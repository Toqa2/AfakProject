using Afak.Service.Dto;
using Afak.Service.MappingConfiguration;
using AfakProject.Data;
using AfakProject.Data.DatabaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afak.Service.Service
{
    public class UserService : IUserService
    {
        private readonly AfakContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(AfakContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<bool> AddAsync(AddUserDto addUserDto)
        {
            try
            {
                ApplicationUser appUser = new ApplicationUser();
                Mapping.Mapper.Map(addUserDto, appUser);

                IdentityResult addUserResult = await userManager.CreateAsync(appUser, addUserDto.Password);
                return addUserResult.Succeeded;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<UserListDto>?> List()
        {
            try
            {
                var list = await context.Users.Include(e => e.UserCertifications).Where(e => e.UserCertifications.Count >= 5).ToListAsync();

                IEnumerable<UserListDto>? userList = new List<UserListDto>();
                Mapping.Mapper.Map(list, userList);

                return userList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
