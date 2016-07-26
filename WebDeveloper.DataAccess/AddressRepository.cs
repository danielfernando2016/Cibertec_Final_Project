using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;
using WebDeveloper.Model.DTO;

namespace WebDeveloper.DataAccess
{
    public class AddressRepository : BaseDataAccess<Address>
    {
        public IEnumerable<AddressModelView> GetListDto()
        {
            using (var dbContext = new WebContextDb())
            {
                return Automapper.GetGeneric<IEnumerable<Address>, 
                                            List<AddressModelView>>
                                            (dbContext.Address.ToList().OrderByDescending(x => x.ModifiedDate).Take(10));
            }
        }

        public Address GetById(int id)
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.Address.FirstOrDefault(p => p.AddressID == id);
            }
        }
    }
}
