﻿using AutoMapper;
using Flight_Planner.Core.Models;
using FlightPlanner3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightPlanner3.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper GetMapper() 
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AirportRequest, Airport>()
                    .ForMember(d => d.Id,
                    s => s.Ignore());
                cfg.CreateMap<Airport, AirportRequest>();

                cfg.CreateMap<FlightRequest, Flight>();
                cfg.CreateMap<Flight, FlightRequest>();

                cfg.CreateMap<AirportResponse, AirportRequest>()
                    .ForMember(d => d.Id,
                    opt =>
                    opt.Ignore());
                cfg.CreateMap<AirportRequest, AirportResponse>();

                cfg.CreateMap<FlightRequest, FlightResponse>();

                cfg.CreateMap<Airport, AirportResponse>()
                .ForMember(m => m.AirportCode,
                opt =>
                opt.MapFrom(s => s.AirportCode));
                cfg.CreateMap<AirportResponse, Airport>()
                    .ForMember(m => m.Id,
                    opt => opt.Ignore())
                    .ForMember(m => m.AirportCode,
                    opt =>
                    opt.MapFrom(s => s.AirportCode));
 
                cfg.CreateMap<Flight, FlightResponse>();
            }); 
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}