using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.ViewModel.Address;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Provinces.Queries.GetProvinces
{
    public  class GetProvinceListQuery:IRequest<List<ProvinceDto>>
    {
        public class GetProvincesQueryHandler : IRequestHandler<GetProvinceListQuery, List<ProvinceDto>>
        {
            private readonly ApplicationDbContext _db;
            private readonly IMapper _mapper;
            public GetProvincesQueryHandler(ApplicationDbContext db,IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<List<ProvinceDto>> Handle(GetProvinceListQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<ProvinceDto>>( await _db.Province.ToListAsync());
            }
        }
    }
}
