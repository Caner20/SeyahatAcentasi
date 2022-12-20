namespace SeyahatAcentasi.Models
{
    public class MailRequest
    {
        public string Isim { get; set; }
        public string GonderenMail { get; set; }
        public string AlıcıMail { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }
    }
}
