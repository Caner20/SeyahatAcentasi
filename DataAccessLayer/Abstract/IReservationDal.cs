using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id);  //onay bekleyen rezervasyon
        List<Reservation> GetListWithReservationByAccepted(int id);      //onaylanan rezervasyon
        List<Reservation> GetListWithReservationByPrevious(int id);     //gecmis rezervasyon
    }
}
