# NGConnection

### Definição: 
- O pacote NGConnection contém estruturas para auxiliar a manipulação de conexões com banco de dados.

### Vantagens: 
- Ter estruturas prontas para facilitar a manipulação de conexões.
- Padronizar a manipulação de conexões.

# Documentação

### Usings:

```ruby
using NGConnection;
using NGConnection.Enums;
```

### Implementação NGConnection:

Para criar uma conexão basta criar um objeto do banco correspondente passando os parâmetros da string de conexão.
```ruby
MySql mysql = new MySql("IpAddress", "DataBaseName", "UserName", "Password");
MySql mysql = new MySql($@"Server = {IpAddress}; Database = {DataBaseName}; Uid = {UserName}; Pwd = {Password}; Connection Timeout = {TimeOut};");
```
> [!NOTE]
> Note que pode-se iniciar o objeto passando a string inteira ou os parametros separadamente.
