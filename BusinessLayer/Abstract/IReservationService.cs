using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    { 
        List<Reservation> GetListWithReservationByWaitApproval(int id);     //onay bekleyenler property'si rezervasyonlardan cekiyor , id ye gore
        List<Reservation> GetListWithReservationByAccepted(int id);     //onaylanan property'si rezervasyonlardan cekiyor , id ye gore
        List<Reservation> GetListWithReservationByPrevious(int id);     //gecmis rezervasyon property'si rezervasyonlardan cekiyor , id ye gore
    }
}
