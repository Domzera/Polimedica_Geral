using Microsoft.EntityFrameworkCore;
using PolimedicaGeral.Data;
using PolimedicaGeral.DTO;
using PolimedicaGeral.Interface;
using PolimedicaGeral.Models;
using PolimedicaGeral.Service;

namespace PolimedicaGeral.Repository
{
    public class RoteiroRepository : IRoteiro
    {
        private PolimedicaGeralDBContext _context;
        private CheckAddRoteiro _checkAddRoteiro;
        private ChecaUpdate _checaUpdate;

        public RoteiroRepository(PolimedicaGeralDBContext context, CheckAddRoteiro checkAddRoteiro ,ChecaUpdate checaUpdate)
        {
            _context = context;
            _checkAddRoteiro = checkAddRoteiro;
            _checaUpdate = checaUpdate;
        }

        public async Task<IResult> Create(RoteiroDto roteiro)
        {
            //Confere se já tem esse cliente no roteiro do dia
            var roteirocliente = await _context.Roteiros.FirstOrDefaultAsync(r => r.Cliente! == roteiro.Cliente && (r.Data == roteiro.Data || roteiro.Data == null ));

            if (roteirocliente != null)
            {
                //return Results.BadRequest("Entrega já cadastrada.");
                return Results.Json(new { mensagem = "Entrega já cadastrada." }, statusCode: 400);
            }

            string validator = "";
            validator = _checkAddRoteiro.ChecaString(roteiro.Cliente, "Cliente");
            validator = _checkAddRoteiro.ChecaString(roteiro.Cidade, "Cidade");
            validator = _checkAddRoteiro.ChecaString(roteiro.Bairro, "Bairro");
            validator = _checkAddRoteiro.ChecaString(roteiro.Observacao, "Observação");
            validator = _checkAddRoteiro.ChecaString(roteiro.LojaPolimedica, "Loja/Polimédica");
            validator = _checkAddRoteiro.ChecaString(roteiro.PedidoNf, "Pedido/NF");
            validator = _checkAddRoteiro.ChecaString(roteiro.Vendedor, "Vendedora");
            validator = _checkAddRoteiro.ChecaString(roteiro.Responsavel, "Responsavel");
            validator = _checkAddRoteiro.ChecaString(roteiro.Periodo, "Periodo");

            if (validator == "" && roteiro != null)
            {
                var novoRoteiro = new Roteiro
                {
                    Data = roteiro.Data ?? DateOnly.FromDateTime(DateTime.Now),
                    Cliente = roteiro.Cliente,
                    Cidade = roteiro.Cidade,
                    Bairro = roteiro.Bairro,
                    Observacao = roteiro.Observacao,
                    Cartao = _checkAddRoteiro.SetDecimal(roteiro.Cartao),
                    LojaPolimedica = roteiro.LojaPolimedica,
                    PedidoNf = roteiro.PedidoNf,
                    DinheiroCheque = _checkAddRoteiro.SetDecimal(roteiro.DinheiroCheque),
                    Troco = _checkAddRoteiro.SetDecimal(roteiro.Troco),
                    Vendedor = roteiro.Vendedor,
                    Responsavel = roteiro.Responsavel,
                    Periodo = roteiro.Periodo,
                };

                await _context.Roteiros.AddAsync(novoRoteiro);
                var result = await _context.SaveChangesAsync();

                return result > 0 ? Results.Ok("Roteiro adicionado com sucesso") : Results.Problem("Erro ao adicionar roteiro");
            }
            else
            {
                return Results.Json(new { mensagem = validator }, statusCode: 400);
                //throw new Exception("Roteiro não pode ser adicionado");
            }
        }

        public async Task<IResult> Delete(int id)
        {
            var roteiro = _context.Roteiros.FirstOrDefault(r => r.Id == id);

            if (roteiro == null)
            {
                return Results.NotFound("Roteiro not found.");
            }

            _context.Roteiros.Remove(roteiro);
            await _context.SaveChangesAsync();

            return Results.Ok($"Roteiro deleted: {roteiro.Cliente}");
        }

        public Task<IResult> Get()
        {
            var data = DateOnly.FromDateTime(DateTime.Now);

            var roteiros = _context.Roteiros.Where(r => r.Data == data).ToList();

            if (roteiros == null || !roteiros.Any())
            {
                return Task.FromResult(Results.NotFound("Nenhum roteiro encontrado para a data especificada."));
            }

            return Task.FromResult(Results.Ok(roteiros));
        }

        public Task<IResult> GetComData(DateOnly data)
        {
            var roteiros = _context.Roteiros.Where(r => r.Data == data).ToList();

            if(roteiros == null || !roteiros.Any())
            {
                return Task.FromResult(Results.NotFound("Nenhum roteiro encontrado para a data especificada."));
            }

            return Task.FromResult(Results.Ok(roteiros));
        }

        public async Task<IResult> Update(int id,RoteiroDto roteiroAtual)
        {
            var roteiroVelho = _context.Roteiros.FirstOrDefault(r => r.Id.Equals(id));

            if (roteiroVelho == null)
            {
                return Results.NotFound("Roteiro not found.");
            }
            else
            {
                {
                    roteiroVelho.Cliente = _checaUpdate.CheckUpdateString(roteiroVelho.Cliente!, roteiroAtual.Cliente!);
                    roteiroVelho.Cidade = _checaUpdate.CheckUpdateString(roteiroVelho.Cidade!, roteiroAtual.Cidade!);
                    roteiroVelho.Bairro = _checaUpdate.CheckUpdateString(roteiroVelho.Bairro!, roteiroAtual.Bairro!);
                    roteiroVelho.Observacao = _checaUpdate.CheckUpdateString(roteiroVelho.Observacao!, roteiroAtual.Observacao!);
                    roteiroVelho.Cartao = _checaUpdate.CheckUpdateNumber(roteiroVelho.Cartao, roteiroAtual.Cartao);
                    roteiroVelho.LojaPolimedica = _checaUpdate.CheckUpdateString(roteiroVelho.LojaPolimedica!, roteiroAtual.LojaPolimedica!);
                    roteiroVelho.PedidoNf = _checaUpdate.CheckUpdateString(roteiroVelho.PedidoNf!, roteiroAtual.PedidoNf!);
                    roteiroVelho.DinheiroCheque = _checaUpdate.CheckUpdateNumber(roteiroVelho.DinheiroCheque!, roteiroAtual.DinheiroCheque!);
                    roteiroVelho.Vendedor = _checaUpdate.CheckUpdateString(roteiroVelho.Vendedor!, roteiroAtual.Vendedor!);
                    roteiroVelho.Troco = _checaUpdate.CheckUpdateNumber(roteiroVelho.Troco, roteiroAtual.Troco);
                    roteiroVelho.Responsavel = _checaUpdate.CheckUpdateString(roteiroVelho.Responsavel!, roteiroAtual.Responsavel!);
                    roteiroVelho.Periodo = _checaUpdate.CheckUpdateString(roteiroVelho.Periodo!, roteiroAtual.Responsavel!);
                }
                ;

                _context.Update(roteiroVelho);
                await _context.SaveChangesAsync();
                return Results.Ok($"Roteiro updated:{roteiroVelho.Cliente}");

            }
        }
    }
}
