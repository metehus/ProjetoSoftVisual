using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Salao
{
    class Atendimento
    {
        public long Id {get; set;}
        public Cliente? cliente {get; set;}
        public Funcionario? funcionario {get; set;}
        public Tipo? tipo {get; set;}

        public enum Tipo
        {
            Corte,
            Colorir
            /*
                outros tipos de serviços ...
            */
        }
    }
}
