using MCF.Web.Models;

namespace MCF.Web.Services.IServices
{
    public interface IStorageLocationService
    {
        Task<ResponseDto?> GetAllStorageLocation();
    }
}
