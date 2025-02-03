using Airways.Application.Models.Aicraft;
using Airways.Application.Models.Airline;
using Airways.Application.Models.Classs;
using Airways.Application.Models.Order;
using Airways.Application.Models.Payment;
using Airways.Application.Models.PricePolycy;
using Airways.Application.Models.Review;
using Airways.Application.Models.Reys;
using Airways.Application.Models.Ticket;
using Airways.Application.Services;
using Moq;

namespace AirwaysTest
{
    public class UnitTest1
    {
        private readonly Mock<IAirlineService> _airlineService;
        private readonly Mock<IAircraftService> _aicraftService;
        private readonly Mock<IReviewservice> _reviewService;
        private readonly Mock<ITicketService> _ticketService;
        private readonly Mock<IClassService> _classService;
        private readonly Mock<IReysService> _reysService;
        private readonly Mock<IOrderService> _orderService;
        private readonly Mock<IPaymentService> _paymentService;
        private readonly Mock<IPricePolicyService> _pricepolicyService;



        public UnitTest1()
        {
            _airlineService = new Mock<IAirlineService>();
            _aicraftService = new Mock<IAircraftService>();
            _reviewService = new Mock<IReviewservice>();
            _ticketService = new Mock<ITicketService>();
            _classService = new Mock<IClassService>();
            _reysService = new Mock<IReysService>();
            _orderService = new Mock<IOrderService>();
            _paymentService = new Mock<IPaymentService>();
            _pricepolicyService = new Mock<IPricePolicyService>();
        }

        #region Airline
        [Fact]
        public async Task Airline_Delete_Id()
        {
            Guid id = Guid.Parse("d468d3d5-7e3a-490e-98d2-9299d4420ea0");

            _airlineService.Setup(x => x.DeleteAsync(id)).ReturnsAsync(true);

            var service = _airlineService.Object;

            bool result = await service.DeleteAsync(id);

            Assert.True(result);

        }
        [Fact]
        public async Task Airline_GetAll()
        {
            var airlines = new List<AirlineResponceModel>
        {
            new AirlineResponceModel { Id = Guid.NewGuid(), Name = "Airline 1" },
            new AirlineResponceModel { Id = Guid.NewGuid(), Name = "Airline 2" }
        };

            _airlineService.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(airlines);

            var service = _airlineService.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(airlines.Count, result.Count);
        }

