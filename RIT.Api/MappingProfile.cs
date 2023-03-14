using AutoMapper;
using RIT.Api.Dtos.DrillBlockPoints;
using RIT.Api.Dtos.DrillBlocks;
using RIT.Api.Dtos.HolePoints;
using RIT.Api.Dtos.Holes;
using RIT.Data.Entities;

namespace RIT.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //DrillBlocks
        CreateMap<CreateDrillBlock, DrillBlock>()
            .ForMember(d => d.Id, m => m.MapFrom(s => Guid.NewGuid()));
        CreateMap<DrillBlock, GetDrillBlock>();
        CreateMap<UpdateDrillBlock, DrillBlock>();

        //Holes
        CreateMap<CreateHole, Hole>()
            .ForMember(d => d.Id, m => m.MapFrom(s => Guid.NewGuid()));
        CreateMap<Hole, GetHole>();
        CreateMap<UpdateHole, Hole>();

        //DrillBlockPoints
        CreateMap<CreateDrillBlockPoint, DrillBlockPoints>()
            .ForMember(d => d.Id, m => m.MapFrom(s => Guid.NewGuid()));
        CreateMap<DrillBlockPoints, GetDrillBlockPoint>();
        CreateMap<UpdateDrillBlockPoint, DrillBlockPoints>();

        //HolePoints
        CreateMap<CreateHolePoint, HolePoints>()
            .ForMember(d => d.Id, m => m.MapFrom(s => Guid.NewGuid()));
        CreateMap<HolePoints, GetHolePoint>();
        CreateMap<UpdateHolePoint, HolePoints>();
    }
}