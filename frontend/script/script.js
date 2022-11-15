
/**
 * Funções
 */

var url = 'http://localhost:3000/'

//atendimento

const carregaSelecoes = () => {
	fetch(url + 'funcionario')
		.then(response => response.json())
		.then((funcionarios) => {

			const selectFunctionario = document.getElementById('id-funcionario')
			selectFunctionario.innerHTML = ''

			for (const funcionario of funcionarios) {
				const option = document.createElement('option')
				option.innerText = funcionario.nome
				option.value = funcionario.id
				selectFunctionario.appendChild(option)
			}

			fetch(url + 'cliente')
				.then(response => response.json())
				.then((clientes) => {

					const selectCliente = document.getElementById('id-cliente')
					selectCliente.innerHTML = ''

					for (const cliente of clientes) {
						const option = document.createElement('option')
						option.value = cliente.id
						option.innerText = cliente.nome
						selectCliente.appendChild(option)
					}

				})
		})
}

const cadastrarAtendimento = () => {

	let idCliente = document.getElementById('id-cliente')
	let idFuncionario = document.getElementById('id-funcionario')
	let tipo = document.getElementById('tipo-atendimento')
	let data = document.getElementById('data-atendimento')

	if (!valida_id(idCliente) || !valida_id(idFuncionario) || !valida_cargo_ou_tipo(tipo) || !valida_data(data)) {
		return
	}


	let bodyAtendimento =
	{
		idCliente: document.getElementById('id-cliente').value,
		idFuncionario: document.getElementById('id-funcionario').value,
		tipo: document.getElementById('tipo-atendimento').value,
		dataAtendimento: document.getElementById('data-atendimento').value
	};

	fetch(url + "atendimento",
		{
			'method': 'POST',
			'redirect': 'follow',
			'headers':
			{
				'Content-Type': 'application/json',
				'Accept': 'application/json'
			},
			'body': JSON.stringify(bodyAtendimento)
		})
		//checa se requisicao deu certo
		.then((response) => {
			if (response.ok) {
				return response.text()
			}
			else {
				return response.text().then((text) => {
					throw new Error(text)
				})
			}
		})
		//trata resposta
		.then((output) => {
			console.log(output)
			alert('evento efetuado!')
		})
		//trata erro
		.catch((error) => {
			console.log(error)
			alert('Não foi possível efetuar o evento!')
		})

}

const mostrarAtendimento = () => {
	//da um GET no endpoint "atendimentos"
	fetch(url + 'atendimento')
		.then(response => response.json())
		.then((atendimento) => {
			//pega div que vai conter a lista de atendimentos
			let mostrarAtendimento = document.getElementById('mostrar-atendimentos')

			//limpa div
			while (mostrarAtendimento.firstChild) {
				mostrarAtendimento.removeChild(mostrarAtendimento.firstChild)
			}

			let idSelecionado = document.getElementById('id_atendimento')

			//preenche div com usuarios recebidos do GET
			for (let atendimento of Atendimento) {
				if (atendimento.id == idSelecionado) {
					//cria div para as informacoes de um atendimento
					let divAtendimento = document.createElement('div')
					divAtendimento.setAttribute('class', 'form')

					//pega o id do cliente
					let divIdCliente = document.createElement('input')
					divIdCliente.placeholder = 'Id do cliente'
					divIdCliente.value = atendimento.idCliente
					divAtendimento.appendChild(divIdCliente)

					//pega o id do funcionario
					let divIdFuncionario = document.createElement('input')
					divIdFuncionario.placeholder = 'Id do funcionario'
					divIdFuncionario.value = atendimento.idFuncionario
					divAtendimento.appendChild(divIdFuncionario)

					//pega o tipo do atendimento
					let divTipoAtendimento = document.createElement('input')
					divTipoAtendimento.placeholder = 'Tipo de atendimento'
					divTipoAtendimento.value = atendimento.tipo
					divAtendimento.appendChild(divTipoAtendimento)

					//pega a data do atendimento
					let divDataAtendimento = document.createElement('input')
					divDataAtendimento.placeholder = 'Data do atendimento'
					divDataAtendimento.value = atendimento.dataAtendimeto
					divAtendimento.appendChild(divDataAtendimento)

					//insere a div do usuario na div com a lista de usuarios
					mostrarAtendimento.appendChild(divAtendimento)
				}
			}
		})
}

