using Airways.Application.Models;
using Airways.Application.Models.Ticket;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;
using SkiaSharp;

namespace Airways.Application.Services.Impl
{
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;


        public TicketService(ITicketRepository ticketRepository,
            IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<List<TicketResponceModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _ticketRepository.GetAllAsync();

            var mapper = _mapper.Map<List<TicketResponceModel>>(result);
            return mapper;
        }

        public async Task<CreateTicketResponceModel> CreateAsync(CreateTicketsModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Tickets>(createTodoItemModel);
            var res = await _ticketRepository.AddAsync(todoItem);
            return new CreateTicketResponceModel
            {
                Id = res.Id
            };
        }

        public async Task<UpdateTicketResponceModel> UpdateAsync(Guid id, UpdateTicketModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _ticketRepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateTicketResponceModel
            {
                Id = (await _ticketRepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _ticketRepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _ticketRepository.DeleteAsync(todoItem)).Id
            };
        }

        [Obsolete]
        public async Task<byte[]> GenerateTicketImageAsync(Guid ticketId)
        {
            // Ticketni olish
            var ticket = await GetTicketByIdAsync(ticketId);
            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }

            // QR kod va tasvir yaratish
            string qrCodeText = $"https://yourdomain.com/tickets/{ticketId}";

            // Tasvirni generatsiya qilish
            return await GenerateTicketImage(ticket.PassengerName, ticket.DepartureCity, ticket.ArrivalCity, ticket.ScheduledDepartureTime, ticket.SeatNumber);
        }

        // Ticketni ID orqali olish
        public async Task<Tickets> GetTicketByIdAsync(Guid ticketId)
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(ticketId);
            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }
            return ticket;

        }

        // Tasvirni generatsiya qilish (avvalgi metodni shu yerda saqlaysiz)
        [Obsolete]
        public async Task<byte[]> GenerateTicketImage(string passengerName, string departureCity, string arrivalCity, DateTime scheduledDepartureTime, string seatNumber)
        {
            int width = 800, height = 600;

            using var bitmap = new SKBitmap(width, height);
            using var canvas = new SKCanvas(bitmap);

            var backgroundPaint = new SKPaint
            {
                Shader = SKShader.CreateLinearGradient(
                    new SKPoint(0, 0),
                new SKPoint(width, height),
                    new SKColor[] { SKColors.LightBlue, SKColors.White },
                    new float[] { 0, 1 },
                    SKShaderTileMode.Clamp)
            };
            canvas.DrawRect(0, 0, width, height, backgroundPaint);

            var borderPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.DarkBlue,
                StrokeWidth = 8
            };
            canvas.DrawRect(20, 20, width - 40, height - 40, borderPaint);

            var titlePaint = new SKPaint
            {
                Color = SKColors.Black,
                TextSize = 40,
                IsAntialias = true,
                TextAlign = SKTextAlign.Center
            };

            var bodyPaint = new SKPaint
            {
                Color = SKColors.Black,
                TextSize = 28,
                IsAntialias = true,
                TextAlign = SKTextAlign.Center
            };

            var footerPaint = new SKPaint
            {
                Color = SKColors.Black,
                TextSize = 20,
                IsAntialias = true,
                TextAlign = SKTextAlign.Left
            };

            canvas.DrawText($"Ticket for {passengerName}", width / 2, 100, titlePaint);
            canvas.DrawText($"From: {departureCity} To: {arrivalCity}", width / 2, 180, bodyPaint);
            canvas.DrawText($"Departure: {scheduledDepartureTime:dd MMM yyyy HH:mm}", width / 2, 220, bodyPaint);
            canvas.DrawText($"Seat: {seatNumber}", width / 2, 260, bodyPaint);



            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            canvas.DrawText($"Date: {currentDate}", 100, height - 100, footerPaint);

            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            return data.ToArray();
        }

    }
}
