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
            if (roteiro != null)
            {
                var novoRoteiro = new Roteiro
                {
                    Data = DateOnly.FromDateTime(DateTime.Now),
                    Cliente = await _checkAddRoteiro.CheckRoteiro(roteiro.Cliente,"Cliente") == Results.Ok() ?
                        roteiro.Cliente : null!,
                    Cidade = await _checkAddRoteiro.CheckRoteiro(roteiro.Cidade,"Cidade") == Results.Ok() ?
                        roteiro.Cidade : null!,
                    Bairro = await _checkAddRoteiro.CheckRoteiro(roteiro.Bairro,"Bairro") == Results.Ok() ?
                       roteiro.Bairro : null!,
                    Observação = await _checkAddRoteiro.CheckRoteiro(roteiro.Observação,"Observação") == Results.Ok() ?
                        roteiro.Observação : null!,
                    Cartao = roteiro.Cartao,
                    Vendedor = await _checkAddRoteiro.CheckRoteiro(roteiro.Vendedor,"Vendedor") == Results.Ok() ?
                        roteiro.Vendedor : null!,
                    Numero = await _checkAddRoteiro.CheckRoteiro(roteiro.Numero,"Número/NF da venda") == Results.Ok() ?
                        roteiro.Numero : null!,
                    Pagamento = roteiro.Pagamento,
                    Troco = roteiro.Troco,
                    Responsavel = await _checkAddRoteiro.CheckRoteiro(roteiro.Responsavel,"Responsável por colocar no roteiro") == Results.Ok() ?
                        roteiro.Responsavel : null!,
                };

                await _context.Roteiros.AddAsync(novoRoteiro);
                var result = await _context.SaveChangesAsync();

                return result > 0 ? Results.Ok("Roteiro adicionado com sucesso") : Results.Problem("Erro ao adicionar roteiro");
            }
            else
            {
                throw new Exception("Roteiro não pode ser adicionado");
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
                    roteiroVelho.Cliente = _checaUpdate.CheckUpdateString(roteiroVelho.Cliente, roteiroAtual.Cliente);
                    roteiroVelho.Cidade = _checaUpdate.CheckUpdateString(roteiroVelho.Cidade, roteiroAtual.Cidade)!;
                    roteiroVelho.Bairro = _checaUpdate.CheckUpdateString(roteiroVelho.Bairro, roteiroAtual.Bairro)!;
                    roteiroVelho.Observação = _checaUpdate.CheckUpdateString(roteiroVelho.Observação, roteiroAtual.Observação);
                    roteiroVelho.Cartao = _checaUpdate.CheckUpdateNumber(roteiroVelho.Cartao, roteiroAtual.Cartao);
                    roteiroVelho.Vendedor = _checaUpdate.CheckUpdateString(roteiroVelho.Vendedor, roteiroAtual.Vendedor)!;
                    roteiroVelho.Numero = _checaUpdate.CheckUpdateString(roteiroVelho.Numero, roteiroAtual.Numero)!;
                    roteiroVelho.Pagamento = _checaUpdate.CheckUpdateNumber(roteiroVelho.Pagamento, roteiroAtual.Pagamento);
                    roteiroVelho.Troco = _checaUpdate.CheckUpdateNumber(roteiroVelho.Troco, roteiroAtual.Troco);
                    roteiroVelho.Responsavel = _checaUpdate.CheckUpdateString(roteiroVelho.Responsavel, roteiroAtual.Responsavel)!;
                };

                _context.Update(roteiroVelho);
                await _context.SaveChangesAsync();
                return Results.Ok($"Roteiro updated:{roteiroVelho.Cliente}");

            }
        }
    }
}
