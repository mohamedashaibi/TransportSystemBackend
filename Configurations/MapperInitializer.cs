using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TransportSystem.Data;
using TransportSystem.Models;

namespace TransportSystem.Configurations
{
	public class MapperInitializer : Profile
	{
		public MapperInitializer()
		{

			//Branch Mapping
			CreateMap<Branch, BranchDTO>().ReverseMap();
			CreateMap<Branch, UpdateBranchDTO>().ReverseMap();
			CreateMap<Branch, CreateBranchDTO>().ReverseMap();

			//City Mapping
			CreateMap<City, CityDTO>().ReverseMap();
			CreateMap<City, CreateCityDTO>().ReverseMap();

			//Company Mapping
			CreateMap<Company, CompanyDTO>().ReverseMap();
			CreateMap<Company, CreateCompanyDTO>().ReverseMap();
			CreateMap<Company, UpdateCompanyDTO>().ReverseMap();

			//CompanyProuct Mapping
			CreateMap<CompanyProduct, CompanyProductDTO>().ReverseMap();
			CreateMap<CompanyProduct, CreateCompanyProductDTO>().ReverseMap();

			//Invoice Mapping
			CreateMap<Invoice, CreateInvoiceDTO>().ReverseMap();
			CreateMap<Invoice, UpdateInvoiceDTO>().ReverseMap();
			CreateMap<Invoice, InvoiceDTO>().ReverseMap();

			//InvoiceProduct Mapping
			CreateMap<InvoiceProduct, InvoiceProductDTO>().ReverseMap();
			CreateMap<InvoiceProduct, CreateInvoiceProductDTO>().ReverseMap();
			CreateMap<InvoiceProduct, UpdateInvoiceProductDTO>().ReverseMap();

			//User Mapping
			CreateMap<ApiUser, UserDTO>().ReverseMap();
			CreateMap<ApiUser, UserLoginDTO>().ReverseMap();
			CreateMap<ApiUser, UserSignupDTO>().ReverseMap();
			CreateMap<ApiUser, GetUserDTO>().ReverseMap();

		}
	}
}
