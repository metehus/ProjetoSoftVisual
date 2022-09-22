using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore; <<adicionar com os comando do professor>>
using Microsoft.Extensions.DependencyInjection;

namespace Union
{
    class Atendimento
    {
        public uint id;
        public Cliente? cliente;
        public Funcionario? funcionario;
        public enum tipoServico
        {
            Corte,
            Colorir
            /*
                outros tipos de serviços ...
            */
        };
        public class Construtor 
        { 
            public int id {get; set;}
            public Cliente? cliente {get; set;}
            public Funcionario? funcionario {get; set;}
            public tipoServico tipoServico {get; set;} 
        }
    }
}
