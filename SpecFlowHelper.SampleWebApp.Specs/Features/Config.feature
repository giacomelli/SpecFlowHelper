#language: pt-br
@Config
Funcionalidade: Config
	COMO usuário
	QUERO acessar a página de teste de config steps
	PARA validar os passos
	 
Contexto:          

Cenário: Quando altero a chave do web.config
	Quando altero a chave 'testKey' do web.config para '1'

	