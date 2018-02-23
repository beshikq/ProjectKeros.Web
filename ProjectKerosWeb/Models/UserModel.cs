using System;
using System.Collections.Generic;

namespace ProjectKerosWeb.Models
{
    public partial class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
    }
}
