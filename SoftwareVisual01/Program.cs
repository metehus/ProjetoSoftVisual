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
            //app.MapPost("/teste", (BaseDeDados banco, Cliente cliente) =>
            //{
              //  banco.Cliente.Add(cliente);
                //banco.SaveChanges();
                //return banco.Cliente.ToList();
            //});

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


            
                //Cliente CRUD:
            

            //mostrar tudo:
            app.MapGet("/clientes", (BaseDeDados banco) => 
            {
				return banco.Cliente.ToList();
			});

            //mostra determinado cliente
            app.MapGet("/cliente/{id}", (BaseDeDados banco, long id) => 
            {
				return banco.Cliente.Find(id);
			});

            //adicionar cliente
            app.MapPost("/cadastrarcliente", (BaseDeDados banco, Cliente cliente) =>
			{
				banco.Cliente.Add(cliente);
				banco.SaveChanges();
				return "Cliente adicionado!!!";
			});

            //atualizar do cliente
            app.MapPost("/atualizarcliente/{id}", (BaseDeDados banco, Cliente clienteAtualizado, long id  ) =>
			{
				var cliente = banco.Cliente.Find(id);
                if (cliente == null) {
                    return "cliente não existe";
                }
                cliente.nome = clienteAtualizado.nome;
                cliente.telefone = clienteAtualizado.telefone;
                cliente.email = clienteAtualizado.email;
                banco.SaveChanges();
				return "Cliente atualizado!!!";
			});

            //deletar cliente:
            app.MapPost("/deletarcliente/{id}", (BaseDeDados banco,  long id) =>
			{
				var cliente = banco.Cliente.Find(id);
                if (cliente == null) {
                    return "cliente não existe";
                }
				banco.Remove(cliente);
				banco.SaveChanges();
				return "Cliente deletado!!!";
			});
		

            app.Run();
		

            
        }
    }
}
