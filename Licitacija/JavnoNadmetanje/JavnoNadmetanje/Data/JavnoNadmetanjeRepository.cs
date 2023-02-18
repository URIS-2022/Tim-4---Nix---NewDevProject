using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JavnoNadmetanje.Data
{
    /// <summary>
    /// repozitorijum javnog nadmetanja koji je prosisern njegovim interfejsom
    /// </summary>
    public class JavnoNadmetanjeRepository : IJavnoNadmetanjeRepository
    {
        private readonly JavnoNadmetanjeContext context;

        /// <summary>
        /// deklarisanje klase
        /// </summary>
        /// <param name="context"></param>
        public JavnoNadmetanjeRepository(JavnoNadmetanjeContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// funkcija koja vraca sva javna nadmetanja u bazi
        /// </summary>
        /// <returns>lista svih javnih nadmetanja</returns>
        public List<JavnoNadmetanjeModel> GetAllJavnaNadmetanja()
        {
            return (from j in context.JavnaNadmetanja select j).ToList();
        }

        /// <summary>
        /// funkcija koja u zavisnosti od prosledjenog id-a ispisuje odredjenjo javno nadmetanje
        /// </summary>
        /// <param name="javnoNadmetanjeID"></param>
        /// <returns>javno nadmetanje sa unetim id-jem</returns>
        public JavnoNadmetanjeModel GetJavnoNadmetanjeById(Guid javnoNadmetanjeID)
        {
            return context.JavnaNadmetanja.FirstOrDefault(j => j.JavnoNadmetanjeID == javnoNadmetanjeID);
        }

        /// <summary>
        /// funkcija kojom kreiramo novo javno nadmetanje
        /// </summary>
        /// <param name="javnoNadmetanje"></param> 
        /// <returns></returns>
        public JavnoNadmetanjeModel CreateJavnoNadmetanje(JavnoNadmetanjeModel javnoNadmetanje)
        {
            javnoNadmetanje.JavnoNadmetanjeID = Guid.NewGuid();
            context.JavnaNadmetanja.Add(javnoNadmetanje);
            JavnoNadmetanjeModel novoNadmetanje = GetJavnoNadmetanjeById(javnoNadmetanje.JavnoNadmetanjeID);
            return novoNadmetanje;
        }

        /// <summary>
        /// funkcija kojom brisemo postojece javno nadmetanje u odnosu na prosledjeni id
        /// </summary>
        /// <param name="javnoNadmetanjeID"></param>
        public void DeleteJavnoNadmetanje(Guid javnoNadmetanjeID)
        {
            //var javnoNadmetanje = GetJavnoNadmetanjeById(javnoNadmetanjeID);
            //if (javnoNadmetanje != null)
            //{
            //    context.Remove(javnoNadmetanje);
            //}
            context.JavnaNadmetanja.Remove(context.JavnaNadmetanja.FirstOrDefault(j => j.JavnoNadmetanjeID == javnoNadmetanjeID));
        }


        /// <summary>
        /// funkcija kojom azuriramo neko postojece javno nadmetanje, ali ovde nismo nista deklarisali samo u controlleru
        /// </summary>
        /// <param name="javnoNadmetanje"></param>
        public void UpdateJavnoNadmetanje(JavnoNadmetanjeModel javnoNadmetanje)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// cuva sve promene
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

    }
}
