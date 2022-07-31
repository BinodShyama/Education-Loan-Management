using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.Domain.Entities;
using LoanManagement.ViewModel.Address;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Provinces.Queries.GetDistricts
{
    public class GetDistrictListQuery : IRequest<List<DistrictDto>>
    {
        public class GetDistrictListQueryHandler : IRequestHandler<GetDistrictListQuery, List<DistrictDto>>
        {
            private readonly ApplicationDbContext _db;
            private readonly IMapper _mapper;
            public GetDistrictListQueryHandler(ApplicationDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<List<DistrictDto>> Handle(GetDistrictListQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<DistrictDto>>(await _db.District.Include(c=>c.Province).ToListAsync());
            }
        }
    }
}