const listarAtentimentos = () => {
	//da um GET no endpoint "atendimentos"
	fetch(url + 'atendimento')
		.then(response => response.json())
		.then((atendimentos) => {
			//pega div que vai conter a lista de atendimentos
			let listarAtendimento = document.getElementById('listar-atendimentos')

			//limpa div
			while (listarAtendimento.firstChild) {
				listarAtendimento.removeChild(listarAtendimento.firstChild)
			}

			//preenche div com usuarios recebidos do GET
			for (let atendimento of atendimentos) {
				//cria div para as informacoes de um atendimento
				let divAtendimento = document.createElement('div')
				divAtendimento.setAttribute('class', 'form')

				const botaoDeletar = document.createElement('button')
				botaoDeletar.innerText = 'Apagar'
				botaoDeletar.onclick = () => {
					listarAtendimento.removeChild(divAtendimento)
					excluirAtendimento(atendimento.id)
				}
				divAtendimento.appendChild(botaoDeletar)

				const botaoAtualizar = document.createElement('button')
				botaoAtualizar.innerText = 'Atualizar'
				divAtendimento.appendChild(botaoAtualizar)


				//pega o id do cliente
				let divIdCliente = document.createElement('input')
				divIdCliente.placeholder = 'Cliente'
				divIdCliente.value = atendimento.nomeCliente || 'Cliente não existente'
				divIdCliente.disabled = true
				divAtendimento.appendChild(divIdCliente)

				//pega o id do funcionario
				let divIdFuncionario = document.createElement('input')
				divIdFuncionario.placeholder = 'Funcionario'
				divIdFuncionario.value = atendimento.nomeFuncionario || 'Cliente não existente'
				divIdFuncionario.disabled = true
				divAtendimento.appendChild(divIdFuncionario)

				//pega o tipo do atendimento
				let divTipoAtendimento = document.createElement('input')
				divTipoAtendimento.placeholder = 'Tipo de atendimento'
				divTipoAtendimento.value = atendimento.tipo
				divTipoAtendimento.disabled = true
				divAtendimento.appendChild(divTipoAtendimento)

				//pega a data do atendimento
				let divDataAtendimento = document.createElement('input')
				divDataAtendimento.placeholder = 'Data do atendimento'
				divDataAtendimento.type = 'datetime-local'
				divDataAtendimento.value = atendimento.dataAtendimento
				divDataAtendimento.disabled = true
				divAtendimento.appendChild(divDataAtendimento)

				//insere a div do usuario na div com a lista de usuarios
				listarAtendimento.appendChild(divAtendimento)

				const botaoConfirma = document.createElement('button')
				botaoConfirma.innerText = 'Confirmar alterações'
				botaoConfirma.style.visibility = 'hidden'
				divAtendimento.appendChild(botaoConfirma)

				botaoAtualizar.onclick = () => {
					divTipoAtendimento.disabled = false
					divDataAtendimento.disabled = false

					botaoConfirma.style.visibility = 'unset'
				}

				botaoConfirma.onclick = () => {
					if (!valida_cargo_ou_tipo(divTipoAtendimento) || !valida_data(divDataAtendimento)) {
						return
					}

					divTipoAtendimento.disabled = true
					divDataAtendimento.disabled = true
					botaoConfirma.style.visibility = 'hidden'

					atualizarAtendimento(atendimento.id, divTipoAtendimento.value, divDataAtendimento.value)
				}
			}
		})
}

function atualizarAtendimento = (id, tipo, data) =>
{
	let body =
	    {
		    'tipo' = tipo,
		    'data' = data
	    }
	
	fetch(url + "atendimento/atualizar/" + id,
	{
		'method': 'POST',
		'redirect': 'follow',
		'headers':
		{
			'Content-Type': 'application/json',
			'Accept': 'application/json'
		},
		'body': JSON.stringify(body)
	})
	.then((response) =>
	{
		if(response.ok)
		{
			return response.text()
		}
		else
		{
			return response.text().then((text) =>
			{
				throw new Error(text)
			})
		}
	})
	.then((output) =>
	{
		console.log(output)
		alert('Usuário atualizado!')
	})
	.catch((error) =>
	{
		console.log(error)
		alert('Não foi possível atualizar o usuário!')
	})
}
	
}

