using Airways.Application.Models.Payment;
using Airways.Core.Entity;
using AutoMapper;

namespace Airways.Application.MappingProfiles
{
    public class PaymentMaping:Profile
    {
        public PaymentMaping()
        {
            CreateMap<CreatePaymentModel, Payment>();

            CreateMap<UpdatePaymentModel, Payment>().ReverseMap();

            CreateMap<Payment, PaymentResponceModel>();
        }
    }
}
