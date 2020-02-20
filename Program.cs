using System;
using System.Net;
using System.Net.Mail;

internal class Program
{
	private static void Main(string[] args)
	{
		string FROM = "shakelyconsultingllc@gmail.com";
		string FROMNAME = "Joe Shakely";
		string TO = "joeshakely@gmail.com";
		string SMTP_USERNAME = "AKIA6NY7BEZUOFUEVLMI";
		string SMTP_PASSWORD = "BJKEwh7n+uvVcJ06qaH1xulk3toxloCEYgazjPAK1jaZ";
		string HOST = "email-smtp.us-west-2.amazonaws.com";
		int PORT = 587;
		string SUBJECT = "ATTN Email from https://casillas-law.github.io/";
		string BODY = "<h1>Amazon SES Test</h1><p>This email was sent through the <a href='https://aws.amazon.com/ses'>Amazon SES</a> SMTP interface using the .NET System.Net.Mail library.</p>";
		MailMessage message = new MailMessage
		{
			IsBodyHtml = true,
			From = new MailAddress(FROM, FROMNAME)
		};
		message.To.Add(new MailAddress(TO));
		message.Subject = SUBJECT;
		message.Body = BODY;
		using (SmtpClient client = new SmtpClient(HOST, PORT))
		{
			client.Credentials = new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);
			client.EnableSsl = true;
			try
			{
				Console.WriteLine("Attempting to send email...");
				client.Send(message);
				Console.WriteLine("Email sent!");
			}
			catch (Exception ex)
			{
				Console.WriteLine("The email was not sent.");
				Console.WriteLine("Error message: " + ex.Message);
			}
		}
	}
}
