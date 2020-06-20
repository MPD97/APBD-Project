
using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Advert.Database.Entities;

namespace Advert.Database.MapProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientRegisterRequestModel>();
            CreateMap<Client, ClientResponseModel>();
            CreateMap<ClientResponseModel, Client>();
            CreateMap<ClientRegisterRequestModel, Client>();
        }
    }
}
