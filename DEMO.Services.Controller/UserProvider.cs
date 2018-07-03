using DEMO.Data;
using DEMO.Entity;
using DEMO.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO.Services.Controller
{
    class UserProvider : IUserProvider
    {
        public override void AddUser(User item, string userLogg)
        {
            try
            {
                using (var context = new DemoModel())
                {
                    IRepository<User> rep = new EfRepository<User>(context);

                    if (item.UserId == 0)
                    {
                        item.FlagActivo = true;
                        item.CreadoPor = userLogg;
                        item.FechaCreacion = DateTime.Now;
                        rep.Insert(item);
                    }
                    else
                    {
                        var userToUp = rep.Table.Where(x => x.UserId == item.UserId).FirstOrDefault();
                        userToUp.Email = item.Email;

                        userToUp.DNI = item.DNI;
                        userToUp.FirstName = item.FirstName;
                        userToUp.LastName = item.LastName;
                        userToUp.MobilePhone = item.MobilePhone;

                        rep.Update(userToUp);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log
            }
        }

        public override List<User> GetUsersByType(string Nombre, DateTime? fechaI, DateTime? fechaF, bool? flagActivo, int pageNumber, int pageSize, out int total)
        {
            try
            {
                using (var context = new DemoModel())
                {
                    var dtFechaI = fechaI.HasValue ? new DateTime(fechaI.Value.Year, fechaI.Value.Month, fechaI.Value.Day) : (DateTime?)null;
                    var dtFechaF = fechaF.HasValue ? new DateTime(fechaF.Value.Year, fechaF.Value.Month, fechaF.Value.Day) : (DateTime?)null;
                    

                    IRepository<User> rep = new EfRepository<User>(context);
                    var registros = rep.Table.Where(x => x.FlagActivo
                                                     && (x.FechaCreacion >= dtFechaI || !dtFechaI.HasValue)
                                                     && (x.FechaCreacion <= dtFechaF || !dtFechaF.HasValue)
                                                     && !x.FlagEliminado
                                                     && (x.FullName.ToUpper().Contains(Nombre.ToUpper()) || string.IsNullOrEmpty(Nombre))
                                                    );

                    total = registros.ToList().Count;

                    var listaFinal = registros.OrderBy(x => x.FirstName).Skip((pageNumber - 1) * pageSize).Take(pageSize).Distinct();

                    return listaFinal.ToList();
                }
            }
            catch (Exception ex)
            {
                // Log
                throw new Exception();
            }
        }
    }
}
