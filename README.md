# UrlShortener

-Rodar script localizado na pasta Maguin-barboza/UrlShortener.Data/Scripts
-Modificar a instancia do sql server na classe Program método ConfigureContext (connectionString="Server=[...])

-Ao rodar o código irá abrir o Swagger. Faça as inclusões.

-O código gerado será mostrado na area de respostas do POST no swagger, conforme mostra a imagem abaixo.

![Inclusão de url](https://user-images.githubusercontent.com/54153956/157947965-0f981638-54c6-464d-b62e-d75db039f7c0.png)

-Após, será possivel realizar os testes da seguinte forma: copie e cole o endereço na url (Exemplo: "https://localhost:1234/swagger/index.html")
-No endereço, apague o a parte que faz referência ao swagger ("swagger/index.html")
-Coloque o código gerado pelo método post após a url da api (Exemplo: "https://localhost:1234/MKA0yf")
-Pronto! Você será redirecionado para a página.

#ATENÇÃO
-A api só aceita urls completas, incluindo o protocolo (http, https, ftp, etc.). Se tentar incluir alguma url sem o protocolo, será lançada uma exception: "Url não é válida."
-Exemplo: "https://www.google.com" funciona. "google.com" não funciona.
