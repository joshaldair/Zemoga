using Application.Features.Comments.Queries.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Queries.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public bool IsPending { get; set; }
        public bool IsApproved { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}
