using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Domain.Interfaces;

namespace Task9ASPNetCore.Services.Interfaces
{
    public interface IServices<TModelDTO>
    {
        Task<IEnumerable<TModelDTO>> GetAllAsync(int id);
        Task<TModelDTO> GetByIdAsync(int id);
        Task CreateAsync(TModelDTO model);
        Task UpdateAsync(TModelDTO model);
        Task DeleteAsync(int id);

    }
}
