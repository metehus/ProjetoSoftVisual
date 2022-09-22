using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore; <<adicionar com os comando do professor>>
using Microsoft.Extensions.DependencyInjection;

namespace Union
{
    class Funcionario
    {
        public int id {get; set;}
        public string? cpf {get; set;}
        public string? nome {get; set;}
        public string? numeroCelular {get; set;}
        public string? email {get; set;}
    }
}