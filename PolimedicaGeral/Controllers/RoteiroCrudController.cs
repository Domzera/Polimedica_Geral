using Microsoft.AspNetCore.Mvc;
using PolimedicaGeral.DTO;
using PolimedicaGeral.Interface;

namespace PolimedicaGeral.Controllers
{
    //[Route("polimedica/[controller]")]
    [Route("polimedica/crud/roteiro")]
    [ApiController]
    public class RoteiroCrudController : ControllerBase
    {
        private readonly IRoteiro _roteiro;
        public RoteiroCrudController(IRoteiro roteiro)
        {
            _roteiro = roteiro;
        }

        [HttpPost]
        public async Task<IResult> Create(RoteiroDto roteiro)
        {
            Console.WriteLine($"Request received at /polimedica/roteiro - ATENÇÂO");
            IResult novoRoteiro = await _roteiro.Create(roteiro);

            return novoRoteiro;
        }

        [HttpGet("data/{ano:int}/{mes:int}/{dia:int}")]
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

        [HttpGet("teste")]
        public IActionResult Teste()
        {
            return Ok("Funcionando");
        }
    }
}
