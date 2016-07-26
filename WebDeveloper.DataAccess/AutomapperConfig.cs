using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebDeveloper.Model;
using WebDeveloper.Model.DTO;

namespace WebDeveloper.DataAccess
{
    public class Automapper
    {
        private static readonly MapperConfiguration _config = null;
        private static readonly object padlock = new object();

        static Automapper()
        {
            _config = SetAutomapperConfig();
        }

        private static MapperConfiguration SetAutomapperConfig()
        {
            lock (padlock)
            {
                return _config ?? new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Person, PersonModelView>();
                    cfg.CreateMap<Address, AddressModelView>();
                });
            }
        }


        public static IEnumerable<R> GetGeneric<T, R>(IEnumerable<T> claimList)
        {
            var mapper = _config.CreateMapper();
            return mapper.Map<IEnumerable<T>, List<R>>(claimList);
        }

        public static R GetGeneric<T, R>(T keyDocumentParent)
        {
            var mapper = _config.CreateMapper();
            return mapper.Map<T, R>(keyDocumentParent);
        }
    }
}
