using PolimedicaGeral.DTO;

namespace PolimedicaGeral.Interface
{
    public interface IRoteiro
    {
        /// <summary>
        /// Gets all roteiros.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        
        Task<IResult> Get();
        Task<IResult> GetComData(DateOnly data);
        Task<IResult> Update(int id,RoteiroDto novo);
        Task<IResult> Delete(int id);
        Task<IResult> Create(RoteiroDto roteiro);

    }
}
