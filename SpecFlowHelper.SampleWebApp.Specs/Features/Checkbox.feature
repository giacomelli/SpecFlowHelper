#language: pt-br
@Checkbox
Funcionalidade: Checkbox
	COMO usuário
	QUERO acessar a página de teste de checkbox steps
	PARA validar os passos
	 
Contexto:          
	Quando abro a url 'Home/CheckboxSteps'

Cenário: Quando marco/desmarco checkbox
	Quando marco a checkbox 'checkbox 1'
	E marco a checkbox 'checkbox 2'
	E marco a checkbox 'checkbox 3'

	Quando desmarco a checkbox 'checkbox 1'
	E desmarco a checkbox 'checkbox 2'
	E desmarco a checkbox 'checkbox 3'

	