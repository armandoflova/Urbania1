using AutoMapper;
using UrbaniaApi.Dtos;
using UrbaniaApi.Models;

namespace UrbaniaApi.Helpers
{
    public class AutoMapperPerfiles: Profile
    {
        public AutoMapperPerfiles()
        {
            CreateMap<Proyecto , ProyectoReturn>();
            CreateMap<Foto , FotoReturn>();
        }
    }
}