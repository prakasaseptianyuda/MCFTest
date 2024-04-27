using MCF.Web.Models;

namespace MCF.Web.Services.IServices
{
    public interface IBpkbService
    {
        Task<ResponseDto?> GetAllTrBpkb();
        Task<ResponseDto?> GetTrBpkbById(string id);
        Task<ResponseDto?> Create(TrBpkbDto trBpkbDto);
        Task<ResponseDto?> Update(TrBpkbDto trBpkbDto);
    }
}
