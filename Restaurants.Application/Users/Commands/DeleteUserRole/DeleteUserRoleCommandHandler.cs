
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands.DeleteUserRole
{
    public class DeleteUserRoleCommandHandler(
        ILogger<DeleteUserRoleCommandHandler> logger,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager
        ) : IRequestHandler<DeleteUserRoleCommand>
    {
        public async Task Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting role {RoleName} for user {UserEmail}", request.RoleName, request.UserEmail);

            var user = await userManager.FindByEmailAsync(request.UserEmail)
                ?? throw new NotFoundException(nameof(User), request.UserEmail);

            var role = await roleManager.FindByNameAsync(request.RoleName)
                ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

            await userManager.RemoveFromRoleAsync(user, role.Name);
        }
    }
}
