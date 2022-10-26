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
   public class FeatureManager : IFeatureService
    {
        IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)  //Feature cons parametre alıyor
        {
            _featureDal = featureDal;    //parametredeki değeri _featureDal 'a atıyor
        }

        public Feature GetTByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Feature t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Feature t)
        {
            throw new NotImplementedException();
        }

        public List<Feature> TGetList()
        {
            return _featureDal.GetList(); //cagrıldıgı yere liste döndürücek
        }

        public void TUpdate(Feature t)
        {
            throw new NotImplementedException();
        }
    }
}
