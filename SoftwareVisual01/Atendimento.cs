using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore; <<adicionar com os comando do professor>>
using Microsoft.Extensions.DependencyInjection;

namespace Union
{
    class Atendimento
    {
        public int id {get; set;}
        public Cliente? cliente {get; set;}
        public Funcionario? funcionario {get; set;}
        public enum tipoServico
        {
            Corte,
            Colorir
            /*
                outros tipos de serviços ...
            */
        }

        

    }
}