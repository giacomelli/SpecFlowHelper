#language: pt-br
@Button
Funcionalidade: Button
	COMO usuário
	QUERO acessar a página de teste de button steps
	PARA validar os passos
	 
Contexto:          
	Quando abro a url 'Home/ButtonSteps'

Cenário: Quando clico no botão
	Quando clico no botão 'click button 1'
	Então deve exibir o texto 'button 01 clicked'

	Quando clico no botão 'click button 2'
	Então deve exibir o texto 'button 02 clicked'

	Quando clico no botão 'click button 3'
	Então deve exibir o texto 'button 03 clicked'