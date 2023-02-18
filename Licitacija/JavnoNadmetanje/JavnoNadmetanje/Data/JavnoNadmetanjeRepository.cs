using JavnoNadmetanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JavnoNadmetanje.Data
{
    public class JavnoNadmetanjeRepository : IJavnoNadmetanjeRepository
    {
        private readonly JavnoNadmetanjeContext context;

        public JavnoNadmetanjeRepository(JavnoNadmetanjeContext context)
        {
            this.context = context;
        }

        //get all
        public List<JavnoNadmetanjeModel> GetAllJavnaNadmetanja()
        {
            return (from j in context.JavnaNadmetanja select j).ToList();
        }

        //get by id
        public JavnoNadmetanjeModel GetJavnoNadmetanjeById(Guid javnoNadmetanjeID)
        {
            return context.JavnaNadmetanja.FirstOrDefault(j => j.JavnoNadmetanjeID == javnoNadmetanjeID);
        }

        //create
        public JavnoNadmetanjeModel CreateJavnoNadmetanje(JavnoNadmetanjeModel javnoNadmetanje)
        {
            javnoNadmetanje.JavnoNadmetanjeID = Guid.NewGuid();
            context.JavnaNadmetanja.Add(javnoNadmetanje);
            JavnoNadmetanjeModel novoNadmetanje = GetJavnoNadmetanjeById(javnoNadmetanje.JavnoNadmetanjeID);
            return novoNadmetanje;
        }

        //delete
        public void DeleteJavnoNadmetanje(Guid javnoNadmetanjeID)
        {
            //var javnoNadmetanje = GetJavnoNadmetanjeById(javnoNadmetanjeID);
            //if (javnoNadmetanje != null)
            //{
            //    context.Remove(javnoNadmetanje);
            //}
            context.JavnaNadmetanja.Remove(context.JavnaNadmetanja.FirstOrDefault(j => j.JavnoNadmetanjeID == javnoNadmetanjeID));
        }


        //update
        public void UpdateJavnoNadmetanje(JavnoNadmetanjeModel javnoNadmetanje)
        {
            //throw new NotImplementedException();
        }


        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

    }
}
