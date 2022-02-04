using AntChallenge.ViewModels;
using AutoMapper;
using DataAccessLayer.Models;

namespace AntChallenge.Mappings
{
    public class ProfessorProfile:Profile
    {
        public ProfessorProfile()
        {
            CreateMap<Professor, ProfessorViewModel>()
                .ReverseMap();
        }
    }
}
