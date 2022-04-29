﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamsunHirudoVerbana.Core.CoreRepository;
using SamsunHirudoVerbana.Data;

namespace SamsunHirudoVerbana.Core.EntityRepository
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        private SamsunHirudoVerbanaContext SamsunHirudoVerbanaContext { get => _context as SamsunHirudoVerbanaContext; }

        public UserRepository(SamsunHirudoVerbanaContext context) : base(context)
        {
        }
    }
}