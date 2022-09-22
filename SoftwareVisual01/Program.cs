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
			
			//Conexão com o banco Cliente.db
			var connectionCliente = builder.Configuration.GetConnectionString("Cliente") ?? "Data Source=Cliente.db";
			builder.Services.AddSqlite<BaseCliente>(connectionCliente);
			
			var appCliente = builder.Build();
			
			//Conexão com o banco Funcionario.db
			var connectionFuncionario = builder.Configuration.GetConnectionString("Funcionario") ?? "Data Source=Funcionario.db";
			builder.Services.AddSqlite<BaseFuncionario>(connectionFuncionario);
			
			var appFuncionario = builder.Build();
			
			//Conexão com o banco Atendimento.db
			var connectionAtendimento = builder.Configuration.GetConnectionString("Atendimento") ?? "Data Source=Atendimento.db";
			builder.Services.AddSqlite<BaseAtendimento>(connectionAtendimento);
			
			var appAtendimento = builder.Build();
            */
		/*
			appCliente.Run();
			appFuncionario.Run();
			appAtendimento.Run();
		*/
            
        }

    }
}
