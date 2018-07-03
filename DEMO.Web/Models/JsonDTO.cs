using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DEMO.Entity;

namespace DEMO.Web.Models
{
    public class JsonDTO
    {
        public List<User> ListUser { get; internal set; }
        public int Total { get; internal set; }
    }
}