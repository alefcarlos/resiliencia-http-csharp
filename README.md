Projeto de referência do artigo [Criando chamadas HTTP resilientes utilizando Polly com HttpClient Factory](https://medium.com/@alef.carlos/criando-chamadas-http-resilientes-utilizando-polly-com-httpclient-factory-eafb2644a244)


# Publicando no Heroku

É necessário instalar [Heroku CLI](https://devcenter.heroku.com/articles/heroku-cli).

Usando o cmd executa o comando abaixo para realizar o login

```bash
heroku login
```

Após realizada processo de login, devemos gerar a imagem Docker e então  realizar o push da imagem para o `Container Registry do Heroku

```bash
heroku container:push web -a simulacao-erros-api
```

E então setar a imagem atual.

```bash
heroku container:release web -a simulacao-erros-api
```