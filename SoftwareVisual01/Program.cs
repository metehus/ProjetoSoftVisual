using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore; <<adicionar com os comando do professor>>
using Microsoft.Extensions.DependencyInjection;

namespace Union
{

    //Banco de clientes:

    /*
    class BaseClientes : DbContext
	{
		public BaseClientes(DbContextOptions options) : base(options)
		{
		}
		
		public DbSet<Clientes> Clientes { get; set; } = null!;
	}

    //Banco de Funcionarios:
    class BaseFuncionarios : DbContext
	{
		public BaseFuncionarios(DbContextOptions options) : base(options)
		{
		}
		
		public DbSet<Funcionarios> Funcionarios { get; set; } = null!;
	}

    //Banco de Atendimentos:

        class BaseAtendimento : DbContext
	{
		public BaseAtendimento(DbContextOptions options) : base(options)
		{
		}
		
		public DbSet<Atendimento> Atendimento { get; set; } = null!;
	}
    */

    class Program
    {
        static void main(String[] args)
        {
            /*
            var builder = WebApplication.CreateBuilder(args);
			
			var connectionString = builder.Configuration.GetConnectionString("Usuarios") ?? "Data Source=Usuarios.db";
			builder.Services.AddSqlite<BaseUsuarios>(connectionString);
			
			var app = builder.Build();
            */

            //app.Run();
        }

    }
}