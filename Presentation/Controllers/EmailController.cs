using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Models.Entities;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        // The client secret JSON file path
        static string clientSecretFile = "client_secret.json";

        // The user ID
        static string userId = "me";

        // The scopes for the Gmail API
        static string[] scopes = { GmailService.Scope.GmailSend };

        // POST: api/Email
        // A method to create and send an email using the Gmail API
        [HttpPost]
        public async Task<ActionResult> PostEmail([FromBody] Email emailRequest)
        {
            try
            {
                // Create a Gmail service object
                var gmailService = GetGmailService();

                // Create a Mime message object
                var mimeMessage = CreateMimeMessage(emailRequest);

                // Create a Message object
                var message = CreateMessage(mimeMessage);

                // Send the email using the service
                var response = SendEmail(gmailService, message);

                // Return a success message
                return Ok("Email sent successfully!");
            }
            catch (Exception ex)
            {
                // Return an error message
                return BadRequest(ex.Message);
            }
        }

        // A method to create a Gmail service object
        public static GmailService GetGmailService()
        {
            // Create a credential object
            UserCredential credential;

            // Use the client secret JSON file and the scopes to get the user consent
            using (var stream = new FileStream(clientSecretFile, FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/gmail-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create a Gmail service object using the credential and the application name
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Gmail API Example",
            });

            return service;
        }

        // A method to create a Mime message object
        public static MimeMessage CreateMimeMessage(Email emailRequest)
        {
            // Create a new Mime message object
            var message = new MimeMessage();

            // Set the sender email address
            message.From.Add(new MailboxAddress("Sender Name", "noreplyMindfactory@gmail.com"));

            // Set the recipient email address
            message.To.Add(new MailboxAddress("Receiver Name", emailRequest.ToEmail));

            // Set the subject
            message.Subject = emailRequest.Subject;

            // Set the plain text content
            message.Body = new TextPart("plain") { Text = emailRequest.Body };

            return message;
        }

        // A method to create a Message object
        public static Message CreateMessage(MimeMessage mimeMessage)
        {
            // Create a new Message object
            var message = new Message();

            // Convert the Mime message to a byte array
            Byte[] bytes = Encoding.UTF8.GetBytes(mimeMessage.ToString());

            // Convert the byte array to a base64-encoded string
            var base64 = Convert.ToBase64String(bytes);

            // Replace the characters that are not URL-safe
            base64 = base64.Replace('+', '-').Replace('/', '_').TrimEnd('=');

            // Assign the base64-encoded string to the Raw property
            message.Raw = base64;

            return message;
        }

        // A method to send an email using the service
        public static Message SendEmail(GmailService service, Message message)
        {
            // Call the Send method with the user ID and the message
            var request = service.Users.Messages.Send(message, userId);

            // Execute the request and get the response
            var response = request.Execute();

            return response;
        }
    }
}