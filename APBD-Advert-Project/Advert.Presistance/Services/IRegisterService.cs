using Advert.Database.DTOs.Requests;
using Advert.Database.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Services
{
    public interface IRegisterService
    {
        public ClientRegisterResponseModel Create(ClientRegisterRequestModel model);
    }
}
