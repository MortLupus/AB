using System;
using AutoMapper;
using MVC4.Models.Fantasy;

namespace MVC4.Integration.BattleScribe.AutoMapper
{
    public class BattleScribeProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Roster, Army>()
                .ForMember(x => x.Race, y => y.MapFrom(z => z.CatalogueName))
                .ForMember(x => x.Points, y => y.MapFrom(z => Convert.ToUInt32(z.PointsLimit)));

            Mapper.CreateMap<Selection, Unit>();

            Mapper.CreateMap<Selection, Character>()
                .ForMember(x => x.Points, y => y.MapFrom(z => Convert.ToUInt32(z.Points / z.Number)))
                .ForMember(x => x.ModelCount, y => y.MapFrom(z => z.Number));
        }
    }
}