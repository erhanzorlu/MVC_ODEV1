using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ODEV1.Models.Entities
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}