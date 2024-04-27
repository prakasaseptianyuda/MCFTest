using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Service1.API.Entities;
using Service1.API.Models.Dtos;
using Service1.API.Services.IServices;

namespace Service1.API.Services
{
    public class BpkbService : IBpkbService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BpkbService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TrBpkbDto> Create(TrBpkbDto trBpkbDto)
        {
            var trBpkbDb = await _context.TrBpkb.AsNoTracking().Where(t => t.AgreementNumber == trBpkbDto.AgreementNumber).FirstOrDefaultAsync();

            if (trBpkbDb != null) {
                throw new Exception("Agreement number telah terdaftar!");
            }

            TrBpkb trBpkb = _mapper.Map<TrBpkb>(trBpkbDto);
            trBpkb.CreatedOn = DateTime.Now;
            trBpkb.LastUpdatedOn = DateTime.Now;

            _context.TrBpkb.Add(trBpkb);
            await _context.SaveChangesAsync();
            return _mapper.Map<TrBpkbDto>(trBpkb);
        }

        public async Task<IEnumerable<TrBpkbDto>> GetAll()
        {
            var trBpkbList = await _context.TrBpkb.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<TrBpkbDto>>(trBpkbList);
        }

        public async Task<TrBpkbDto> GetById(string id)
        {
            var trBpkb = await _context.TrBpkb.AsNoTracking().Where(w => w.AgreementNumber == id).FirstOrDefaultAsync();
            return _mapper.Map<TrBpkbDto>(trBpkb);
        }

        public async Task<TrBpkbDto> Update(TrBpkbDto trBpkbDto)
        {
            var trBpkbDb = await _context.TrBpkb.AsNoTracking().Where(t => t.AgreementNumber == trBpkbDto.AgreementNumber).FirstOrDefaultAsync();

            if (trBpkbDb == null)
            {
                throw new Exception("Agreement number tidak terdaftar!");
            }

            TrBpkb trBpkb = _mapper.Map<TrBpkb>(trBpkbDto);
            trBpkb.LastUpdatedOn = DateTime.Now;

            _context.TrBpkb.Update(trBpkb);
            await _context.SaveChangesAsync();
            return _mapper.Map<TrBpkbDto>(trBpkb);
        }

    }
}
