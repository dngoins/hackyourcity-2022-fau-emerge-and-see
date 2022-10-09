using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Twilio.Base;
using Twilio.AspNet.Common;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace az_fn_hackathon_people_trigger
{
    public class Function1
    {
        private static HttpClient client = new HttpClient();
        
        [FunctionName("Function1")]
        public void Run([IoTHubTrigger("messages/events", Connection = "Endpoint=sb://iothub-ns-tse-iot-hu-8017541-55f05f82d3.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=L+SicQlLGlFGlnViRnILRNpMPr8aJ9wBYsz3AkkkrQE=;EntityPath=tse-iot-hub-santacruz")]EventData message, ILogger log)
        {
            log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");

            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "ACb4ef08528b658067385dff8599ec1809";//Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = "eb97bc6adae662437e09982618f94048"; // Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(accountSid, authToken);

            var msg = MessageResource.Create(
                body: "DroneAid is here to help. We have wifi access turn on your phones and connect to DroneAid wireless network",
                from: new Twilio.Types.PhoneNumber("+19548645004"),
                to: new Twilio.Types.PhoneNumber("+19548645004")
            );


        }
    }
}