#language: pt-br
@RadioButton
Funcionalidade: RadioButton
	COMO usuário
	QUERO acessar a página de teste de radiobutton steps
	PARA validar os passos
	 
Contexto:          
	Quando abro a url 'Home/RadioButtonSteps'

Cenário: Quando marco/desmarco radiobutton
	Quando marco o radiobutton 'Radio 1'
	E marco o radiobutton 'Radio 2'
	E marco o radiobutton 'Radio 3'

	