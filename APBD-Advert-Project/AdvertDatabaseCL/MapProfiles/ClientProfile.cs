using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using Advert.Database.Entities;
using AutoMapper;

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