using CsvHelper;
using Notifier;
using System.Globalization;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

TwilioClient.Init(accountSid, authToken);


string path = Environment.GetEnvironmentVariable("NOTIFIER_PATH");
string from = Environment.GetEnvironmentVariable("NOTIFIER_FROM");


using (var reader = new StreamReader(path))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var records = csv.GetRecords<Message>();

    foreach (var m in records)
    {
        if (m.Time == DateTime.Now.ToString("HH:mm"))
        {
            var message = MessageResource.Create(
                body: $"{m.Time}: {m.Text}",
                from: new Twilio.Types.PhoneNumber(from),
                to: new Twilio.Types.PhoneNumber(m.Destination)
            );

            Console.WriteLine(message.Sid);
        }
    }
}


