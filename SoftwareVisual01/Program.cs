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

            /*
            Atendimento CRUD:
            */

            //mostrar tudo:
            app.MapGet(
                "/atendimento",
                (BaseDeDados banco) =>
                {
                    return banco.Atendimento.ToList();
                }
            );

            //mostra determinado atendimento:
            app.MapGet(
                "/atendimento/{id}",
                (BaseDeDados banco, long id) =>
                {
                    return banco.Atendimento.Find(id);
                }
            );

            //adicionar atendimento:
            app.MapPost(
                "/atendimento",
                (BaseDeDados banco, Atendimento atendimento) =>
                {
                    if (
                        banco.Cliente.Find(atendimento.idCliente) != null
                        && banco.Funcionario.Find(atendimento.idFuncionario) != null
                    )
                    {
                        var atendimentos = banco.Atendimento.ToList();

                        foreach(var _atendimento in atendimentos) {
                            if (_atendimento.idCliente == atendimento.idCliente && _atendimento.dataAtendimento == atendimento.dataAtendimento) {
                                return "Já existe um atendimento neste horário com este cliente.";
                            } else if (_atendimento.idFuncionario == atendimento.idFuncionario && _atendimento.dataAtendimento == atendimento.dataAtendimento) {
                                return "Já existe um atendimento neste horário com este funcionario.";
                            }
                        }

                        banco.Atendimento.Add(atendimento);
                        banco.SaveChanges();

                        return "Atendimento adicionado!!!";
                    }

                    return "cliente ou funcionario não existe";
                }
            );

            //atualização do atendimento:
            app.MapPost(
                "/atendimento/atualizar/{id}",
                (BaseDeDados banco, Atendimento atendimentoAtualizado, long id) =>
                {
                    var atendimento = banco.Atendimento.Find(id);

                    if (atendimento == null)
                    {
                        return "atendimento não existe";
                    }

                    atendimento.tipo = atendimentoAtualizado.tipo;
                    atendimento.dataAtendimento = atendimentoAtualizado.dataAtendimento;
                    banco.SaveChanges();

                    return "Atendimento atualizado!!!";
                }
            );

            //deletar atendimento:
            app.MapPost(
                "/atendimento/deletar/{id}",
                (BaseDeDados banco, long id) =>
                {
                    var atendimento = banco.Atendimento.Find(id);

                    if (atendimento == null)
                    {
                        return "atendimento não existe";
                    }

                    banco.Remove(atendimento);
                    banco.SaveChanges();

                    return "Atendimeno deletado!!!";
                }
            );

            //Cliente CRUD:


            //mostrar tudo:
            app.MapGet(
                "/cliente",
                (BaseDeDados banco) =>
                {
                    return banco.Cliente.ToList();
                }
            );

            //mostra determinado cliente
            app.MapGet(
                "/cliente/{id}",
                (BaseDeDados banco, long id) =>
                {
                    return banco.Cliente.Find(id);
                }
            );

            //adicionar cliente
            app.MapPost(
                "/cliente",
                (BaseDeDados banco, Cliente cliente) =>
                {
                    banco.Cliente.Add(cliente);
                    banco.SaveChanges();

                    return "Cliente adicionado!!!";
                }
            );

            //atualizar do cliente
            app.MapPost(
                "/cliente/atualizar/{id}",
                (BaseDeDados banco, Cliente clienteAtualizado, long id) =>
                {
                    var cliente = banco.Cliente.Find(id);

                    if (cliente == null)
                    {
                        return "cliente não existe";
                    }

                    cliente.nome = clienteAtualizado.nome;
                    cliente.telefone = clienteAtualizado.telefone;
                    cliente.email = clienteAtualizado.email;
                    banco.SaveChanges();

                    return "Cliente atualizado!!!";
                }
            );

            //deletar cliente:
            app.MapPost(
                "/cliente/deletar/{id}",
                (BaseDeDados banco, long id) =>
                {
                    var cliente = banco.Cliente.Find(id);

                    if (cliente == null)
                    {
                        return "cliente não existe";
                    }

                    banco.Remove(cliente);
                    banco.SaveChanges();

                    return "Cliente deletado!!!";
                }
            );

            //Funcionario CRUD:

            //mostrar tudo:
            app.MapGet(
                "/funcionario",
                (BaseDeDados banco) =>
                {
                    return banco.Funcionario.ToList();
                }
            );

            //mostra determinado funcionario
            app.MapGet(
                "/funcionario/{id}",
                (BaseDeDados banco, long id) =>
                {
                    return banco.Funcionario.Find(id);
                }
            );

            //adicionar funcionario
            app.MapPost(
                "/funcionario",
                (BaseDeDados banco, Funcionario funcionario) =>
                {
                    banco.Funcionario.Add(funcionario);
                    banco.SaveChanges();
                    return "Funcionario adicionado!!!";
                }
            );

            //atualizar do funcionario
            app.MapPost(
                "/funcionario/atualizar/{id}",
                (BaseDeDados banco, Funcionario funcionarioAtualizado, long id) =>
                {
                    var funcionario = banco.Funcionario.Find(id);

                    if (funcionario == null)
                    {
                        return "funcionário não existe";
                    }

                    funcionario.nome = funcionarioAtualizado.nome;
                    funcionario.telefone = funcionarioAtualizado.telefone;
                    funcionario.email = funcionarioAtualizado.email;
                    funcionario.cargo = funcionarioAtualizado.cargo;
                    banco.SaveChanges();

                    return "Funcionario atualizado!!!";
                }
            );

            //demitir funcionario:
            app.MapPost(
                "/funcionario/deletar/{id}",
                (BaseDeDados banco, long id) =>
                {
                    var funcionario = banco.Funcionario.Find(id);

                    if (funcionario == null)
                    {
                        return "funcionário não existe";
                    }

                    banco.Remove(funcionario);
                    banco.SaveChanges();

                    return "Funcionario demitido!!!";
                }
            );

            app.Run();
        }
    }
}
