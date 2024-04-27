using Service1.API.Models.Dtos;

namespace Service1.API.Services.IServices
{
    public interface IBpkbService
    {
        Task<IEnumerable<TrBpkbDto>> GetAll();
        Task<TrBpkbDto> GetById(string id);
        Task<TrBpkbDto> Create(TrBpkbDto trBpkbDto);
        Task<TrBpkbDto> Update(TrBpkbDto trBpkbDto);
    }
}
