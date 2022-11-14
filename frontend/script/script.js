
/**
 * Funções
 */

//atendimento

const cadastrar_atendimento = () =>
{
	let idCliente = document.getElementById('id-cliente')
	let idFuncionario = document.getElementById('id-funcionario')
	let tipo = document.getElementById('tipo-atendimento')
	let data = document.getElementById('data-atendimento')

	if (!valida_id(idCliente) || !valida_id(idFuncionario) || !valida_cargo_ou_tipo(tipo) || !valida_data(data)) {
		return
	}

	console.log(idCliente.value, idFuncionario.value, tipo.value, data.value)
}

const mostrar_atendimento = () =>
{
	//codigo
}

const listar_atentimentos = () =>
{
	//codigo
}

const excluir_atendimento = () =>
{
	//codigo
}

//funcionario

const cadastrar_funcionario = () =>
{
	let nome = document.getElementById('nome-funcionario')
	let telefone = document.getElementById('telefone-funcionario')
	let email = document.getElementById('email-funcionario')
	let cargo = document.getElementById('cargo-funcionario')

	if (!valida_nome(nome) || !valida_telefone(telefone) || !valida_email(email) || !valida_cargo_ou_tipo(cargo)) {
		return
	}

	console.log(nome.value, telefone.value, email.value, cargo.value)
}

const mostrar_funcionario = () =>
{
	//codigo
}

const listar_funcionarios = () =>
{
	//codigo
}

const excluir_funcionario = () =>
{
	//codigo
}

//cliente

const cadastrar_cliente = (e) =>
{
	let nome = document.getElementById('nome-cliente')
	let telefone = document.getElementById('telefone-cliente')
	let email = document.getElementById('email-cliente')

	if (!valida_nome(nome) || !valida_telefone(telefone) || !valida_email(email)) {
		return
	}

	console.log(nome.value, telefone.value, email.value)
}

const mostrar_cliente = () =>
{
	//codigo
}

const listar_clientes = () =>
{
	//codigo
}

const excluir_cliente = () =>
{
	//codigo
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