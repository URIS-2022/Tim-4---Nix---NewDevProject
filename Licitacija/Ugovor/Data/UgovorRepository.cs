using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System;
using Ugovor.Models;

namespace Ugovor.Data
{
    public class UgovorRepository : IUgovorRepository
    {
        private readonly UgovorDbContext _context;
        private readonly IMapper _mapper;

        public UgovorRepository(UgovorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public List<UgovorModel> GetAll()
        {
            return _context.Ugovori.ToList();
        }
        public UgovorModel GetById(Guid ugovorId)
        {
            return _context.Ugovori.FirstOrDefault(e => e.UgovorId == ugovorId);
        }

        public UgovorConfirmation Create(UgovorModel ugovor)
        {
            ugovor.UgovorId = Guid.NewGuid();
            var ugovorDodat = _context.Ugovori.Add(ugovor);
            return _mapper.Map<UgovorConfirmation>(ugovorDodat.Entity);
        }

        public void Update(UgovorModel ugovor)
        {
            //Nije potrebna implementacija
        }

        public void Delete(Guid ugovorId)
        {
            var ugovor = GetById(ugovorId);
            _context.Remove(ugovor);
        }
    }
}
