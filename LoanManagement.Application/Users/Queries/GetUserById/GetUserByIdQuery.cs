using LoanManagement.Domain;
using LoanManagement.ViewModel.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Users.Queries.GetUserById
{
   public class GetUserByIdQuery : IRequest<UserUpdateDto>
    {
        public string id { get; set; }
        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserUpdateDto>
        {
            private readonly ApplicationDbContext _context;

            public GetUserByIdQueryHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<UserUpdateDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {

               return await _context.User.Where(c => c.Id == request.id).Select(c => new UserUpdateDto {
                UserName=c.UserName,
                FirstName=c.FirstName,
                Email=c.Email,
                Status=c.Status
                }).FirstOrDefaultAsync(cancellationToken);
            }
        }

    }
}
