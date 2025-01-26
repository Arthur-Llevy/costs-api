## [PORTUGUESE]

# Sumário
-  __[Introdução](#costs-api)__
-  __[Rotas da API](#rotas)__
-  __[Com rodar o projeto](#como-rodar-o-projeto)__
-  __[English version](#english)__

<br><br>

# Costs API
O Costs API é o projeto backend do repositório [Costs](https://github.com/Arthur-Llevy/Costs-Desafio-React).

## Funcionalidades
- Criar um projeto
- Editar um projeto
- Excluir um projeto
- Atualizar um projeto
- Adicionar serviços a um projeto

## Rotas
- __{GET}__ /projects/ <br>
Lista todos os projetos
---

- __{POST}__ /projects/ <br>
Cria um novo projeto <br>
__{BODY}__ <br>
{ <br>
  "name": __string__, <br>
  "budget":  __number__, <br>
  "costs":  __number__, <br>
  "category": { <br>
    "id":  __number__, <br>
  } <br>
}

---
- __{GET}__ /projects/{id} <br>
Lista um projeto pelo seu id

---
- __{PATCH}__ /projects/{id} <br>
Edita um projeto <br>
__{BODY}__ <br>
{ <br>
  "name": __string__, <br>
  "budget":  __number__, <br>
  "costs":  __number__, <br>
  "category": { <br>
    "id":  __number__, <br>
  } <br>
}

---
- __{DELETE}__ /projects/{id} <br>
Excluir um projeto com base em seu id
---

- __{PATCH}__ /projects/addService/{id} <br>
Adiciona um serviço em um projeto com base em seu id. Tem que ser enviado dentro de uma lista<br>
__{BODY}__ <br>
[{ <br>
  "name": __string__, <br>
  "bcost":  __number__, <br>
  "description":  __string__, <br>
}]

---
- __{DELETE}__ /projects/removeService/{id} <br>
Remove um serviço de um projeto com base em seu id<br>
---

- __{GET}__ /projects/categories <br>
Traz todas as categórias cadastradas<br>
---

<br> 

## Como rodar o projeto
1. Certifique-se que o dotnet na versão 9.0 ou superior está instalado em sua máquina. Use o comando abaixo para verficiar:

```bash
dotnet --version
```
Caso não seja retornada a versão do dotnet, o mesmo não está instalado em sua máquina

1.1 Também certifique-se que o docker está instalado em sua máquina
```bash
docker --version
```
Caso não seja retornada a versão do docker, o mesmo não está instalado em sua máquina


2. Clone o projeto para um diretório de sua preferência
```bash
git clone git@github.com:Arthur-Llevy/costs-api.git
```

3. Navege até o projeto
```bash
cd ./costs-api
```

4. Inicialize o banco de dados com o docker
```bash
docker compose up --build
```

***Observação*** a flag "--build" só é necessária na primeira vez que você executa o comando. Da segunda em diante, basta executar "docker compose up".

5. Para rodar a api, vá até a pasta /Api
```bash
cd ./API
```

6. Baixe as dependências
```bash
dotnet restore
```

7. Inicie o projeto
```bash
dotnet watch run
```


Irá aparecer algo semelhante a mensagem abaixo em seu terminal, contento as portas onde você pode acessar à api
<pre>
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5016
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /minimal-api/Api   
</pre>

8. (Opicional) Acessar a UI do Scalar
Navege até a rota 
<pre>
http://localhost:<"porta">/scalar/v1
</pre>

9. Rodar os testes
Vá para a pasta ./Tests localizada na raiz do projeto
```bash
    cd ../Tests
```

10. Baixar dependências
```bash
    donet restore
```

11. Execute os testes
```
    dotnet test
```
---

## [ENGLISH]

# Summary
- __[Introduction](#costs-api-1)__
- __[API Routes](#routes)__
- __[How to run the project](#how-to-run-the-project)__
- __[Portuguese version](#portuguese)__

<br><br>

# Costs API
The Costs API is the backend project of the [Costs](https://github.com/Arthur-Llevy/Costs-Desafio-React) repository.

## Features
- Create a project
- Edit a project
- Delete a project
- Update a project
- Add services to a project

## Routes
- __{GET}__ /projects/ <br>
List all projects
---

- ​​__{POST}__ /projects/ <br>
Create a new project <br>
__{BODY}__ <br>
{<br>
"name": __string__, <br>
"budget": __number__, <br>
"costs": __number__, <br>
"category": { <br>
"id": __number__, <br>
} <br>
}
---
- __{GET}__ /projects/{id} <br>
List a project by its id

---
- __{PATCH}__ /projects/{id} <br>
Edit a project <br>
__{BODY}__ <br>
{<br>
"name": __string__, <br>
"budget": __number__, <br>
"costs": __number__, <br>
"category": { <br>
"id": __number__, <br>
} <br>
}
---
- __{DELETE}__ /projects/{id} <br>
Delete a project based on its id
---
- __{PATCH}__ /projects/addService/{id} <br>
Added a service to a project based on its id. Must be sent inside a list<br>
__{BODY}__ <br>
[{ <br>
"name": __string__, <br>
"bcost": __number__, <br>
"description": __string__, <br>
}]

---
- __{DELETE}__ /projects/removeService/{id} <br>
Remove a service from a project based on its id<br>
---

- __{GET}__ /projects/categories <br>
Brings all registered categories<br>
---

<br>

## How to run the project
1. Make sure that dotnet version 9.0 or higher is installed on your machine. Use the command below to check:

```bash
dotnet --version
```
If the dotnet version is not returned, it is not installed on your machine

1.1 Also check that docker is installed on your machine
```bash
docker --version
```
If the docker version is not returned, it is not installed on your machine

2. Clone the project to a directory of your choice
```bash
git clone git@github.com:Arthur-Llevy/costs-api.git
```

3. Navigate to the project
```bash
cd ./costs-api
```

4. Initialize the database with docker
```bash
docker compose --build
```

***Note*** the "--build" flag is only necessary the first time you run the command. From the second onwards, just run "docker compose up".

5. To run the API, go to the /Api folder
```bash
cd./API
```

6. Download the dependencies
```bash
dotnet restore
```

7. Start the project
```bash
dotnet watch run
```

Something similar to the message below will appear in your terminal, content of the ports where you can access the API
<pre>
information: Microsoft.Hosting.Lifetime[14]
Now listening: http://localhost:5016
information: Microsoft.Hosting.Lifetime[0]
Application started. Press Ctrl+C to shut down. info: Microsoft.Hosting.Lifetime[0]
Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
Content root path: /minimal-api/Api
</pre>

8. (Optional) Access the Scalar UI
Navigate to the
<pre>
http://localhost:<"port">/scalar/v1
</pre>

9. Run the tests
Go to the ./Tests folder located in the project root
```bash
cd ../Tests
```

10. Download dependencies
```bash
donet restore
```

11. Run the tests
```
dotnet test
```
---

## [ENGLISH]