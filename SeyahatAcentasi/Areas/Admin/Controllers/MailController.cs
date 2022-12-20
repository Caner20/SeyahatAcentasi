using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Org.BouncyCastle.Crypto.Macs;
using SeyahatAcentasi.Models;

namespace SeyahatAcentasi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {

            MimeMessage mm = new MimeMessage();

            MailboxAddress mbFrom = new MailboxAddress("Admin", "bilmemseyahat@gmail.com"); //kontrol admin, gonderen mai
            mm.From.Add(mbFrom);//mailin buradan geldigini kullaniciya bildirdik from(kimden)

            MailboxAddress mbTo = new MailboxAddress("User",mailRequest.AlıcıMail); //gonderilicek olan kisinin adi , alicinin maili
            mm.To.Add(mbTo);//mailin kime gidiceginin adresini belirledik to(kime)

            var bodyBuilder = new BodyBuilder();  //icerigi olusturmak icin
            bodyBuilder.TextBody = mailRequest.Icerik; //icerigi goruntuleyebilmek icin 
            mm.Body = bodyBuilder.ToMessageBody();  //mm den gelen body ile insa ettik messageBody ile

            mm.Subject = mailRequest.Konu;  //parametreden gelen konuyu mm'nin konusuna atadik

            SmtpClient client = new SmtpClient();   //bu sınıf bir protokol sunucusu
            client.Connect("smtp.gmail.com", 587, false);      //baglanti saglandi mail adresine , portu
            client.Authenticate("bilmemseyahat@gmail.com", "xsuykoosahpmgglf");  //kim tarafından gonderilicegini belirtilicek
            client.Send(mm);          //mm 'daki degeri gonder
            client.Disconnect(true);
            return View();
        }
    }
}

//bilmemseyahat@gmail.com gonderen mail
//sifre