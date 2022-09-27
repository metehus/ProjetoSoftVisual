using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Salao
{
    class Cliente
    {
        public ulong id {get; set;}
        //public string? cpf {get; set;}
        public string? nome {get; set;}
        public string? telefone {get; set;}
        public string? email {get; set;}
    }
}



