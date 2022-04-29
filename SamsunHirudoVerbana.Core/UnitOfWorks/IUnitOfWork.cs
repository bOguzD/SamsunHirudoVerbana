using SamsunHirudoVerbana.Core.EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsunHirudoVerbana.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IAddressRepository Address { get; }
        ICityRepository City { get; }
        ICountryRepository Country { get; }
        ICountyRepository County { get; }
        IProductRepository Product { get; }
        IUserRepository User { get; }
        ICurrencyRepository Currency { get; }
        IPictureRepository Picture { get; }
        IPriceRepository Price { get; }
        IInventoryRepository Inventory { get; }

        Task CommitAsync();
        void Commit();
    }
}
