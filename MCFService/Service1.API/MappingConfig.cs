using AutoMapper;
using Service1.API.Entities;
using Service1.API.Models.Dtos;

namespace Service1.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<MsStorageLocation, StorageLocationDto>().ReverseMap();
                config.CreateMap<TrBpkb, TrBpkbDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
