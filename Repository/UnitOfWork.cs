using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Data;
using TransportSystem.IRepository;

namespace TransportSystem.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DatabaseContext _context;
		//private IGenericRepository<Country> _countries;
		//private IGenericRepository<Hotel> _hotels;
		private IGenericRepository<Branch> _branches;
		private IGenericRepository<BranchUser> _branchUsers;
		private IGenericRepository<Company> _companies;
		private IGenericRepository<CompanyProduct> _companyProducts;
		private IGenericRepository<CompanyUser> _companyUsers;
		private IGenericRepository<DeveloperUser> _developerUsers;
		private IGenericRepository<Invoice> _invoices;
		private IGenericRepository<InvoiceProduct> _invoiceProducts;
		private IGenericRepository<NormalUser> _normalUsers;
		private IGenericRepository<City> _cities;
		private IGenericRepository<ApiUser> _users;

		public UnitOfWork(DatabaseContext context)
		{
			_context = context;
		}

		public IGenericRepository<City> CityRepo => _cities ??= new GenericRepository<City>(_context);

		public IGenericRepository<Branch> BranchRepo => _branches ??= new GenericRepository<Branch>(_context);

		public IGenericRepository<BranchUser> BranchUserRepo => _branchUsers ??= new GenericRepository<BranchUser>(_context);

		public IGenericRepository<Company> CompanyRepo => _companies ??= new GenericRepository<Company>(_context);

		public IGenericRepository<CompanyProduct> CompanyProductRepo => _companyProducts ??= new GenericRepository<CompanyProduct>(_context);

		public IGenericRepository<CompanyUser> CompanyUser => _companyUsers ??= new GenericRepository<CompanyUser>(_context);

		public IGenericRepository<DeveloperUser> DeveloperUserRepo => _developerUsers ??= new GenericRepository<DeveloperUser>(_context);

		public IGenericRepository<Invoice> InvoiceRepo => _invoices ??= new GenericRepository<Invoice>(_context);

		public IGenericRepository<InvoiceProduct> InvoiceProductRepo => _invoiceProducts ??= new GenericRepository<InvoiceProduct>(_context);

		public IGenericRepository<NormalUser> NormalUserRepo => _normalUsers ??= new GenericRepository<NormalUser>(_context);
		public IGenericRepository<ApiUser> UserRepo => _users ??= new GenericRepository<ApiUser>(_context);

		//public IGenericRepository<Country> CountryRepo => _countries ??= new GenericRepository<Country>(_context);

		//public IGenericRepository<Hotel> HotelRepo => _hotels ??= new GenericRepository<Hotel>(_context);

		public void Dispose()
		{
			_context.Dispose();
			GC.SuppressFinalize(this);
		}


		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}
	}
}
