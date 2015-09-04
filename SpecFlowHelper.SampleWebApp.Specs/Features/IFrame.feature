#language: pt-br
@Browser
Funcionalidade: IFrame
	COMO usuário
	QUERO acessar a página de teste de IFrames
	PARA validar os passos
	 
Contexto:          
	Quando abro a url 'Home/WindowWithIframes'

Cenário: Quando navega para o iframe
	Quando navego para o iframe 'IFrameFast'
	Então deve exibir o texto 'IFrameFast'

	Quando navego de volta para a janela principal

	Quando navego para o iframe 'IFrameSlow1'
	Então deve exibir o texto 'IFrameSlow1'
	Quando clico no botão 'Abrir IFrameSlow2'
	Então deve exibir o texto 'IFrameSlow2'