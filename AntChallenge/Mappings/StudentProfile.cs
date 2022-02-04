using AntChallenge.ViewModels;
using AutoMapper;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntChallenge.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ReverseMap();
        }
    }
}

