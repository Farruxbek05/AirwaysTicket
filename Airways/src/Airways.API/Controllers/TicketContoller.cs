using Airways.Application.Models;
using Airways.Application.Models.Ticket;
using Airways.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class TicketContoller : ApiController
    {
        private readonly ITicketService _ticketService;

        public TicketContoller(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateTicketsModel createUserModel)
        {
            return Ok(ApiResult<CreateTicketResponceModel>.Success(
                await _ticketService.CreateAsync(createUserModel)));
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
            return Ok(ApiResult<BaseResponceModel>.Success(await _ticketService.DeleteAsync(id)));
        }
    }
}
