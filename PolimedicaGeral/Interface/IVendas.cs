using PolimedicaGeral.DTO;

namespace PolimedicaGeral.Interface
{
    public interface IVendas
    {
        Task<IResult> Create(VendasDto vendas);
        Task<IResult> GetByMonth(int month);
        Task<IResult> Update(int id,VendasDto vendas);
    }
}
