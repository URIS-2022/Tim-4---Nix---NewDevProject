using System;
using JavnoNadmetanje.Models;
using System.Collections.Generic;

namespace JavnoNadmetanje.Data
{
    /// <summary>
    /// intefejs javnog nadmetanja
    /// </summary>
    public interface IJavnoNadmetanjeRepository
    {
        #pragma warning disable CS1591 //nepotreban XML koment posto sve objasnili u JavnoNadmetanjeRepository

        bool SaveChanges();

        List<JavnoNadmetanjeModel> GetAllJavnaNadmetanja();

        //ispisi ono jn sa prosledjenim id-jem
        JavnoNadmetanjeModel GetJavnoNadmetanjeById(Guid javnoNadmetanjeID);

        //kreiraj javno nadmetanje
        JavnoNadmetanjeModel CreateJavnoNadmetanje(JavnoNadmetanjeModel javnoNadmetanje);

        //azuriranje javnog nadmetanja
        void UpdateJavnoNadmetanje(JavnoNadmetanjeModel javnoNadmetanje);

        //obrisi javno nadmetanje
        void DeleteJavnoNadmetanje(Guid javnoNadmetanjeID);

        #pragma warning restore CS1591 //nepotreban XML koment
    }
}
