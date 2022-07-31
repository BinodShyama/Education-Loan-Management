using LoanManagement.Application.Members.Queries.GetDegreeList;
using LoanManagement.Application.Members.Queries.GetInstitutionList;
using LoanManagement.Application.Members.Queries.GetUniversityList;
using LoanManagement.Application.Members.Queries.GetWardList;
using LoanManagement.Application.Provinces.Queries.GetDistricts;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Sevices
{
    public interface ISelectListService
    {
        List<SelectListItem> GetRelationshipList();
        Task<List<SelectListItem>> GetDistrictList();
        Task<List<SelectListItem>> GetDegreeList();
        Task<List<SelectListItem>> GetInstitutionList();
        Task<List<SelectListItem>> GetUniversityList();
        Task<List<SelectListItem>> GetWardList();
    }

    public class SelectListService : ISelectListService
    {
        private readonly IMediator _mediator;
        public SelectListService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<SelectListItem>> GetDegreeList()
        {
            var degree = await _mediator.Send(new GetDegreeListQuery());
            return degree.Select(c => new SelectListItem { Text = c, Value = c }).ToList();
        }

        public async Task<List<SelectListItem>> GetDistrictList()
        {
            var district = await _mediator.Send(new GetDistrictListQuery());
            return district.Select(c => new SelectListItem { Text = c.Name, Value = c.Name, Selected = (c.Id == 23 ? true : false) }).ToList();
        }

        public async Task<List<SelectListItem>> GetInstitutionList()
        {
            var institution = await _mediator.Send(new GetInstitutionListQuery());
            return institution.Select(c => new SelectListItem { Text = c, Value = c }).ToList();
        }

        public List<SelectListItem> GetRelationshipList()
        {
            return new List<SelectListItem>() {new SelectListItem { Text = "Father", Value = "Father" },
                new SelectListItem { Value = "Mother", Text = "Mother" },
            new SelectListItem { Value = "GrandFather", Text = "GrandFather" },
            new SelectListItem { Value = "GrandMother", Text = "GrandMother" },
            new SelectListItem { Value = "Wife", Text = "Wife" },
            new SelectListItem { Value = "Husband", Text = "Husband" },
            new SelectListItem { Value = "Brother", Text = "Brother" },
            new SelectListItem { Value = "Sister", Text = "Sister" },
            new SelectListItem { Value = "Other", Text = "Other" } };
        }

        public async Task<List<SelectListItem>> GetUniversityList()
        {
            var university = await _mediator.Send(new GetUniverssityListQuery());
            return university.Select(c => new SelectListItem { Text = c, Value = c }).ToList();
        }

        public async Task<List<SelectListItem>> GetWardList()
        {
            var ward = await _mediator.Send(new GetWardListQuery());
            return ward.Select(c => new SelectListItem { Text = c, Value = c }).ToList();
        }
    }
}
