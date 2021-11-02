using DataService.Abstract.UserPersonalDetails;
using DataService.EntityData.EntityModels;
using Employee.Manager.Models;
using Employee.Manager.Models.DTO;
using Employee.Manager.Models.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Manager.Managers.UserPersonalDetails
{
   
    public class UserPersonalDetailsManager
    {
        private readonly IUserPersonalDetailsServices _userPersonalDetailsServices;
        public UserPersonalDetailsManager(IUserPersonalDetailsServices userPersonalDetailsServices )
        {
            _userPersonalDetailsServices = userPersonalDetailsServices;
        }

        public async Task<UserPersonalDetailsDTO> GetUserPersonalDetailsById(long id)
        {
            var res = await _userPersonalDetailsServices.GetUserPersonalDetailsById(id);
            return UserPersonalDetailsDTO.MapToDTO(res);
        }

        public async Task<bool> DeleteUserPersonalDetails(long id)
        {
            var res = await _userPersonalDetailsServices.DeleteUserPersonalDetails(id);
            return res;
        }


            public async Task<UserPersonalDetailsDTO> CreateUsersPersonalDetails(UserPersonalDetailsDTO userPersonalDetailsDTO)
        {
            var isNew = userPersonalDetailsDTO.Id == 0;
            //return await _userPersonalDetailsServices.CreateUsersPersonalDetails(UserPersonalDetailsDTO.MapToEntity(userPersonalDetailsDTO));
            var Details = new UserPersonalDetail();

            if (!isNew)
            {
                Details = await _userPersonalDetailsServices.GetUserPersonalDetailsById(userPersonalDetailsDTO.Id);
            }

            Details.UserId = userPersonalDetailsDTO.UserId;
            Details.Fname = userPersonalDetailsDTO.Fname;
            Details.Mname = userPersonalDetailsDTO.Mname;
            Details.Lname = userPersonalDetailsDTO.Lname;
            Details.Dob = userPersonalDetailsDTO.Dob;

            if (isNew)
            {
                await _userPersonalDetailsServices.CreateUsersPersonalDetails(Details);
            }
            else
            {
                await _userPersonalDetailsServices.UpdateUserPersonalDetailsAsync(Details);
            }

         

            return UserPersonalDetailsDTO.MapToDTO(Details);
        }
        public async Task<List<UserPersonalDetailsDTO>> GetUsersPersonalDetails()
        {
            var res = await _userPersonalDetailsServices.GetUsersPersonalDetails();
            var response = res
                .Select(x => UserPersonalDetailsDTO.MapToDTO(x))
                .ToList();
            return response;
        }
    }
}
