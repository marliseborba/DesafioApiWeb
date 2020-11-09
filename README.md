# DesafioApiWeb
Projeto de API Web para vaga de desenvolvedora JR.

Este projeto consiste em uma API com operações CRUD para gerenciar usuários.
Desenvolvida no Visual Studio e necessita da ferramenta Postman para executar as requisições.

Foram implementadas as seguintes funcionalidades:
Persistência no banco de dados SQLServer (em memória) com EntityFramework;
Validação de dados com Data Annotations;
Verificação da unicidade dos atributos Login e Email;
Criptografia da senha.

Funcionamento no Postman:
URL:
https://localhost:44399/api/usuario/

Parâmetros de exemplo para POST:
{
  "Nome":"Marlise",
  "Login":"Liz",
  "Matricula":"123",
  "Senha":"abc",
  "Ativo":false,
  "Email":"marlise@gmail.com"
}

UPDATE e DELETE: informar o ID do usuário no final da url.