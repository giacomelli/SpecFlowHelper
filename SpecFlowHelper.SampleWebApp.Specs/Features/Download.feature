#language: pt-br
@Download
Funcionalidade: Download
	COMO usuário
	QUERO acessar a página de teste de download steps
	PARA validar os passos
	 
Contexto:       
	Quando abro a url 'Home/DownloadSteps'   

Cenário: Quando faço download
	Quando limpo a pasta de downloads do usuário
	Então deve existir 0 arquivos com a extensão 'zip' na pasta de downloads
	Quando clico no link 'Download sample.zip'
	Então deve existir um arquivo com o nome 'Sample.zip' na pasta de downloads
	E deve existir 1 arquivos com a extensão 'zip' na pasta de downloads
	Quando clico no link 'Download sample.zip'
	Então deve existir 2 arquivos com a extensão 'zip' na pasta de downloads	   

	