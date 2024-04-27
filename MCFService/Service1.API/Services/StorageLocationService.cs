using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Service1.API.Entities;
using Service1.API.Models.Dtos;
using Service1.API.Services.IServices;

namespace Service1.API.Services
{
    public class StorageLocationService : IStorageLocationService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StorageLocationService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StorageLocationDto>> GetAll()
        {
            var storageLocations = await _context.MsStorageLocation.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<StorageLocationDto>>(storageLocations);
        }
    }
}
