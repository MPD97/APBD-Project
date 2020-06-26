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
            CreateMap<Client, ClientRegisterRequest>();
            CreateMap<Client, ClientResponse>();
            CreateMap<ClientResponse, Client>();
            CreateMap<ClientRegisterRequest, Client>();
        }
    }
}