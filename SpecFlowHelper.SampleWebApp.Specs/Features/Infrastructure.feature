#language: pt-br
@Infrastructure
Funcionalidade: Infrastructure
	COMO usuário
	QUERO acessar a página de teste de infrastructure steps
	PARA validar os passos
	 
Contexto:          
	

Cenário: Quando limpo o cache da web api
	Quando abro a url 'http://localhost:8001/api/Sample'
	Então deve exibir o texto 'Current sample 1'
	Quando abro a url 'http://localhost:8001/api/Sample'
	Então deve exibir o texto 'Current sample 2'
	Quando limpo o cache da web api
	Quando abro a url 'http://localhost:8001/api/Sample'
	Então deve exibir o texto 'Current sample 1'



	