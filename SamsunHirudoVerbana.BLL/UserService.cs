using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamsunHirudoVerbana.BLL.DTOs;
using SamsunHirudoVerbana.BLL.EntityService;
using SamsunHirudoVerbana.BLL.Service;
using SamsunHirudoVerbana.Core.CoreRepository;
using SamsunHirudoVerbana.Core.Helpers.JWT;
using SamsunHirudoVerbana.Core.UnitOfWorks;
using SamsunHirudoVerbana.Data;

namespace SamsunHirudoVerbana.BLL
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository) : base(unitOfWork, repository)
        {
            //public async Task<AccessToken> Authenticate(LoginDTO loginDTO)
            //{
            //    var user = await unitOfWork.User.Where(x=>x.Email == loginDTO.Email && x.Password == loginDTO.Password);

            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var key = Encoding.ASCII.GetBytes();
            //}
        }

        public Task<AccessToken> Authenticate(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

    }
}
