using Microsoft.EntityFrameworkCore;
using PolimedicaGeral.Data;
using PolimedicaGeral.DTO;
using PolimedicaGeral.Interface;
using PolimedicaGeral.Models;
using PolimedicaGeral.Service;

namespace PolimedicaGeral.Repository
{
    public class VendasRepository : IVendas
    {
        private readonly PolimedicaGeralDBContext _context;
        private readonly ChecaUpdate _checa;

        public VendasRepository(PolimedicaGeralDBContext context, ChecaUpdate checa)
        {
            _context = context;
            _checa = checa;
        }

        public async Task<IResult> Create(VendasDto vendas)
        {

            if (vendas.Data == null || vendas.Data == default)
            {
                vendas.Data = DateOnly.FromDateTime(DateTime.Now);
            }
            {
                var novaVenda = new Vendas
                {
                    UserId = vendas.UserId,
                    UserType = vendas.UserType,
                    Data = vendas.Data,
                    Conta = vendas.Conta,
                    Valor = vendas.Valor,
                    QuantAtend = vendas.QuantAtend
                };
                await _context.Vendas.AddAsync(novaVenda);
            }

            var result = await _context.SaveChangesAsync();

            return result > 0 ?
                Results.Ok(new { Sucesso = true, mensagem = "Adicionado com sucesso." }) :
                Results.Problem(detail: "Erro ao adicionar", statusCode: 400);
        }

        public async Task<IResult> Update(int id, VendasDto vendaAtual)
        {
            var vendaVelha = await _context.Vendas.FirstOrDefaultAsync(v => v.Id == id);

            if (vendaVelha == null)
            {
                return Results.Problem(detail: "Mês nãoencontrado.", statusCode: 400);
            }
            else
            {
                vendaVelha.UserId = _checa.ChecaUpdateInteger(vendaVelha.UserId, vendaAtual.UserId);
                vendaVelha.UserType = _checa.CheckUpdateString(vendaVelha.UserType, vendaAtual.UserType);
                vendaVelha.Data = _checa.ChecaUpdateData(vendaVelha.Data, vendaAtual.Data);
                vendaVelha.Conta = _checa.CheckUpdateString(vendaVelha.Conta, vendaAtual.Conta);
                vendaVelha.Valor = _checa.CheckUpdateNumber(vendaVelha.Valor, vendaAtual.Valor);
                vendaAtual.QuantAtend = _checa.ChecaUpdateInteger(vendaVelha.QuantAtend, vendaAtual.QuantAtend);
            }
            _context.Update(vendaVelha);
            await _context.SaveChangesAsync();
            return Results.Ok(new { sucesso = true, mensagem = "Atualizado com sucesso." });
        }

        public async Task<IResult> GetByMonth(int month)
        {
            if (month == 0)
            {
                month = DateOnly.FromDateTime(DateTime.Now).Month;
            }

            var vendas = await _context.Vendas
                .Where(v => v.Data.HasValue && v.Data.Value.Month == month)
                .ToListAsync();

            if (!vendas.Any())
            {
                return Results.NotFound(new { sucesso = false, mensagem = "Nenhuma venda encontrada para este mês." });
            }
            return Results.Ok(new { sucesso = true, mensagem = "Mês encontrado", dados = vendas });
        }
    }
}
