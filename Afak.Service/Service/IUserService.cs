using Afak.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afak.Service.Service
{
    public interface IUserService
    {
        Task<bool> AddAsync(AddUserDto addUserDto);
        Task<IEnumerable<UserListDto>?> List();
    }
}
