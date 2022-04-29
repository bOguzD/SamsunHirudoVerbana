using SamsunHirudoVerbana.Core.CoreRepository;
using SamsunHirudoVerbana.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsunHirudoVerbana.Core.EntityRepository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private SamsunHirudoVerbanaContext SamsunHirudoVerbanaContext { get => _context as SamsunHirudoVerbanaContext; }

        public AddressRepository(SamsunHirudoVerbanaContext context) : base(context)
        {
        }

    }
}
