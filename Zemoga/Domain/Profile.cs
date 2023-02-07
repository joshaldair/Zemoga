using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public  class Profile : BaseDomainModel
{
    public Profile()
    {
        Users = new HashSet<User>();
    }

    public string Name { get; set; }    

    public ICollection<User> Users { get; set; }
}
