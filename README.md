# notifier
A simple console app for sending daily SMS messages via Twilio based on a list of times and destinations in a CSV file

You'll need 4 environment variables:

TWILIO_ACCOUNT_SID - Get this from Twilio
TWILIO_AUTH_TOKEN - Get this from Twilio
NOTIFIER_PATH - This is a path to the CSV file containing message details (eg: c:\temp\notifier.csv)
NOTIFIER_FROM - The phone number the SMS will come from.

Note: all phone numbers should be in the format: +15555555555

CSV file format: Three columns, the first row is the header. Example:

Time,Text,Destination
08:00,First Message,+15555555555
09:00,Its 9am,+15555555555
