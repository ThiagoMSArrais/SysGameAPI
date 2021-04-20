using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sysgame.API.ViewModels;
using SysGame.Domain.Models;

namespace Sysgame.API.Configuration
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<Amigo, AmigoViewModel>().ReverseMap();
            CreateMap<Jogo, JogoViewModel>().ReverseMap();
        }
    }

    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new AutomapperConfiguration());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
