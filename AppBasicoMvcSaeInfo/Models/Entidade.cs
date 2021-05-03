using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBasicoMvcSaeInfo.Models
{
    public abstract class Entidade
    {
        public Entidade()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
    }
}
