#language: pt-br
@Combobox
Funcionalidade: Combobox
	COMO usuário
	QUERO acessar a página de teste de combobox steps
	PARA validar os passos
	 
Contexto:          
	Quando abro a url 'Home/ComboboxSteps'

Cenário: Quando seleciono o texto	
	Quando seleciono 'Two' na combobox 'combobox1'
	Então a combobox 'combobox1' deve ter o texto 'Two' selecionado	