#language: pt-br
@Home
Funcionalidade: Sample1
	COMO usuário
	QUERO acessar a página incial
	PARA mostrar o uso do SpecFlowHelper
	 
Contexto:          
	Quando acesso a página principal

Cenário: Quando acesso a página principal	
	Então deve exibir o texto 'Index view'

Cenário: Quando digito no campo
	Quando digito 'SpecFlowHelper sample' no campo 'input1'
	E clico no botão 'Enviar'
	Então o campo 'input1' deve ter o valor ''

Cenário: Quando inicio os jobs
	Quando digito 'Verificando SampleJob1' no campo 'input1'
	E executo o job 'SampleJob1' e aguardo pelo texto 'SampleJob1 done' no log
	Então existe o texto 'Starting SampleJob1' no log do job

	Quando digito 'Verificando SampleJob2' no campo 'input1'
	E executo o job 'SampleJob2' e aguardo pelo texto 'SampleJob2 done' no log
	Então existe o texto 'Starting SampleJob2' no log do job

	Quando digito 'Jobs ok' no campo 'input1'
