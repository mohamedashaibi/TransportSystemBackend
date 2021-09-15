using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Data;

namespace TransportSystem.IRepository
{
	public interface IUnitOfWork : IDisposable
	{
		//IGenericRepository<Country> CountryRepo { get; }
		//IGenericRepository<Hotel> HotelRepo { get; }

		IGenericRepository<Branch> BranchRepo { get; }
		IGenericRepository<City> CityRepo { get; }
		IGenericRepository<BranchUser> BranchUserRepo { get; }
		IGenericRepository<Company> CompanyRepo { get; }
		IGenericRepository<CompanyProduct> CompanyProductRepo { get; }
		IGenericRepository<CompanyUser> CompanyUser { get; }
		IGenericRepository<DeveloperUser> DeveloperUserRepo { get; }
		IGenericRepository<Invoice> InvoiceRepo { get; }
		IGenericRepository<InvoiceProduct> InvoiceProductRepo { get; }
		IGenericRepository<NormalUser> NormalUserRepo { get; }
		IGenericRepository<ApiUser> UserRepo { get; }

		Task Save();
	}
}