const excluirAtendimento = (idSelecionado) => {

	fetch(url + 'atendimento/deletar/' + idSelecionado,
		{
			'method': 'POST',
			'redirect': 'follow'
		})
		.then((response) => {
			if (response.ok) {
				return response.text()
			}
			else {
				return response.text().then((text) => {
					throw new Error(text)
				})
			}
		})
		.then((output) => {
			console.log(output)
			alert('atendimento excluido com sucesso!');
		})
		.catch((error) => {
			console.log(error)
			alert('erro ao excluir o atendimento!');
		})
}

//funcionario

const cadastrarFuncionario = () => {

	let nome = document.getElementById('nome-funcionario')
	let telefone = document.getElementById('telefone-funcionario')
	let email = document.getElementById('email-funcionario')
	let cargo = document.getElementById('cargo-funcionario')

	if (!valida_nome(nome) || !valida_telefone(telefone) || !valida_email(email) || !valida_cargo_ou_tipo(cargo)) {
		return
	}

	let bodyFuncionario =
	{
		nome: nome.value,
		telefone: telefone.value,
		email: email.value,
		cargo: cargo.value,
	};

	fetch(url + "funcionario",
		{
			'method': 'POST',
			'redirect': 'follow',
			'headers':
			{
				'Content-Type': 'application/json',
				'Accept': 'application/json'
			},
			'body': JSON.stringify(bodyFuncionario)
		})
		//checa se requisicao deu certo
		.then((response) => {
			if (response.ok) {
				return response.text()
			}
			else {
				return response.text().then((text) => {
					throw new Error(text)
				})
			}
		})
		//trata resposta
		.then((output) => {
			console.log(output)
			alert('Cadastro efetuado!')
		})
		//trata erro
		.catch((error) => {
			console.log(error)
			alert('Não foi possível efetuar o cadastro!')
		})

}

const mostrarFuncionario = () => {
	//da um GET no endpoint "funcionarios"
	fetch(url + 'funcionario')
		.then(response => response.json())
		.then((funcionario) => {
			//pega div que vai conter a lista de funcionarios
			let mostrarFuncionario = document.getElementById('mostrar-funcionario')

			//limpa div
			while (mostrarFuncionario.firstChild) {
				mostrarFuncionario.removeChild(mostrarFuncionario.firstChild)
			}

			let idSelecionado = document.getElementById('id_funcionario')

			//preenche div com funcionarios recebidos do GET
			for (let funcionario of Funcionario) {
				if (funcionario.id == idSelecionado) {
					//cria div para as informacoes de um funcionario
					let divFuncionario = document.createElement('div')
					divFuncionario.setAttribute('class', 'form')

					//pega o nome do funcionario
					let divNomeFuncionario = document.createElement('input')
					divNomeFuncionario.placeholder = 'Nome Completo'
					divNomeFuncionario.value = funcionario.nome
					divFuncionario.appendChild(divNomeFuncionario)

					//pega o telefone do funcionario
					let divTelefoneFuncionario = document.createElement('input')
					divTelefoneFuncionario.placeholder = 'Telefone'
					divTelefoneFuncionario.value = funcionario.telefone
					divFuncionario.appendChild(divTelefoneFuncionario)

					//pega o email do funcionario
					let divEmailFuncionario = document.createElement('input')
					divEmailFuncionario.placeholder = 'Email'
					divEmailFuncionario.value = funcionario.email
					divFuncionario.appendChild(divEmailFuncionario)

					//pega o cargo do funcionario
					let divCargoFuncionario = document.createElement('input')
					divCargoFuncionario.placeholder = 'Cargo'
					divCargoFuncionario.value = funcionario.cargo
					divFuncionario.appendChild(divCargoFuncionario)

					//insere a div do funcionario na div com a lista de funcionarios
					mostrarFuncionario.appendChild(divFuncionario)
				}
			}
		})
}

