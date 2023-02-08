﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Queries.DTO
{
    public class CommentDTO
    {
        public string Description { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
    }
}
