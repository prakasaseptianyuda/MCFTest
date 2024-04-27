using Service1.API.Models.Dtos;

namespace Service1.API.Services.IServices
{
    public interface IStorageLocationService
    {
        Task<IEnumerable<StorageLocationDto>> GetAll();
    }
}