const listarFuncionarios = () => {
	//da um GET no endpoint "funcionarios"
	fetch(url + 'funcionario')
		.then(response => response.json())
		.then((funcionarios) => {
			//pega div que vai conter a lista de funcionarios
			let listarFuncionario = document.getElementById('listar-funcionarios')

			//limpa div
			while (listarFuncionario.firstChild) {
				listarFuncionario.removeChild(listarFuncionario.firstChild)
			}

			//preenche div com funcionarios recebidos do GET
			for (let funcionario of funcionarios) {
				//cria div para as informacoes de um funcionario
				let divFuncionario = document.createElement('div')
				divFuncionario.setAttribute('class', 'form')

				const botaoDeletar = document.createElement('button')
				botaoDeletar.innerText = 'Demitir'
				botaoDeletar.onclick = () => {
					listarFuncionario.removeChild(divFuncionario)
					excluirFuncionario(funcionario.id)
				}
				divFuncionario.appendChild(botaoDeletar)

				const botaoAtualizar = document.createElement('button')
				botaoAtualizar.innerText = 'Atualizar'
				divFuncionario.appendChild(botaoAtualizar)

				//pega o nome do funcionario
				let divNomeFuncionario = document.createElement('input')
				divNomeFuncionario.placeholder = 'Nome Completo'
				divNomeFuncionario.value = funcionario.nome
				divNomeFuncionario.disabled = true
				divFuncionario.appendChild(divNomeFuncionario)

				//pega o telefone do funcionario
				let divTelefoneFuncionario = document.createElement('input')
				divTelefoneFuncionario.placeholder = 'Telefone'
				divTelefoneFuncionario.value = funcionario.telefone
				divTelefoneFuncionario.disabled = true
				divFuncionario.appendChild(divTelefoneFuncionario)

				//pega o email do funcionario
				let divEmailFuncionario = document.createElement('input')
				divEmailFuncionario.placeholder = 'Email'
				divEmailFuncionario.value = funcionario.email
				divEmailFuncionario.disabled = true
				divFuncionario.appendChild(divEmailFuncionario)

				//pega o cargo do funcionario
				let divCargoFuncionario = document.createElement('input')
				divCargoFuncionario.placeholder = 'Cargo'
				divCargoFuncionario.value = funcionario.cargo
				divCargoFuncionario.disabled = true
				divFuncionario.appendChild(divCargoFuncionario)

				//insere a div do funcionario na div com a lista de funcionarios
				listarFuncionario.appendChild(divFuncionario)

				const botaoConfirma = document.createElement('button')
				botaoConfirma.innerText = 'Confirmar alterações'
				botaoConfirma.style.visibility = 'hidden'
				divFuncionario.appendChild(botaoConfirma)

				botaoAtualizar.onclick = () => {
					divNomeFuncionario.disabled = false
					divTelefoneFuncionario.disabled = false
					divEmailFuncionario.disabled = false
					divCargoFuncionario.disabled = false

					botaoConfirma.style.visibility = 'unset'
				}

				botaoConfirma.onclick = () => {
					if (!valida_nome(divNomeFuncionario) || !valida_telefone(divTelefoneFuncionario) || !valida_email(divEmailFuncionario) || !valida_cargo_ou_tipo(divCargoFuncionario)) {
						return
					}

					divNomeFuncionario.disabled = true
					divTelefoneFuncionario.disabled = true
					divEmailFuncionario.disabled = true
					divCargoFuncionario.disabled = true
					botaoConfirma.style.visibility = 'hidden'

					atualizarFuncionario(funcionario.id, divNomeFuncionario.value, divTelefoneFuncionario.value, divEmailFuncionario.value, divCargoFuncionario.value)
				}
			}
		})
}

function atualizarFuncionario(id, nome, telefone, email, cargo) {
	let body =
	    {
		    'nome' = nome,
		    'telefone' = telefone,
		    'email' = email,
		    'cargo' = cargo
	    }
	
	fetch(url + "funcionario/atualizar/" + id,
	{
		'method': 'POST',
		'redirect': 'follow',
		'headers':
		{
			'Content-Type': 'application/json',
			'Accept': 'application/json'
		},
		'body': JSON.stringify(body)
	})
	.then((response) =>
	{
		if(response.ok)
		{
			return response.text()
		}
		else
		{
			return response.text().then((text) =>
			{
				throw new Error(text)
			})
		}
	})
	.then((output) =>
	{
		console.log(output)
		alert('Funcionario atualizado!')
	})
	.catch((error) =>
	{
		console.log(error)
		alert('Não foi possível atualizar o funcionario!')
	})
}

