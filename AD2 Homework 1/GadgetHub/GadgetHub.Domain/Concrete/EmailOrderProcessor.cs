﻿using System.Net;
using System.Net.Mail;
using System.Text;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;

namespace GadgetHub.Domain.Concrete
{
	public class EmailSettings
	{
		public string MailToAddress = "orders@example.com";
		public string MailFromAddress = "sportsstore@example.com";
		public bool UseSsl = true;
		public string Username = "MySmtpUsername";
		public string Password = "MySmtpPassword";
		public string ServerName = "smtp.example.com";
		public int ServerPort = 587;
		public bool WriteAsFile = true;
		public string FileLocation = @"c:\gadget_hub_emails";
	}

	public class EmailOrderProcessor : IOrderProcessor
	{
		private EmailSettings emailSettings;
		public EmailOrderProcessor(EmailSettings settings)
		{
			emailSettings = settings;
		}
		public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
		{
			using (var smtpClient = new SmtpClient())
			{
				smtpClient.EnableSsl = emailSettings.UseSsl;
				smtpClient.Host = emailSettings.ServerName;
				smtpClient.Port = emailSettings.ServerPort;
				smtpClient.UseDefaultCredentials = false;
				smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

				if (emailSettings.WriteAsFile)
				{
					smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
					smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
					smtpClient.EnableSsl = false;
				}

				StringBuilder body = new StringBuilder()
					.AppendLine("A new order has been submitted")
					.AppendLine("---")
					.AppendLine("Items:");

				foreach (var line in cart.Lines)
				{
					var subtotal = line.Gadget.GadgetPrice * line.Quantity;
					body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity, line.Gadget.GadgetName, subtotal);
				}

				body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
					.AppendLine("---")
					.AppendLine("Ship to:")
					.AppendLine(shippingInfo.Name)
					.AppendLine(shippingInfo.Line1)
					.AppendLine(shippingInfo.Line2 ?? "")
					.AppendLine(shippingInfo.Line3 ?? "")
					.AppendLine(shippingInfo.City)
					.AppendLine(shippingInfo.State ?? "")
					.AppendLine(shippingInfo.Country)
					.AppendLine(shippingInfo.Zip)
					.AppendLine("---")
					.AppendFormat("Gift wrap: {0}", shippingInfo.GiftWrap ? "Yes" : "No");

				MailMessage mailMessage = new MailMessage(
					emailSettings.MailFromAddress,
					emailSettings.MailToAddress,
					"New order submitted!",
					body.ToString());

				if (emailSettings.WriteAsFile)
				{
					mailMessage.BodyEncoding = Encoding.ASCII;
				}
				smtpClient.Send(mailMessage);
			}
		}
	}
}
