using Airways.Application.MediatrCRUD;
using Airways.Application.Models;
using Airways.Core.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePersonCommand command)
        {
            var result = await _mediator.Send(command);

            // Agar failure bo‘lsa, BadRequest qaytarish
            if (result.IsFailure)
            {
                return BadRequest(new { Error = result.Error?.message });
            }

            // Agar success bo‘lsa, Id ni qaytarish
            return Created("", new { Id = result.Value, Message = "Person successfully created" });
        }






        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllPersonsQuery());

            if (result.IsFailure) // ❗ Agar failure bo‘lsa, NotFound qaytaramiz
                return NotFound(new { Error = result.Error?.message });

            return Ok(result.Value); // ✅ Bu joy faqat muvaffaqiyatli natija bo‘lsa ishlaydi
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePersonCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID mismatch.");

            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return BadRequest(new { Error = result.Error?.message });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePersonCommand(id));

            if (result.IsFailure)
                return BadRequest(new { Error = result.Error?.message });

            return NoContent();
        }

    }

}
