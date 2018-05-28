using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VideoRentalApp.Dtos;
using VideoRentalApp.Models;

namespace VideoRentalApp.App_Start
{
    public class MappingProfile : Profile
    {
        public  MappingProfile()
        {
            //Customer mapping
            CreateMap<Customer, CustomerDto>();
                
            CreateMap<CustomerDto, Customer>();

            //Movie mapping
            CreateMap<Movie, MovieDto>();
                //.ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<MovieDto, Movie>();

            //Membership mapping
            CreateMap<MembershipType, MembershipTypeDto>();

            //Genre mapping
            CreateMap<Genre, GenreDto>();
        }
    }
}