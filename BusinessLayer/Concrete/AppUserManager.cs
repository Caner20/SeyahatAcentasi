using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Migrations;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService    //manager impleme edildi serviceden
    {
        IAppUserDal _appUserDal;   //IappuserDal dan degisken tanımlandi

        public AppUserManager(IAppUserDal appUserDal)    //constructor tanımlandı parametreli
        {
            _appUserDal = appUserDal;     //girilen deger degiskene atandi
        }

        public AppUser GetTByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> TGetList()    //liste olarak appuser'i donduren getlist metoduyla cagiriyoruz
        {
            return _appUserDal.GetList();   //bu ozelligi getlistle.dondurduk
        }

        public void TUpdate(AppUser t)
        {
            throw new NotImplementedException();
        }
    }
}
