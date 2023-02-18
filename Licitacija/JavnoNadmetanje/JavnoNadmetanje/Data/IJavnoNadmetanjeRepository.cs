using System;
using JavnoNadmetanje.Models;
using System.Collections.Generic;

namespace JavnoNadmetanje.Data
{
    public interface IJavnoNadmetanjeRepository
    { 
        bool SaveChanges();
        
        //ispisi sva javna nadmetanja
        List<JavnoNadmetanjeModel> GetAllJavnaNadmetanja();

        //ispisi ono jn sa prosledjenim id-jem
        JavnoNadmetanjeModel GetJavnoNadmetanjeById(Guid javnoNadmetanjeID);

        //kreiraj javno nadmetanje
        JavnoNadmetanjeModel CreateJavnoNadmetanje(JavnoNadmetanjeModel javnoNadmetanje);

        //azuriranje javnog nadmetanja
        void UpdateJavnoNadmetanje(JavnoNadmetanjeModel javnoNadmetanje);

        //obrisi javno nadmetanje
        void DeleteJavnoNadmetanje(Guid javnoNadmetanjeID);
    }
}
