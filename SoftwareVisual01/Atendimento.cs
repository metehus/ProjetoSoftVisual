using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Salao
{
    class Atendimento
    {
        public ulong Id {get; set;}
        public Cliente? cliente {get; set;}
        public Funcionario? funcionario {get; set;}
        public String? tipo {get; set;}
        public DateTime dataAtendimento {get; set;}
    }
}
