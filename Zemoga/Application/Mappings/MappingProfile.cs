﻿using Application.Features.Authors.Commands;
using Application.Features.Authors.Queries.DTO;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {

            // AUTHOR
            CreateMap<CreateAuthorCommand,Author>();
            CreateMap<UpdateAuthorCommand, Author>();
            CreateMap<DeleteAuthorCommand, Author>();
            CreateMap<Author, AuthorDTO>();

        }
    }
}
