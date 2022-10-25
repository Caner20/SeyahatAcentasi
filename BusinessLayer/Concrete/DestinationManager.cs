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
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _destinationdal;

        public DestinationManager(IDestinationDal destinationdal)
        {
            _destinationdal = destinationdal;
        }

        public Destination GetTByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Destination t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Destination t)
        {
            throw new NotImplementedException();
        }

        public List<Destination> TGetList()
        {
            return _destinationdal.GetList();
        }

        public void TUpdate(Destination t)
        {
            throw new NotImplementedException();
        }
    }
}
