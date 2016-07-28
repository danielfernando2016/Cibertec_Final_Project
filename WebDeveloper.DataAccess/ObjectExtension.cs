using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDeveloper.DataAccess
{
    public static class ObjectExtension
    {
        public static IEnumerable<Tsource> Page <Tsource>(this IEnumerable<Tsource> source,
                                                            int page, int pageSize)
        {
            //Esto es una expresiones lambdas
            //Skip le dice cuantos registros debe tomar en cuenta a partir de un determinado numero
            //Skip(50) de 1000 registros deberia tomar desde el 51

            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
