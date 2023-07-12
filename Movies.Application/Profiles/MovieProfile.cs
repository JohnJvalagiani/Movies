using AutoMapper;
using Movies.Application.Models;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<WatchlistItemResponse, WatchlistItem>().ReverseMap();
            CreateMap<Movie, MovieResponse>().ReverseMap();
        }
    }
}
