/*
                Atendimento CRUD:
            */

            //mostrar tudo:
            app.MapGet("/atendimento", (BaseDeDados banco) => 
            {
				return banco.Atendimento.ToList();
			});

            //mostra determinado atendimento:
            app.MapGet("/atendimento/{id}", (BaseDeDados banco, long id) => 
            {
				return banco.Atendimento.Find(id);
			});

            //adicionar atendimento:
            app.MapPost("/cadastrarAtendimento", (BaseDeDados banco, Atendimento atendimento) =>
			{
               if(banco.Cliente.Find(atendimento.cliente)?.id.CompareTo(atendimento.cliente) == 0)
               {
                    banco.Atendimento.Add(atendimento);
                    banco.SaveChanges();
                    return "Atendimento adicionado!!!";
               }
               else
               {
                    return "Cliente inexistente!!!";
               }
			});

            //atualização do atendimento:
            app.MapPost("/atualizar/{id}", (BaseDeDados banco, Atendimento atendimentoAtualizado, long id) =>
			{
				var atendimento = banco.Atendimento.Find(id);
                atendimento.dataAtendimento = atendimentoAtualizado.dataAtendimento;
				banco.SaveChanges();
				return "Atendimento atualizado!!!";
			});

            //deletar atendimento:
            app.MapPost("/deletar/{id}", (BaseDeDados banco, long id) =>
			{
				var atendimento = banco.Atendimento.Find(id);
				banco.Remove(atendimento);
				banco.SaveChanges();
				return "Atendimeno deletado!!!";
			});
