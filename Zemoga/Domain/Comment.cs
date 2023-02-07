using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Comment : BaseDomainModel
    {
        public string Description { get; set; }
        public int? PostId { get; set; }
        public Post Post { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
