/**
* 命名空间: SportsStore.Domain.Concrete
*
* 功 能： N/A
* 类 名： EmailOrderProcessor
* CLR V:  4.0.30319.42000
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/9/22 16:41:12 PC-CAOYUNMING
*/
using System;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;


namespace SportsStore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "order@example.com";
        public string MailFromAddress = "sportsstore@example.com";
        public bool UseSsl = true;
        public string UserName = "mystmpusername";
        public string PassWord = "mystmppassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"D:\project_files\ProMVC5_20180922\SportsStore\SportsStore.WebUI\EmailFiles";
    }


    /// <summary>
    /// 发送订单邮件
    /// </summary>
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(ShopCart cart, ShippingDetails shippingDetails)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.UserName, emailSettings.PassWord);
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder();
                body.Append("A new order has been submitted");
                body.Append("---");
                body.Append("Items:");
                foreach (var item in cart.Lines)
                {
                    var subtotal = item.Product.Price * item.Count;
                    body.AppendFormat("{0} x {1} (subtotal:{2:c})", item.Count, item.Product.Name, subtotal);
                }

                body.AppendFormat("Total order value: {0:c}", cart.ComputeToValue())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingDetails.Name)
                    .AppendLine(shippingDetails.Line1)
                    .AppendLine(shippingDetails.Line2 ?? "")
                    .AppendLine(shippingDetails.Line3 ?? "")
                    .AppendLine(shippingDetails.City)
                    .AppendLine(shippingDetails.State ?? "")
                    .AppendLine(shippingDetails.Country)
                    .AppendLine(shippingDetails.Zip)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap:{0}", shippingDetails.GiftWrap ? "Yes" : "No");

                MailMessage mailMessage = new MailMessage(emailSettings.MailFromAddress, emailSettings.MailToAddress, "New order submitted", body.ToString());
                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }
                smtpClient.Send(mailMessage);
            }
        }
    }
}
