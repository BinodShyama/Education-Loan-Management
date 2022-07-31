using LoanManagement.Domain;
using LoanManagement.Domain.Entities;
using LoanManagement.ViewModel.ResponseModel;
using LoanManagement.ViewModel.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<ResponseModel<UserUpdateDto>>
    {
        public UserUpdateDto userUpdateDto { get; set; }
        public string id { get; set; }
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseModel<UserUpdateDto>>
        {
            private readonly ApplicationDbContext _context;
            private readonly UserManager<User> _userManager;
            public UpdateUserCommandHandler(ApplicationDbContext context, UserManager<User> userManager)
            {
                _context = context;
                _userManager = userManager;

            }

            public async Task<ResponseModel<UserUpdateDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = await _context.User.Where(c => c.Id == request.id).FirstOrDefaultAsync();
                    if (user != null)
                    {
                        user.FirstName = request.userUpdateDto.FirstName;
                        user.UserName = request.userUpdateDto.UserName;
                        user.NormalizedUserName = request.userUpdateDto.UserName.ToUpper();
                        user.UpdatedAt = DateTime.Now;
                        user.UpdatedBy = request.userUpdateDto.UpdatedBy;
                        if (!string.IsNullOrEmpty(request.userUpdateDto.Password))
                        {
                            var newPassword = _userManager.PasswordHasher.HashPassword(user, request.userUpdateDto.Password);
                            user.PasswordHash = newPassword;
                        }

                        var res = await _userManager.UpdateAsync(user);

                        await _context.SaveChangesAsync();
                        return new ResponseModel<UserUpdateDto> { Data = request.userUpdateDto, Messages = new List<string> { "User updated succussfully." }, Status = true };
                    }
                    else
                        return new ResponseModel<UserUpdateDto> { Data = request.userUpdateDto, Messages = new List<string> { "Failed to save the user." }, Status = false };

                }
                catch (Exception ex)
                {
                    return new ResponseModel<UserUpdateDto> { Data = request.userUpdateDto, Messages = new List<string> { "Failed to save the user." }, Status = false };
                }
            }

        }
    }
}