#language: pt-br
@Badge
Funcionalidade: Badge
	COMO usuário
	QUERO acessar a página de teste de badge steps
	PARA validar os passos
	 
Contexto:          
	Quando abro a url 'Home/BadgeSteps'

Cenário: Deve exibir o badge com o texto
	Quando clico no botão 'Show badge'
	Então deve exibir o badge com o texto 'Badge 01'

	Quando clico no botão 'Show badge'
	Então deve exibir o badge com o texto 'Badge 02'

	Quando clico no botão 'Show badge'
	Então deve exibir o badge com o texto 'Badge 03'