const excluirFuncionario = (idSelecionado) => {

	fetch(url + 'funcionario/deletar/' + idSelecionado,
		{
			'method': 'POST',
			'redirect': 'follow'
		})
		.then((response) => {
			if (response.ok) {
				return response.text()
			}
			else {
				return response.text().then((text) => {
					throw new Error(text)
				})
			}
		})
		.then((output) => {
			console.log(output)
			alert('funcionario demitido com sucesso!')
		})
		.catch((error) => {
			console.log(error)
			alert('erro ao excluir o funcionario!')
		})
}

//cliente

const cadastrarCliente = (e) => {
	let nome = document.getElementById('nome-cliente')
	let telefone = document.getElementById('telefone-cliente')
	let email = document.getElementById('email-cliente')

	if (!valida_nome(nome) || !valida_telefone(telefone) || !valida_email(email)) {
		return
	}

	let bodyCliente =
	{
		nome: nome.value,
		telefone: telefone.value,
		email: email.value
	};

	fetch(url + "cliente",
		{
			'method': 'POST',
			'redirect': 'follow',
			'headers':
			{
				'Content-Type': 'application/json',
				'Accept': 'application/json'
			},
			'body': JSON.stringify(bodyCliente)
		})
		//checa se requisicao deu certo
		.then((response) => {
			if (response.ok) {
				return response.text()
			}
			else {
				return response.text().then((text) => {
					throw new Error(text)
				})
			}
		})
		//trata resposta
		.then((output) => {
			console.log(output)
			alert('Cadastro efetuado!')
		})
		//trata erro
		.catch((error) => {
			console.log(error)
			alert('Não foi possível efetuar o cadastro!')
		})

}

const mostrarCliente = () => {
	//da um GET no endpoint "clientes"
	fetch(url + 'cliente')
		.then(response => response.json())
		.then((cliente) => {
			//pega div que vai conter a lista de clientes
			let mostrarCliente = document.getElementById('mostrar-cliente')

			//limpa div
			while (mostrarCliente.firstChild) {
				mostrarCliente.removeChild(mostrarCliente.firstChild)
			}

			let idSelecionado = document.getElementById('id_cliente')

			//preenche div com clientes recebidos do GET
			for (let cliente of Cliente) {
				if (cliente.id == idSelecionado) {
					//cria div para as informacoes de um cliente
					let divCliente = document.createElement('div')
					divCliente.setAttribute('class', 'form')

					//pega o nome do cliente
					let divNomeCliente = document.createElement('input')
					divNomeCliente.placeholder = 'Nome Completo'
					divNomeCliente.value = cliente.nome
					divCliente.appendChild(divNomeCliente)

					//pega o telefone do cliente
					let divTelefoneCliente = document.createElement('input')
					divTelefoneCliente.placeholder = 'Telefone'
					divTelefoneCliente.value = cliente.telefone
					divCliente.appendChild(divTelefoneCliente)

					//pega o email do cliente
					let divEmailCliente = document.createElement('input')
					divEmailCliente.placeholder = 'Email'
					divEmailCliente.value = cliente.email
					divCliente.appendChild(divEmailCliente)

					//insere a div do cliente na div com a lista de clientes
					mostrarCliente.appendChild(divCliente)
				}
			}
		})
}

