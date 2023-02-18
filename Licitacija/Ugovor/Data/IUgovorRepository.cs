using System.Collections.Generic;
using System;
using Ugovor.Models;

namespace Ugovor.Data
{
    public interface IUgovorRepository
    {
        List<UgovorModel> GetAll();
        UgovorModel GetById(Guid ugovorId);
        UgovorConfirmation Create(UgovorModel ugovor);
        void Update(UgovorModel ugovor);
        void Delete(Guid ugovorId);
        bool SaveChanges();
    }
}
