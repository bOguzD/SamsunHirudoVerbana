using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamsunHirudoVerbana.Core.CoreRepository;
using SamsunHirudoVerbana.Data;

namespace SamsunHirudoVerbana.Core.EntityRepository
{
    public class PriceRepository : Repository<Price>, IPriceRepository
    {
        private SamsunHirudoVerbanaContext SamsunHirudoVerbanaContext { get => _context as SamsunHirudoVerbanaContext; }
        public PriceRepository(SamsunHirudoVerbanaContext context) : base(context)
        {

        }

    }
}
