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
                body: "Hi there! Thanks for joining Hack It Out <3"
            );

            Console.WriteLine(message.Sid);

            var call = CallResource.Create(
                to: new PhoneNumber(Secrets.TO_NUMBER),
                from: new PhoneNumber(Secrets.TWILIO_PHONENUMBER),
                url: new Uri("https://handler.twilio.com/twiml/EH629ee4f090a841cc524ff347e2c4aa64")
            );

            Console.WriteLine(call.Sid);
        }
    }
}
