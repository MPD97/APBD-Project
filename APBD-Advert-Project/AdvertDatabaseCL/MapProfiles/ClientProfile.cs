
using Advert.Database.DTOs.Responses;
using AdvertDatabaseCL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Database.MapProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientRegisterCommand>();
            CreateMap<Client, ClientResponseModel>();
            CreateMap<ClientResponseModel, Client>();
            CreateMap<ClientRegisterCommand, Client>();
        }
    }
}
