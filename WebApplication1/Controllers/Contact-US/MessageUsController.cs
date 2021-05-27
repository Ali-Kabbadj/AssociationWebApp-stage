using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Classes;
using WebApplication1.Models.Contact_Us;

namespace WebApplication1.Controllers.Contact_US
{
    public class MessageUsController : Controller
    {
        private readonly IEmailSender EmailSender;
        public MessageUsController( IEmailSender emailSender)
        {
            EmailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult SendMessage(ContactForm Form)
        {
            if (ModelState.IsValid)
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("Association2021", "NoResponseAssotiontion2021@outlook.com"));
                // To : Mohamed ABOUFIRASS Adresse : m.aboufirass@resing.ma
                emailMessage.To.Add(new MailboxAddress("AliKabbadj", "Alikabbadj1994@gmail.com"));
                emailMessage.Subject = "Message depuis Contact Form Du site";
                emailMessage.Body = new TextPart("plain")
                {
                    Text = String.Format("This visitor:{0} with this email:{1} Send this message:{2}", Form.Name, Form.Email, Form.Message)
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp-mail.outlook.com", 587);
                    client.Authenticate("NoResponseAssotiontion2021@outlook.com", "0668882287_Ali");
                    client.Send(emailMessage);
                    client.Disconnect(true);
                }
            }
            return RedirectToAction("Index","Home");
        }
    }
}
