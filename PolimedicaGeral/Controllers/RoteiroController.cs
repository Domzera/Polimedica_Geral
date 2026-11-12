using Microsoft.AspNetCore.Mvc;
using PolimedicaGeral.Interface;

namespace PolimedicaGeral.Controllers
{
    
    [ApiController]
    //[Route("polimedica/[controller]")]
    [Route("polimedica/roteiro")]
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

        [HttpGet("pedido/{pedido}")]
        public async Task<IActionResult> GetByPedido(string pedido)
        {
            var pedidos =  await _roteiro.GetByPedido(pedido);
            Console.WriteLine($"Request received for : {pedido}");
            if(pedidos == null)
            {
                return NotFound("Pedido not found.");
            }
            return Ok(pedidos);
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var names = await _roteiro.GetByName(name);
            if (names == null)
            {
                return NotFound("Cliente not found.");
            }
            return Ok(names);
        }
    }
}
