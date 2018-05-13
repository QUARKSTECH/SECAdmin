﻿using AutoMapper;
using SECAdmin.Entity;
using SECAdmin.ViewModel;
using System.Linq;

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

            CreateMap<ClientDetailViewModel, ClientDetail>();
            CreateMap<ClientDetailViewModel, ClientDetail>().ReverseMap();

        }
    }
}