using System;
using System.Web.Mvc;
using AutoMapper;
using MVC4.Extensions.Automapper.Resolvers;
using Infrastructure;
using MVC4.Extensions;

namespace MVC4.Infrastructure.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {

            Mapper.Initialize(cfg =>
                                  {
                                      cfg.ConstructServicesUsing(t => IoC.Instance.Resolve(t));
                                      IoC.Instance.ResolveAll<Profile>().ForEach(cfg.AddProfile);
                                  });

            Mapper.CreateMap<string, MvcHtmlString>().ConvertUsing<MvcHtmlStringConverter>();

            Mapper.CreateMap<decimal, uint>().ConvertUsing(Convert.ToUInt32);

        }  
}
}