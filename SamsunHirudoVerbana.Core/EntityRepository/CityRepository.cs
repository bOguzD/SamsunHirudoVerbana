using SamsunHirudoVerbana.Core.CoreRepository;
using SamsunHirudoVerbana.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsunHirudoVerbana.Core.EntityRepository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private SamsunHirudoVerbanaContext SamsunHirudoVerbanaContext { get => _context as SamsunHirudoVerbanaContext; }
        public CityRepository(SamsunHirudoVerbanaContext context) : base(context)
        {

        }
    }
}
