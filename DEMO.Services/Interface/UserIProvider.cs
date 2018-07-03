using DEMO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO.Services.Interface
{
    public abstract partial class UserIProvider : BaseDBProvider
    {
        public abstract void AddUser(User item, string user);
        public abstract List<User> GetUsersByType(string Nombre, DateTime? fechaI, DateTime? fechaF, bool? flagActivo, int pageNumber, int pageSize, out int total);
    }
}
