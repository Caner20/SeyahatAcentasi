using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _abaoutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            //IAboutDal dan parametre alıyoruz(içerisinde IGenericDal'dan kalıtım alıyor)
           //_aboutDal ile IGenericDal'ın içerisindeki metotları kullanabiliriz
            _abaoutDal = aboutDal; 
        }

        public About GetTByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(About t)
        {
            _abaoutDal.Insert(t);
        }

        public void TDelete(About t)
        {
            _abaoutDal.Delete(t);
        }

        public List<About> TGetList()
        {
            return _abaoutDal.GetList();
        }

        public void TUpdate(About t)
        {
            _abaoutDal.Update(t);
        }
    }
}
