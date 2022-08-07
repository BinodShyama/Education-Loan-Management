using AutoMapper;
using LoanManagement.Domain.Entities;
using LoanManagement.ViewModel.Address;
using LoanManagement.ViewModel.Cheque;
using LoanManagement.ViewModel.LoanCollections;
using LoanManagement.ViewModel.LoanDisbrusement;
using LoanManagement.ViewModel.Media;
using LoanManagement.ViewModel.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Application.Helpers
{
   public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<MemberDetailDto, Member>().ReverseMap();
            CreateMap<MemberLoanDetailDto, MemberLoanDetail>().ReverseMap();
            CreateMap<Domain.Entities.Provinces, ProvinceDto>().ReverseMap();
            CreateMap<LoanDisbrusementCreateDto,LoanDisbrusement>()
                .ForMember(c=>c.CreatedDate,opt=>opt.MapFrom(c=> DateTime.Now))
                .ForMember(c=>c.Id,opt=>opt.MapFrom(c=> Guid.NewGuid()))
                .ForMember(c=>c.Status,opt=>opt.MapFrom(c=> true))
                .ReverseMap();

            CreateMap<LoanDisbrusement, LoanDisbrusementViewDto>()
                .ForMember(c => c.Installments, opt => opt.MapFrom(c => c.LoanDisbrusementDetail));
            CreateMap<LoanDisbrusementDetail, DisbursedIntallments>()
                .ForMember(c => c.Amount, opt => opt.MapFrom(c => c.Amount))
                .ForMember(c => c.Description, opt => opt.MapFrom(c => c.Description));

            CreateMap<LoanCollectionCreateDto, LoanCollection>()
               .ForMember(c => c.CreatedDate, opt => opt.MapFrom(c => DateTime.Now))
               .ForMember(c => c.Id, opt => opt.MapFrom(c => Guid.NewGuid()))
               .ForMember(c => c.Status, opt => opt.MapFrom(c => true))
               .ReverseMap();

            CreateMap<Districts, DistrictDto>()
                .ForMember(c => c.Province, opt => opt.MapFrom(c => c.Province.Name));

            CreateMap<ChequeLayout, ChequeLayoutDto>().ReverseMap();
            CreateMap<Media, MedaiDto>().ReverseMap();
        }
    }
}
