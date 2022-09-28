 //Funcionario CRUD:
            

            //mostrar tudo:
            app.MapGet("/funcionario", (BaseDeDados banco) => 
            {
				return banco.Funcionario.ToList();
			});

            //mostra determinado funcionario
            app.MapGet("/funcionario/{id}", (BaseDeDados banco, long id) => 
            {
				return banco.Funcionario.Find(id);
			});

            //adicionar funcionario
            app.MapPost("/cadastrarfuncionario", (BaseDeDados banco, Funcionario funcionario) =>
			{
				banco.Funcionario.Add(funcionario);
				banco.SaveChanges();
				return "Funcionario adicionado!!!";
			});

            //atualizar do funcionario
            app.MapPost("/atualizarfuncionario/{id}", (BaseDeDados banco, Funcionario funcionarioAtualizado, long id  ) =>
			{
				var funcionario = banco.Funcionario.Find(id);
                funcionario.nome = funcionarioAtualizado.nome;
                funcionario.numeroCelular = funcionarioAtualizado.numeroCelular;
                funcionario.email = funcionarioAtualizado.email;
                banco.SaveChanges();
				return "Funcionario atualizado!!!";
			});

            //demitir funcionario:
            app.MapPost("/deletarfuncionario/{id}", (BaseDeDados banco,  long id) =>
			{
				var funcionario = banco.Funcionario.Find(id);
				banco.Remove(funcionario);
				banco.SaveChanges();
				return "Funcionario demitido!!!";
			});
