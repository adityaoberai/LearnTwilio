using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace LearnTwilio
{
    class Program
    {
        static void Main(string[] args)
        {
            var accountSid = Secrets.TWILIO_ACCOUNTSID;
            var authToken = Secrets.TWILIO_AUTHTOKEN;

            TwilioClient.Init(accountSid, authToken);
            
            var message = MessageResource.Create(
                to: new PhoneNumber(Secrets.TO_NUMBER),
                from: new PhoneNumber(Secrets.TWILIO_PHONENUMBER),
                body: "Hi there! Thanks for joining us <3"
            );

            Console.WriteLine(message.Sid);

            var call = CallResource.Create(
                to: new PhoneNumber(Secrets.TO_NUMBER),
                from: new PhoneNumber(Secrets.TWILIO_PHONENUMBER),
                twiml: new Twiml("<Response><Say>Hi there! Thanks for joining us! You're awesome!</Say></Response>")
            );

            Console.WriteLine(call.Sid);
        }
    }
}
