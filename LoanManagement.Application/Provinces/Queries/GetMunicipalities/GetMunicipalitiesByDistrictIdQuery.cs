using LoanManagement.Domain;
using LoanManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Provinces.Queries.GetMunicipalities
{
   public  class GetMunicipalitiesByDistrictIdQuery:IRequest<List<Municipalities>>
    {
        public int DistrinctId { get; set; }
        public class GetMunicipalitiesByDistrictIdQueryHandler : IRequestHandler<GetMunicipalitiesByDistrictIdQuery, List<Municipalities>>
        {
            private readonly ApplicationDbContext _db;

            public GetMunicipalitiesByDistrictIdQueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<List<Municipalities>> Handle(GetMunicipalitiesByDistrictIdQuery request, CancellationToken cancellationToken)
            {
                return await _db.Municipality.Where(c => c.DistrinctId == request.DistrinctId).ToListAsync();
            }
        }
    }
}
