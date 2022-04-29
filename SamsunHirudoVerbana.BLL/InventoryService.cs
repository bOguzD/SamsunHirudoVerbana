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

namespace SamsunHirudoVerbana.BLL
{
    public class InventoryService : Service<Inventory>, IInventoryService
    {
        public InventoryService(IUnitOfWork unitOfWork, IRepository<Inventory> repository) : base(unitOfWork, repository)
        {

        }
    }
}
