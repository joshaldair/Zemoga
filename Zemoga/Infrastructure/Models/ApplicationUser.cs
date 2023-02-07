using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ApplicationUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? ProfileId { get; set; }
        public int? Id { get; set; }
    }
}
