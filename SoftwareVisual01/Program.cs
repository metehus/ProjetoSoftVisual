using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Salao
{
    class BaseDeDados : DbContext
    {
        public BaseDeDados(DbContextOptions options) : base(options) { }

        public DbSet<Atendimento> Atendimento { get; set; } = null!;
        public DbSet<Funcionario> Funcionario { get; set; } = null!;
        public DbSet<Cliente> Cliente { get; set; } = null!;
    }

    class Programa
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString =
                builder.Configuration.GetConnectionString("BancoDeDados")
                ?? "Data Source=BancoDeDados.db";
            builder.Services.AddSqlite<BaseDeDados>(connectionString);

            var app = builder.Build();

            /* Apenas um teste pra ver se o banco ta funcionando, pode remover */
            app.MapPost("/teste", (BaseDeDados banco, Cliente cliente) =>
            {
                banco.Cliente.Add(cliente);
                banco.SaveChanges();
                return banco.Cliente.ToList();
            });

            /*
                Atendimento CRUD:
            */

            //mostrar tudo:
            app.MapGet("/atendimento", (BaseDeDados banco) => 
            {
				return banco.Atendimento.ToList();
			});

            //mostra determinado atendimento:
            app.MapGet("/atendimento/{id}", (BaseDeDados banco, ulong id) => 
            {
				return banco.Atendimento.Find(id);
			});

            //adicionar atendimento:
            app.MapPost("/atendimento", (BaseDeDados banco, Atendimento atendimento) =>
			{
				banco.Atendimento.Add(atendimento);
				banco.SaveChanges();
				return "Atendimento adicionado!!!";
			});

            //atualização do atendimento:
            app.MapPost("/atualizar/{id}", (BaseDeDados banco, Atendimento atendimentoAtualizado, ulong id) =>
			{
				var atendimento = banco.Atendimento.Find(id);
                atendimento.tipo = atendimentoAtualizado.tipo;
                atendimento.dataAtendimento = atendimentoAtualizado.dataAtendimento;
				banco.SaveChanges();
				return "Atendimento atualizado!!!";
			});

            //deletar atendimento:
            app.MapPost("/deletar/{id}", (BaseDeDados banco, ulong id) =>
			{
				var atendimento = banco.Atendimento.Find(id);
				banco.Remove(atendimento);
				banco.SaveChanges();
				return "Atendimeno deletado!!!";
			});
		

            app.Run();
        }
    }
}
