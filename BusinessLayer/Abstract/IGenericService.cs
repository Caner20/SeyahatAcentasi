using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
        //Bu Interface'in amacı Business'ta tanımlanan bütün metotlar
       //GenericService'den geçicek Business'te Concrete'e gelicek
    public interface IGenericService<T>
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetList();
        T GetTByID(int id);

    }
}
