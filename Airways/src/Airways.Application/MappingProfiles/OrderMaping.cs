using Airways.Application.Models.Order;
using Airways.Core.Entity;
using AutoMapper;

namespace Airways.Application.MappingProfiles
{
    public class OrderMaping:Profile
    {
        public OrderMaping()
        {
            CreateMap<CreateOrderModel, Order>();
            CreateMap<UpdateOrderModel, Order>().ReverseMap();

            CreateMap<Order, OrderResponceModel>();
        }
    }
}
