using AutoMapper;
using OrderManagment.Dto;
using OrderManagment.Models;

namespace OrderManagment.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Orders
            CreateMap<Order, ViewOrder>();
            CreateMap<AddOrder, Order>();
            //Products
            CreateMap<AddProduct, Product>();
            CreateMap<Product, ViewProduct>();
            CreateMap<ViewProduct, Product>();
            //OrderedProducts
            CreateMap<ViewOrderProducts, OrderProducts>();
            CreateMap<OrderProducts, ViewOrderProducts>();
            CreateMap<AddOrderProduct, OrderProducts>();
            //Contractors
            CreateMap<Contractor, ViewContractor>();
            CreateMap<ViewContractor, Contractor>();
            CreateMap<AddContractor, Contractor>();
            CreateMap<Contractor, ContractorWithStats>();
        }
    }
}
