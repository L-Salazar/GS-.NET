# Integrantes:

- Alexsandro Macedo: RM557068
- Leonardo Faria Salazar: RM557484
- Guilherme Felipe da Silva Souza: RM558282

# Video de demonstração

 - Video demonstração

https://www.youtube.com/watch?v=GR-xSpwOhPg&ab_channel=Guilhermedasilva - Video Pitch


# 🌧️ Alagaqui API - .NET Core + Oracle

Este projeto tem como objetivo criar uma solução tecnológica para registrar e monitorar ocorrências de alagamento em áreas urbanas, combinando dados da comunidade, promovendo prevenção e resposta rápida. O usuário pode marcar em tempo real uma área de alagamento. Abaixo algumas imagens que ilustram o aplicativo:

![image](https://github.com/user-attachments/assets/f2ba915e-20d6-4a69-977b-30a5bcf0b11b)
![image](https://github.com/user-attachments/assets/a85a241a-10ec-42fd-a975-ca86cf2acae8)
![image](https://github.com/user-attachments/assets/12acab83-6426-4ac1-8d93-79ea4b5516da)
![image](https://github.com/user-attachments/assets/7478e543-be69-483c-b12d-46c05464ecd2)
![image](https://github.com/user-attachments/assets/5e30e074-1d98-4c22-890d-0441c2f69155)

---

## 📌 Funcionalidades

- Cadastro e gerenciamento de usuários
- Registro de localizações com coordenadas geográficas
- Relato de ocorrências de alagamento por usuários
- Geração de alertas vinculados a ocorrências
- Classificação de alertas por tipo
- Relacionamentos 1:N entre entidades
- Integração com banco de dados Oracle
- Documentação Swagger UI

---

## 🧱 Estrutura do Projeto

```
Alagaqui/
├── Domain/
│   ├── Entities/              # Entidades do domínio
│   └── Interfaces/            # Interfaces de repositórios
├── Application/
│   ├── Dtos/                  # Objetos de Transferência de Dados
│   ├── Interfaces/            # Interfaces de serviços da aplicação
│   └── Services/              # Implementações de serviços
├── Infrastructure/
│   └── Data/
│       ├── AppData/           # DbContext (Oracle)
│       └── Repositories/      # Repositórios concretos
├── Presentation/
│   └── Controllers/           # Controllers RESTful
└── Program.cs                 # Configuração principal
```

---

## 🔗 Endpoints

> Documentação disponível via Swagger em `/swagger` após rodar o projeto.

### Usuários
- `GET /api/Usuario`
- `POST /api/Usuario`
- `PUT /api/Usuario/{id}`
- `DELETE /api/Usuario/{id}`

### Localizações
- `GET /api/Localizacao`
- `POST /api/Localizacao`
- `PUT /api/Localizacao/{id}`
- `DELETE /api/Localizacao/{id}`

### Ocorrências
- `GET /api/Ocorrencia`
- `POST /api/Ocorrencia`
- `PUT /api/Ocorrencia/{id}`
- `DELETE /api/Ocorrencia/{id}`

### Alertas
- `GET /api/Alerta`
- `POST /api/Alerta`
- `PUT /api/Alerta/{id}`
- `DELETE /api/Alerta/{id}`

### Tipos de Alerta
- `GET /api/TipoAlerta`
- `GET /api/TipoAlerta/com-alertas`
- `POST /api/TipoAlerta`
- `PUT /api/TipoAlerta/{id}`
- `DELETE /api/TipoAlerta/{id}`

---

## ⚙️ Tecnologias

- ASP.NET Core 8
- Entity Framework Core
- Oracle DB
- Swagger / Swashbuckle
- C# 11

---

## ▶️ Como Rodar o Projeto

1. Configure sua `ConnectionStrings:Oracle` no `appsettings.json`:
```json
"ConnectionStrings": {
  "Oracle": "User Id=alagaqui_user;Password=senha123;Data Source=localhost:1521/xe"
}
```

2. Execute os comandos:
```bash
dotnet restore
dotnet ef database update
dotnet run
```

3. Acesse `https://localhost:{porta}/swagger` para explorar os endpoints.

---

## 🧪 Exemplo de JSON para testes no Swagger

### ✅ Criar Usuário
```json
{
  "idUsuario": 0,
  "nomeUsuario": "Lucas Mendes",
  "emailUsuario": "lucas.mendes@example.com",
  "senhaUsuario": "lucas123",
  "dataUltimaCriacaoRelato": "2025-06-09T09:00:00"
}
```

### ✅ Criar Localização
```json
{
  "idLocalizacao": 0,
  "nomeLocalizacao": "Rua das Águas Claras",
  "latitude": -23.481234,
  "longitude": -46.598321
}
```

### ✅ Criar Ocorrência
```json
{
  "idOcorrencia": 0,
  "idUsuario": 2,
  "idLocalizacao": 2,
  "titulo": "Alagamento parcial na entrada do parque",
  "descricao": "Entrada do parque com 30 cm de água acumulada após chuva forte.",
  "dataHoraOcorrencia": "2025-06-09T10:30:00"
}
```

### ✅ Criar Tipo de Alerta
```json
{
  "idTipoAlerta": 0,
  "descricaoTipoAlerta": "Alerta de Alagamento Crítico"
}
```

### ✅ Criar Alerta
```json
{
  "idAlerta": 0,
  "idOcorrenciaRelacionada": 2,
  "idTipoAlerta": 1,
  "mensagemAlerta": "Área crítica de alagamento. Trânsito bloqueado.",
  "dataHoraCriacaoAlerta": "2025-06-09T10:45:00",
  "resolvidoAlerta": "N"
}
```
