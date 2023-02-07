using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain
{
    public class User : BaseDomainModel
    {
        public User()
        {
            Comments = new HashSet<Comment>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public int? ProfileId { get; set; }

        public Profile Profile { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
