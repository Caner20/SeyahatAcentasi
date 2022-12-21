using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.MailDTOs
{
    public class MailRequestDTOs
    {
        public string Isim { get; set; }
        public string GonderenMail { get; set; }
        public string AlıcıMail { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }
    }
}
