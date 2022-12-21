using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContactUs
    {
        public int  ContactUsId{get;set;}  //bizimle iletisim  id si

        public string Name{get;set;}   //ismi

        public string Mail { get; set; }     //maili

        public string Subject { get; set; }         //konusu

        public string MessageBody { get; set; }       //mesajın icerigi

        public DateTime MessageDate { get; set; }          //mesajın gonderildigi tarih
    }
}
