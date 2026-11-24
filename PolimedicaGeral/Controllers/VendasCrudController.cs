using Microsoft.AspNetCore.Mvc;
using PolimedicaGeral.DTO;
using PolimedicaGeral.Interface;

namespace PolimedicaGeral.Controllers
{
    [Route("polimedica/crud/vendas")]
    [ApiController]
    public class VendasCrudController : Controller
    {
        private readonly IVendas _ivendas;

        public VendasCrudController(IVendas ivendas)
        {
            _ivendas = ivendas;
        }

        [HttpPost]
        public async Task<IResult> Create(VendasDto venda)
        {
            Console.WriteLine("request received at /polimedica/crud/vendas.");

            IResult novaVenda = await _ivendas.Create(venda);

            return novaVenda;
        }

        [HttpGet("{month:int}")]
        public async Task<IResult> GetByMonth(int month)
        {
            Console.WriteLine("Request received at /polimedica/crud/vendas/getByMonth.");

            IResult actualMonth = await _ivendas.GetByMonth(month);

            return actualMonth;
        }

        [HttpPut("{id:int}")]
        public async Task<IResult> Update(int id, VendasDto venda)
        {
            Console.WriteLine("Request received at /polimedica/crud/vendas/update.");

            IResult updateVenda = await _ivendas.Update(id, venda);

            return updateVenda;
        }
    }
}
