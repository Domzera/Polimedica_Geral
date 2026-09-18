using Microsoft.AspNetCore.Mvc;
using PolimedicaGeral.DTO;
using PolimedicaGeral.Interface;

namespace PolimedicaGeral.Controllers
{
    
    [ApiController]
    [Route("polimedica/[controller]")]
    public class RoteiroController : ControllerBase
    {
        private readonly IRoteiro _roteiro;

        public RoteiroController(IRoteiro roteiro)
        {
            _roteiro = roteiro;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Console.WriteLine("Request received at /polimedica");

            var roteiros = await _roteiro.Get();

            if (roteiros == null)
            {
                return NotFound("No roteiros found.");
            }

            return Ok(roteiros);
        }
        [HttpGet("{ano:int}/{mes:int}/{dia:int}")]
        public async Task<IActionResult> GetComData(int ano, int mes, int dia)
        {
            var data = new DateOnly(ano, mes, dia);
            var roteiros = await _roteiro.GetComData(data);
            
            if (roteiros == null)
            {
                return NotFound("No roteiros found for the specified date.");
            }
            
            return Ok(roteiros);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoteiroDto roteiro)
        {
            var novoRoteiro = await _roteiro.Create(roteiro);

            if (novoRoteiro == null)
            {
                return BadRequest("Failed to create roteiro.");
            }

            return Ok($"Roteiro received: {novoRoteiro}");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var roteiro = await _roteiro.Delete(id);

            if (roteiro == null)
            {
                return NotFound("Roteiro not found.");
            }

            return Ok($"Roteiro deleted: {roteiro}");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, RoteiroDto roteiro)
        {
            var updatedRoteiro = await _roteiro.Update(id, roteiro);
            if (updatedRoteiro == null)
            {
                return NotFound("Roteiro not found.");
            }
            return Ok($"Roteiro updated: {updatedRoteiro}");
        }
    }
}
