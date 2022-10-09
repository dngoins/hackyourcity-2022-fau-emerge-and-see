using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace DroneAid_SMSUtil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "ACb4ef08528b658067385dff8599ec1809"; // Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = "eb97bc6adae662437e09982618f94048"; // Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(accountSid, authToken);

            // make an associative array of people we know, indexed by phone number
            var people = new Dictionary<string, string>() {
                {"+19549131222", "Rawan"},
                {"+19548645004", "Dwight"},
                {"+15613017973", "Malika"}
            };

           
            
            // Iterate over all our friends
            foreach (var person in people)
            {
                // Send a new outgoing SMS by POSTing to the Messages resource
                MessageResource.Create(
                    from: new PhoneNumber("+13857071552"), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber("+19548645004"), // To number, if using Sandbox see note above
                                                     // Message content
                    body: $"Hey {person.Value} Monkey Party at 6PM. Bring Bananas!");

                Console.WriteLine($"Sent message to {person.Value}");
            }
     
        
        }


    }



}
