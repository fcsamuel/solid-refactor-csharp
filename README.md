## Refatoração com SOLID
Projeto em C#, framework .NET Core 3.1.

---

Abaixo está descrito como foram aplicados os princípios SOLID na refatoração do projeto.  

**Single Responsability Principle (SRP)**
  - Implementação de camada de acesso aos dados responsável pelo acesso e manipulação dos dados no banco de dados;
  - Criação de camada de serviço para validação e manipulação dos dadospelas rotas aos controladores;
  - Classes e métodos com alta coesão por estarem aplicando o princípio de responsabilidade única.  

**Open/Closed Principle (OCP)**
  - Implementação de decoradores para manter o código sem alteração ao implementar alterações/melhorias.

**Liskov Substitution Principle (LSP)**
  - Implementadas duas interfaces, uma para busca e outra para manipulação dos dados, utilizando assim o padrão [CQRS (_Command Query Responsability Segregation_)](https://martinfowler.com/bliki/CQRS.html), ao invés de implemetar somente uma interface com os dois comportamentos. Dessa forma, os serviços que necessitavam somente das rotinas de consulta de informação (e não de persistência) não precisavam implementar as demais funcionalidades, afinal de contas elas não seriam necessárias ([YAGNI](https://wiki.c2.com/?YouArentGonnaNeedIt)). Dessa forma o princípio de segregação de Liskov foi aplicado.

**Interface Segregation Principle (ISP)**
  - Implementação de interfaces granulares com contratos específicos, possuindo assim um baixo acoplamento. 

**Dependency Injection (DI)**
  - Utilizada a injeção de dependência nos controladores, serviços e objetos de acesso aos dados, diminuindo assim a dependência de classes instáveis e diminuindo o acoplamento do código.

---

O código inicial é o utilizado no [curso de Solid com C# da Alura](https://www.alura.com.br/curso-online-solid-csharp-principios-orientacao-a-objetos).


