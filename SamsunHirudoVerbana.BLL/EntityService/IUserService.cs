﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamsunHirudoVerbana.BLL.DTOs;
using SamsunHirudoVerbana.BLL.Service;
using SamsunHirudoVerbana.Core.Helpers.JWT;
using SamsunHirudoVerbana.Data;

namespace SamsunHirudoVerbana.BLL.EntityService
{
    public interface IUserService: IService<User>
    {
        Task<AccessToken> Authenticate(LoginDTO loginDTO);
    }
}