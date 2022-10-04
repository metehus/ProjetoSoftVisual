using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Salao
{
    class Atendimento
    {
        public long id {get; set;}
        public long idCliente {get; set;}
        public long idFuncionario {get; set;}
        public string? tipo {get; set;}
        public DateTime dataAtendimento {get; set;}
    }
}