const listarClientes = () => {
	//da um GET no endpoint "clientes"
	fetch(url + 'cliente')
		.then(response => response.json())
		.then((clientes) => {
			//pega div que vai conter a lista de clientes
			let listarCliente = document.getElementById('listar-clientes')

			//limpa div
			while (listarCliente.firstChild) {
				listarCliente.removeChild(listarCliente.firstChild)
			}


			//preenche div com clientes recebidos do GET
			for (let cliente of clientes) {
				//cria div para as informacoes de um cliente
				let divCliente = document.createElement('div')
				divCliente.setAttribute('class', 'form')


				const botaoDeletar = document.createElement('button')
				botaoDeletar.innerText = 'Apagar'
				botaoDeletar.onclick = () => {
					listarCliente.removeChild(divCliente)
					excluirCliente(cliente.id)
				}
				divCliente.appendChild(botaoDeletar)

				const botaoAtualizar = document.createElement('button')
				botaoAtualizar.innerText = 'Atualizar'
				divCliente.appendChild(botaoAtualizar)

				//pega o nome do cliente
				let divNomeCliente = document.createElement('input')
				divNomeCliente.placeholder = 'Nome Completo'
				divNomeCliente.disabled = true
				divNomeCliente.value = cliente.nome
				divCliente.appendChild(divNomeCliente)

				//pega o telefone do cliente
				let divTelefoneCliente = document.createElement('input')
				divTelefoneCliente.placeholder = 'Telefone'
				divTelefoneCliente.disabled = true
				divTelefoneCliente.value = cliente.telefone
				divCliente.appendChild(divTelefoneCliente)

				//pega o email do cliente
				let divEmailCliente = document.createElement('input')
				divEmailCliente.placeholder = 'Email'
				divEmailCliente.disabled = true
				divEmailCliente.value = cliente.email
				divCliente.appendChild(divEmailCliente)

				//insere a div do cliente na div com a lista de clientes
				listarCliente.appendChild(divCliente)

				const botaoConfirma = document.createElement('button')
				botaoConfirma.innerText = 'Confirmar alterações'
				botaoConfirma.style.visibility = 'hidden'
				divCliente.appendChild(botaoConfirma)

				botaoAtualizar.onclick = () => {
					divNomeCliente.disabled = false
					divTelefoneCliente.disabled = false
					divEmailCliente.disabled = false

					botaoConfirma.style.visibility = 'unset'


				}

				botaoConfirma.onclick = () => {
					if (!valida_nome(divNomeCliente) || !valida_telefone(divTelefoneCliente) || !valida_email(divEmailCliente)) {
						return
					}

					divNomeCliente.disabled = true
					divTelefoneCliente.disabled = true
					divEmailCliente.disabled = true
					botaoConfirma.style.visibility = 'hidden'

					atualizarCliente(cliente.id, divNomeCliente.value, divTelefoneCliente.value, divEmailCliente.value)
				}
			}
		})
}

function atualizarCliente (id, nome, telefone, email) {
	let body =
	    {
		    'nome' = nome,
		    'telefone' = telefone,
		    'email' = email
	    }
	
	fetch(url + "cliente/atualizar/" + id,
	{
		'method': 'POST',
		'redirect': 'follow',
		'headers':
		{
			'Content-Type': 'application/json',
			'Accept': 'application/json'
		},
		'body': JSON.stringify(body)
	})
	.then((response) =>
	{
		if(response.ok)
		{
			return response.text()
		}
		else
		{
			return response.text().then((text) =>
			{
				throw new Error(text)
			})
		}
	})
	.then((output) =>
	{
		console.log(output)
		alert('Cliente atualizado!')
	})
	.catch((error) =>
	{
		console.log(error)
		alert('Não foi possível atualizar o cliente!')
	})
}

const excluirCliente = (idSelecionado) => {

	fetch(url + 'cliente/deletar/' + idSelecionado,
		{
			'method': 'POST',
			'redirect': 'follow'
		})
		.then((response) => {
			if (response.ok) {
				return response.text()
			}
			else {
				return response.text().then((text) => {
					throw new Error(text)
				})
			}
		})
		.then((output) => {
			console.log(output)
			document.getElementById(excluir_cliente)
				.innerHTML = 'cliente excluido com sucesso!';
		})
		.catch((error) => {
			console.log(error)
			document.getElementById(excluir_cliente)
				.innerHTML = 'erro ao excluir o cliente!';
		})
}

// validações
function valida_nome({ value, classList }) {
	if (value.trim().length <= 3) {
		classList.add('erro-input')
		return false
	}
	if (value.trim().split(' ').length < 2) {
		classList.add('erro-input')
		return false
	}

	classList.remove('erro-input')
	return true
}

function valida_telefone({ value, classList }) {
	if (value && /^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$/.test(value)) {
		classList.remove('erro-input')
		return true
	}

	classList.add('erro-input')
	return false
}

function valida_email({ value, classList }) {
	if (value && /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/.test(value)) {
		classList.remove('erro-input')
		return true
	}

	classList.add('erro-input')
	return false
}

function valida_cargo_ou_tipo({ value, classList }) {
	if (value.trim().length <= 3) {
		classList.add('erro-input')
		return false
	}

	classList.remove('erro-input')
	return true
}

function valida_id({ value, classList }) {
	if (value <= 0) {
		classList.add('erro-input')
		return false
	}

	classList.remove('erro-input')
	return true
}

function valida_data({ value, classList }) {
	const data = new Date(value).getTime()
	const now = new Date().getTime()

	if (!data || data <= now) {
		classList.add('erro-input')
		return false
	}

	classList.remove('erro-input')
	return true
}