        [Fact]
        public async Task Airline_Create()
        {
            var createModel = new CreateAirlineModel { Name = "New Airline" };
            var responseModel = new CreateAirlineResponceModel { Id = Guid.NewGuid() };

            _airlineService.Setup(x => x.CreateAsync(createModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _airlineService.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Airline_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdateAirlineModel { Name = "Updated Airline" };
            var responseModel = new UpdateAirlineResponceModel { Id = id };

            _airlineService.Setup(x => x.UpdateAsync(id, updateModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _airlineService.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        #endregion
        #region Aircraft
        [Fact]
        public async Task Aircraft_Delete_Id()
        {
            Guid id = Guid.Parse("d468d3d5-7e3a-490e-98d2-9299d4420ea0");

            _aicraftService.Setup(x => x.DeleteAsync(id)).ReturnsAsync(true);

            var service = _aicraftService.Object;

            bool result = await service.DeleteAsync(id);

            Assert.True(result);

        }
        [Fact]
        public async Task Aircraft_GetAll()
        {
            var airlines = new List<AicraftResponceModel>
        {
            new AicraftResponceModel { Id = Guid.NewGuid(), Name = "Aircraft 1" },
            new AicraftResponceModel { Id = Guid.NewGuid(), Name = "Aircraft 2" }
        };

            _aicraftService.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(airlines);

            var service = _aicraftService.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(airlines.Count, result.Count);
        }

        [Fact]
        public async Task Aircraft_Create()
        {
            var createModel = new CreateAircraftModel { Name = "New Aircraft" };
            var responseModel = new CreateAicraftResponceModel { Id = Guid.NewGuid() };

            _aicraftService.Setup(x => x.CreateAsync(createModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _aicraftService.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Aircraft_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdateAicraftModel { Name = "Updated Aircraft" };
            var responseModel = new UpdateAicraftResponceModel { Id = id };

            _aicraftService.Setup(x => x.UpdateAsync(id, updateModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _aicraftService.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);

        }
        #endregion
        #region Review
        [Fact]
        public async Task Review_Delete_Id()
        {
            Guid id = Guid.Parse("d468d3d5-7e3a-490e-98d2-9299d4420ea0");

            _reviewService.Setup(x => x.DeleteAsync(id)).ReturnsAsync(true);

            var service = _reviewService.Object;

            bool result = await service.DeleteAsync(id);

            Assert.True(result);

        }
        [Fact]
        public async Task Review_GetAll()
        {
            var airlines = new List<ReviewResponceModel>
        {
            new ReviewResponceModel { Id = Guid.NewGuid() }

        };

            _reviewService.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(airlines);

            var service = _reviewService.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(airlines.Count, result.Count);
        }

        [Fact]
        public async Task Review_Create()
        {
            Guid id = Guid.Parse("d468d3d5-7e3a-490e-98d2-9299d4420ea0");
            var createModel = new CreateReviewModel { Comment = "New Review", Rating = 2, ReysId = id, UserId = id };
            var responseModel = new CreateReviewResponceModel { Id = Guid.NewGuid() };

            _reviewService.Setup(x => x.CreateAsync(createModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _reviewService.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Review_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdateReviewModel { Comment = "Updated Review" };
            var responseModel = new UpdateReviewResponceModel { Id = id };

            _reviewService.Setup(x => x.UpdateAsync(id, updateModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _reviewService.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);

        }
        #endregion
        #region Ticket
        [Fact]
        public async Task Ticket_Delete_Id()
        {
            Guid id = Guid.Parse("d468d3d5-7e3a-490e-98d2-9299d4420ea0");

            _ticketService.Setup(x => x.DeleteAsync(id)).ReturnsAsync(true);

            var service = _ticketService.Object;

            bool result = await service.DeleteAsync(id);

            Assert.True(result);

        }
        [Fact]
        public async Task Ticket_GetAll()
        {
            var airlines = new List<TicketResponceModel>
        {
            new TicketResponceModel { Id = Guid.NewGuid(), DepartureCity="Andijon",ScheduledDepartureTime=DateTime.Today,ArrivalCity="Tashkent",SeatNumber="2A" },
            new TicketResponceModel { Id = Guid.NewGuid(),DepartureCity="Uzbekistan",ScheduledDepartureTime=DateTime.Today,ArrivalCity="Dubay",SeatNumber="5A" }
        };

            _ticketService.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(airlines);

            var service = _ticketService.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(airlines.Count, result.Count);
        }

        [Fact]
        public async Task Ticket_Create()
        {
            var createModel = new CreateTicketsModel { DepartureCity = "Andijon", ScheduledDepartureTime = DateTime.Today, ArrivalCity = "Tashkent", SeatNumber = "2A" };
            var responseModel = new CreateTicketResponceModel { Id = Guid.NewGuid() };

            _ticketService.Setup(x => x.CreateAsync(createModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _ticketService.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Ticket_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdateTicketModel { DepartureCity = "Andijon", ScheduledDepartureTime = DateTime.Today, ArrivalCity = "Tashkent", SeatNumber = "2A" };
            var responseModel = new UpdateTicketResponceModel { Id = id };

            _ticketService.Setup(x => x.UpdateAsync(id, updateModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _ticketService.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }
        #endregion
        #region Class
        [Fact]
        public async Task Class_Delete_Id()
        {
            Guid id = Guid.Parse("d468d3d5-7e3a-490e-98d2-9299d4420ea0");

            _classService.Setup(x => x.DeleteAsync(id)).ReturnsAsync(true);

            var service = _classService.Object;

            bool result = await service.DeleteAsync(id);

            Assert.True(result);

        }
        [Fact]
        public async Task Class_GetAll()
        {
            var airlines = new List<ClassResponceModel>
        {
          new ClassResponceModel { Id = Guid.NewGuid(),description="Norm"},
          new ClassResponceModel { Id = Guid.NewGuid(),description="False"  }
        };

            _classService.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(airlines);

            var service = _classService.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(airlines.Count, result.Count);
        }

        [Fact]
        public async Task Class_Create()
        {
            var createModel = new CreateCLassModel { description = "Norm" };
            var responseModel = new CreateClassResponceModel { Id = Guid.NewGuid() };

            _classService.Setup(x => x.CreateAsync(createModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _classService.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Class_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdateClassModel { description = "Norm" };
            var responseModel = new UpdateClassResponceModel { Id = id };

            _classService.Setup(x => x.UpdateAsync(id, updateModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _classService.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }
        #endregion
        #region Reys
        [Fact]
        public async Task Reys_Delete_Id()
        {
            Guid id = Guid.Parse("d468d3d5-7e3a-490e-98d2-9299d4420ea0");

            _reysService.Setup(x => x.DeleteAsync(id)).ReturnsAsync(true);

            var service = _reysService.Object;

            bool result = await service.DeleteAsync(id);

            Assert.True(result);

        }
        [Fact]
        public async Task Reys_GetAll()
        {
            var airlines = new List<ReysResponceModel>
        {
          new ReysResponceModel { Id = Guid.NewGuid(),DepartureCity="uzbek",ArrivalCity="Makka",TicketCount=1000,ActualDepartureTime=DateTime.Today},
          new ReysResponceModel { Id = Guid.NewGuid(),DepartureCity="uzbek",ArrivalCity="Madina",TicketCount=1000,ActualDepartureTime=DateTime.Today }
        };

            _reysService.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(airlines);

            var service = _reysService.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(airlines.Count, result.Count);
        }

        [Fact]
        public async Task Reys_Create()
        {
            var createModel = new CreateReysModel { DepartureCity = "uzbek", ArrivalCity = "Makka", ActualDepartureTime = DateTime.Today };
            var responseModel = new CreateReysResponceModel { Id = Guid.NewGuid() };

            _reysService.Setup(x => x.CreateAsync(createModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _reysService.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Reys_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdateReysModel { DepartureCity = "uzbek", ArrivalCity = "Makka", TicketCount = 1000, ActualDepartureTime = DateTime.Today };
            var responseModel = new UpdateReysResponceModel { Id = id };

            _reysService.Setup(x => x.UpdateAsync(id, updateModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _reysService.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }
        #endregion
        #region Order
        [Fact]
        public async Task Order_Delete_Id()
        {
            Guid id = Guid.Parse("d468d3d5-7e3a-490e-98d2-9299d4420ea0");

            _orderService.Setup(x => x.DeleteAsync(id)).ReturnsAsync(true);

            var service = _orderService.Object;

            bool result = await service.DeleteAsync(id);

            Assert.True(result);

        }
        [Fact]
        public async Task Order_GetAll()
        {
            var airlines = new List<OrderResponceModel>
        {
          new OrderResponceModel { Id = Guid.NewGuid(),TotalPrice=200},
          new OrderResponceModel { Id = Guid.NewGuid(),TotalPrice=200 }
        };

            _orderService.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(airlines);

            var service = _orderService.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(airlines.Count, result.Count);
        }

        [Fact]
        public async Task Order_Create()
        {
            var createModel = new CreateOrderModel { TotalPrice = 200 };
            var responseModel = new CreateOrderResponceModel { Id = Guid.NewGuid() };

            _orderService.Setup(x => x.CreateAsync(createModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _orderService.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Order_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdateOrderModel { TotalPrice = 200 };
            var responseModel = new UpdateOrderResponceModel { Id = id };

            _orderService.Setup(x => x.UpdateAsync(id, updateModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _orderService.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }
        #endregion
        #region Payment
        [Fact]
        public async Task Payment_Delete_Id()
        {
            Guid id = Guid.Parse("d468d3d5-7e3a-490e-98d2-9299d4420ea0");

            _paymentService.Setup(x => x.DeleteAsync(id)).ReturnsAsync(true);

            var service = _paymentService.Object;

            bool result = await service.DeleteAsync(id);

            Assert.True(result);

        }
        [Fact]
        public async Task Payment_GetAll()
        {
            var airlines = new List<PaymentResponceModel>
        {
          new PaymentResponceModel { Id = Guid.NewGuid(),Amount=222},
          new PaymentResponceModel { Id = Guid.NewGuid(),Amount=422 }
        };

            _paymentService.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(airlines);

            var service = _paymentService.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(airlines.Count, result.Count);
        }

        [Fact]
        public async Task Payment_Create()
        {
            var createModel = new CreatePaymentModel { Amount = 222 };
            var responseModel = new CreatePaymentResponceModel { Id = Guid.NewGuid() };

            _paymentService.Setup(x => x.CreateAsync(createModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _paymentService.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Payment_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdatePaymentModel { Amount = 222 };
            var responseModel = new UpdatePaymentResponceModel { Id = id };

            _paymentService.Setup(x => x.UpdateAsync(id, updateModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _paymentService.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }
        #endregion
        #region Pricepolicy
        [Fact]
        public async Task Pricepolicy_Delete_Id()
        {
            Guid id = Guid.Parse("d468d3d5-7e3a-490e-98d2-9299d4420ea0");

            _pricepolicyService.Setup(x => x.DeleteAsync(id)).ReturnsAsync(true);

            var service = _pricepolicyService.Object;

            bool result = await service.DeleteAsync(id);

            Assert.True(result);

        }
        [Fact]
        public async Task Pricepolicy_GetAll()
        {
            var airlines = new List<PricePolicyResponceModel>
        {
          new PricePolicyResponceModel { Id = Guid.NewGuid(),DiscountPercentage=500,Conditions="All"},
          new PricePolicyResponceModel { Id = Guid.NewGuid(),DiscountPercentage=700,Conditions="All" }
        };

            _pricepolicyService.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(airlines);

            var service = _pricepolicyService.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(airlines.Count, result.Count);
        }

        [Fact]
        public async Task Pricepolicy_Create()
        {
            var createModel = new CreatePricePolicyModel { DiscountPercentage = 500, Conditions = "All" };
            var responseModel = new CreatePricePolicyResponceModel { Id = Guid.NewGuid() };

            _pricepolicyService.Setup(x => x.CreateAsync(createModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _pricepolicyService.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Pricepolicy_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdatePricePolicyModel { DiscountPercentage = 500, Conditions = "All" };
            var responseModel = new UpdatePricePolicyResponceModel { Id = id };

            _pricepolicyService.Setup(x => x.UpdateAsync(id, updateModel, It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _pricepolicyService.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }
        #endregion

    }
}