using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Salao
{
	class BaseDeDados : DbContext
	{
		public BaseDeDados(DbContextOptions options) : base(options)
		{
		}
		
		public DbSet<Atendimento> Atendimentos { get; set; } = null!;
		public DbSet<Funcionario> Funcionario { get; set; } = null!;
		public DbSet<Cliente> Cliente { get; set; } = null!;
	}

	class Programa {
		static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			
			var connectionString = builder.Configuration.GetConnectionString("BancoDeDados") ?? "Data Source=BancoDeDados.db";
			builder.Services.AddSqlite<BaseDeDados>(connectionString);

			
			var app = builder.Build();
		}
	}
}
