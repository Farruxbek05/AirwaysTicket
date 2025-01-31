using Airways.Application.DTO;
using Airways.Application.Models;
using Airways.Application.Models.Ticket;
using Airways.Application.Services;
using Airways.Application.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class TicketContoller : ApiController
    {
        private readonly ITicketService _ticketService;
        private readonly IPaymentService paymentService;

        public TicketContoller(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult<List<TicketResponceModel>>>> GetAll()
        {
            var result = await _ticketService.GetAllAsync();
            var response = ApiResult<List<TicketResponceModel>>.Success(result);
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateTicketsModel createUserModel)
        {
            var result = await _ticketService.CreateAsync(createUserModel);
            return Ok(ApiResult<CreateTicketResponceModel>.Success(result));

        }



        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateTicketModel updateUserModel)
        {
            return Ok(ApiResult<UpdateTicketResponceModel>.Success(
                await _ticketService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<bool>.Success(await _ticketService.DeleteAsync(id)));
        }
        [HttpGet("{ticketId}/GenerateTicketImage")]
        public async Task<IActionResult> GenerateTicketImage(Guid ticketId)
        {
            try
            {
                // Servisdan metodni chaqirish
                var ticketImage = await _ticketService.GenerateTicketImageAsync(ticketId);

                // Tasvirni rasm sifatida foydalanuvchiga yuborish
                return File(ticketImage, "image/png");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
