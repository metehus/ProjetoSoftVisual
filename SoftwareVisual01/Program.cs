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
            

            		//apresentar Atendimentos
			appAtendimento.MapGet("/atendimento", (BaseAtendimento baseAtendimento) => {
				return baseAtendimento.Atendimento.ToList();
			});
			
			//apresentar Atendimento especifico
			appAtendimento.MapGet("/atendimento/{id}", (BaseAtendimento baseAtendimento, uint id) => {
				return baseAtendimento.Atendimento.Find(id);
			});
			
			//registrar Atendimento
			appAtendimento.MapPost("/registrar", (BaseAtendimento baseAtendimento, Atendimento atendimento) =>
			{
				baseAtendimento.Atendimento.Add(atendimento);
				baseAtendimento.SaveChanges();
				return "Atendimento registrado";
			});
			
			//atualizar Atendimento
			appAtendimento.MapPost("/atualizar/{id}", (BaseAtendimento baseAtendimento, Atendimento.Construtor atendimentoAtualizado, uint id) =>
			{
				var atendimento = baseAtendimento.Atendimento.Find(id);
				atendimento.cliente = atendimentoAtualizado.cliente;
				atendimento.funcionario = atendimentoAtualizado.funcionario;
                atendimento.tipoServico = atendimentoAtualizado.tipoServico;
				baseAtendimento.SaveChanges();
				return "Atendimento atualizado";
			});
						
			//deletar Atendimento
			appAtendimento.MapPost("/deletar/{id}", (BaseAtendimento baseAtendimento, uint id) =>
			{
				var atendimento = baseAtendimento.Atendimento.Find(id);
				baseAtendimento.Remove(atendimento);
				baseAtendimento.SaveChanges();
				return "Atendimento deletado";
			});

		
			appCliente.Run();
			appFuncionario.Run();
			appAtendimento.Run();
            */
        }

    }
}
