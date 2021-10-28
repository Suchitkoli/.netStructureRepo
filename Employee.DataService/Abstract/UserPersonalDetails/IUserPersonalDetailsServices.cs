using DataService.EntityData.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Abstract.UserPersonalDetails
{
    public interface IUserPersonalDetailsServices
    {
        Task<List<UserPersonalDetail>> GetUsersPersonalDetails();

        Task<bool> CreateUsersPersonalDetails(UserPersonalDetail userPersonalDetails);
    }
}
