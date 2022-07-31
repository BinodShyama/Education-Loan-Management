using LoanManagement.Domain;
using LoanManagement.Domain.Entities;
using LoanManagement.ViewModel.ResponseModel;
using LoanManagement.ViewModel.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Users.Commands.Create
{
   public class CreateUserCommand : IRequest<ResponseModel< UserCreateDto>>
    {
        public UserCreateDto userCreateDto { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseModel<UserCreateDto>>
        {
            private readonly ApplicationDbContext _context;
            private readonly UserManager<User> _userManager;
            public CreateUserCommandHandler(ApplicationDbContext context, UserManager<User> userManager)
            {
                _context = context;
                _userManager = userManager;
                
            }

            public async Task<ResponseModel<UserCreateDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = new User()
                    {
                        Status = true,
                        FirstName = request.userCreateDto.FirstName,
                        Email = request.userCreateDto.Email,
                        UserName = request.userCreateDto.UserName,
                        CreatedAt = DateTime.Now,
                        IsAdmin = false,
                        EmailConfirmed = true,
                        CreatedBy= request.userCreateDto.CreatedBy
                    };
                    await _userManager.CreateAsync(user, request.userCreateDto.Password);
                    await _context.SaveChangesAsync(cancellationToken);
                    return new ResponseModel<UserCreateDto> { Data = request.userCreateDto, Messages = new List<string> { "User saved succussfully." }, Status = true };
                }
                catch(Exception ex)
                {
                    return new ResponseModel<UserCreateDto> { Data = request.userCreateDto, Messages = new List<string> { "Failed to save the user." }, Status = false };
                }
            }
        }
    }
}