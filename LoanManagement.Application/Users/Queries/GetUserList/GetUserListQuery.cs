using AutoMapper;
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

namespace LoanManagement.Application.Users.Queries.GetUserList
{
   public class GetUserListQuery : IRequest<List<UserListDto>>
    {
        public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserListDto>>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetUserListQueryHandler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<UserListDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
            {

                return await _context.User.Where(c=>c.IsAdmin==false).Select(c => new UserListDto
                {
                    Id = c.Id,
                    Name =c.FirstName,
                    Email=c.Email,
                    Status= c.Status? $"<span class='badge badge-pill badge-info'>Active</span>":$" <span class='badge badge-pill badge-warning'>Deactive</span>",
                    UserName=c.UserName,
                    Action= $"<a href='/user/edit/{c.Id}' type = 'button' title='Edit user' class='btn btn-default btn-icon'><i class='fa-solid fa-pencil'></i></a>",
                    
                }).ToListAsync();
            }
        }
    }
}
