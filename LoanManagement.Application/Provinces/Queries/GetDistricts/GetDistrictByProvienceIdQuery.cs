using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.Domain.Entities;
using LoanManagement.ViewModel.Address;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Provinces.Queries.GetDistricts
{
    public class GetDistrictByProvienceIdQuery : IRequest<List<DistrictDto>>
    {
        public int ProvienceId { get; set; }
        public class GetDistrictByProvienceIdQueryHandler : IRequestHandler<GetDistrictByProvienceIdQuery, List<DistrictDto>>
        {
            private readonly ApplicationDbContext _db;
            private readonly IMapper _mapper;
            public GetDistrictByProvienceIdQueryHandler(ApplicationDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<List<DistrictDto>> Handle(GetDistrictByProvienceIdQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<DistrictDto>>(await _db.District.Where(c => c.ProvinceId == request.ProvienceId).ToListAsync());
            }
        }
    }
}
