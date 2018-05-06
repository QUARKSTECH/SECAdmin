using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SECAdmin.Web.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappings";

        public DomainToViewModelMappingProfile()
        {
            Configure();
        }

        private void Configure()
        {
            //Mapper.CreateMap<Prospect, ProspectViewModel>()
            //    .ForMember(vm => vm.ID, map => map.MapFrom(m => m.Tract.ID)) //For Reference

        }
    }
}