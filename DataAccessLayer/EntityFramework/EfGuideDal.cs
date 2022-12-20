using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfGuideDal : GenericRepository<Guide>, IGuideDal
    {
        Context context = new Context();
        public void ChangeToFalseByGuide(int id)
        {
            var values = context.Guides.Find(id); //context nesnesine veri tabanından rehberlerin id sini bul values'a at
            values.Status = false;  //gelen id ye gore rehberin durumunu false yap
            context.Update(values); //values den gelen degeri guncelle 
            context.SaveChanges();  //nesnedeki degisikleri kaydet
        }

        public void ChangeToTrueByGuide(int id)
        {
            var values = context.Guides.Find(id); //context nesnesine veri tabanından rehberlerin id sini bul values'a at
            values.Status = true;  //gelen id ye gore rehberin durumunu true yap
            context.Update(values);
            context.SaveChanges();
        }
    }
}
