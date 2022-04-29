using SamsunHirudoVerbana.Core.EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsunHirudoVerbana.Core.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SamsunHirudoVerbanaContext _context;
        private AddressRepository? _addressRepository;
        private CityRepository? _cityRepository;
        private CountryRepository? _countryRepository;
        private CountyRepository? _countyRepository;
        private ProductRepository? _productRepository;
        private UserRepository? _userRepository;
        private CurrencyRepository? _currencyRepository;
        private PictureRepository? _pictureRepository;
        private PriceRepository? _priceRepository;
        private InventoryRepository? _inventoryRepository;

        public UnitOfWork(SamsunHirudoVerbanaContext context)
        {
            _context = context;
        }

        public IAddressRepository Address => _addressRepository = _addressRepository ?? new AddressRepository(_context);
        public ICityRepository City => _cityRepository = _cityRepository ?? new CityRepository(_context);
        public ICountryRepository Country => _countryRepository = _countryRepository ?? new CountryRepository(_context);
        public ICountyRepository County => _countyRepository = _countyRepository ?? new CountyRepository(_context);
        public IProductRepository Product => _productRepository = _productRepository ?? new ProductRepository(_context);
        public IUserRepository User => _userRepository = _userRepository ?? new UserRepository(_context);
        public ICurrencyRepository Currency => _currencyRepository = _currencyRepository ?? new CurrencyRepository(_context);
        public IPictureRepository Picture => _pictureRepository = _pictureRepository ?? new PictureRepository(_context);
        public IPriceRepository Price => _priceRepository = _priceRepository ?? new PriceRepository(_context);
        public IInventoryRepository Inventory => _inventoryRepository = _inventoryRepository ?? new InventoryRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
