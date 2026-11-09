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
            Console.WriteLine($"Roteiros retrieved: {roteiros} items");
            return Ok(roteiros);
        }

        [HttpGet("{ano:int}/{mes:int}/{dia:int}")]
        public async Task<IActionResult> GetComData(int ano, int mes, int dia)
        {
            var data = new DateOnly(ano, mes, dia);
            Console.WriteLine($"Request received at /polimedica with date: {data}");
            var roteiros = await _roteiro.GetComData(data);
            
            if (roteiros == null)
            {
                return NotFound("No roteiros found for the specified date.");
            }
            Console.WriteLine($"Roteiros retrieved for {data}: {roteiros} items");
            return Ok(roteiros);
        }

        [HttpPost]
        public async Task<IResult> Create(RoteiroDto roteiro)
        {
            Console.WriteLine($"Request received at /polimedica with data: {roteiro}");
            IResult novoRoteiro = await _roteiro.Create(roteiro);

            return novoRoteiro;
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine($"Request received at /polimedica to delete roteiro with id: {id}");
            var roteiro = await _roteiro.Delete(id);

            if (roteiro == null)
            {
                return NotFound("Roteiro not found.");
            }
            Console.WriteLine($"Roteiro deleted: {roteiro}");
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
            Console.WriteLine($"Roteiro updated: {updatedRoteiro}");
            return Ok($"Roteiro updated: {updatedRoteiro}");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var roteiro = await _roteiro.GetById(id);
            Console.WriteLine($"Request received at /polimedica to get roteiro with id: {id}");
            if (roteiro == null)
            {
                return NotFound("Roteiro not found.");
            }
            Console.WriteLine($"Roteiro retrieved: {roteiro}");
            return Ok(roteiro);
        }
    }
}
