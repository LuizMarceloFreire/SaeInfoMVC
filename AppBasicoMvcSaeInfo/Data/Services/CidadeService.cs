using AppBasicoMvcSaeInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBasicoMvcSaeInfo.Data.Services
{
    public class CidadeService
    {
        public IOrderedQueryable<Cidade> OrdernarGrid(string sortOrder, IOrderedQueryable<Cidade> cidade)
        {
            switch (sortOrder)
            {
                case "cidadeDesc":
                    cidade = cidade.OrderByDescending(x => x.Nome);
                    break;
                case "estadoDesc":
                    cidade = cidade.OrderByDescending(x => x.Estado.Nome);
                    break;
            }

            return cidade;
        }
    }
}
