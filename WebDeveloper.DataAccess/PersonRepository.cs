using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;
using WebDeveloper.Model.DTO;

namespace WebDeveloper.DataAccess
{
    public class PersonRepository : BaseDataAccess<Person>
    {
        public IEnumerable<PersonModelView> GetListDto()
        {
            using (var dbContext = new WebContextDb())
            {
                return Automapper.GetGeneric<IEnumerable<Person>,List<PersonModelView>>(dbContext.Person.ToList().OrderByDescending(X=>X.ModifiedDate).Take(10));
            }
        }

        public IEnumerable<EmailAddress> EmailList(int id)
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.EmailAddress.Where(em=> em.BusinessEntityID==id).ToList();
            }
        }

        public Person GetPersonById(int id)
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.Person.FirstOrDefault(x => x.BusinessEntityID == id);
            }
        }
    }
}
