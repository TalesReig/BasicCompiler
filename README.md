# Implementação da Análise lexica de um compilador

## Funcionalidades do sistema

- Leitura do código fonte:  lê os códigos inseridos linha a linha.

- Deve-se criar o analisador para a linguagem cujas expressões regulares estão definidas no arquivo pdf no site da disciplina.
1. Ler o código caracter a caracter
2. Classificar os lexemas
3. Gerar a lista de Tokens
4. Criar e preencher a tabela de símbolos
5. Apresentar a lista de erros

- O autômato foi implementado com desvios de código.

- Erros a serem identificados pelo analisador: aspas não fechadas, variáveis iniciando com números, números com ponto e sem as casas decimais e caracteres desconhecidos. O analisador não deve parar no primeiro erro, deve analisar todo o código e mostrar todos os erros identificados no final.

- Caso o usuário queira utilizar e testar, ele deve criar o arquivo seguindo o diretório que está na program pois isso ainda não foi automatizado para o usuários escolher o diretório.
