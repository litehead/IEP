using IEP.BusinessLogic.Entities;
using IEP.Models;
using Nelibur.ObjectMapper;

namespace IEP.App_Start
{
    public static class TinyMapperConfig
    {
        public static void RegisterMappings()
        {
            TinyMapper.Bind<LoginViewModel, User>(config => config.Ignore(x => x.RememberMe));
        }
    }
}