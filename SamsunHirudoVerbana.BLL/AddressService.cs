using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamsunHirudoVerbana.BLL.EntityService;
using SamsunHirudoVerbana.BLL.Service;
using SamsunHirudoVerbana.Core.CoreRepository;
using SamsunHirudoVerbana.Core.UnitOfWorks;
using SamsunHirudoVerbana.Data;

namespace SamsunHirudoVerbana.Service
{
    public class AddressService : Service<Address>, IAddressService
    {
        public AddressService(IUnitOfWork unitOfWork, IRepository<Address> repository) : base(unitOfWork, repository)
        {

        }
    }
}
