# Microservices Marketplace Project

Este é um projeto baseado em .NET 6, seguindo padrões de Microservices, DDD e Clean Architecture. Cada serviço é implementado como um microserviço independente,
promovendo a escalabilidade e manutenção simplificada.

## Serviços 🛠️

### 1. Catalog Service 📚

- **Armazenamento:** MongoDB
- **Descrição:** Responsável por gerenciar o catálogo de produtos.

### 2. Basket Service 🛒

- **Armazenamento:** Redis (Cache)
- **Descrição:** Gerencia o carrinho de compras, armazenando produtos em cache para uma experiência de compra eficiente.

### 3. Discount Service 💰

- **Armazenamento:** PostgreSQL
- **Descrição:** Oferece descontos para produtos, com os detalhes armazenados no PostgreSQL.

### 4. Ordering Service 📦

- **Armazenamento:** PostgreSQL
- **Descrição:** Trata do processo de pedidos, desde a criação até a conclusão.

## Arquitetura e Estrutura do Projeto 🏰

O projeto segue uma arquitetura limpa (Clean Architecture) e DDD:

- **Camada de API:** Responsável pela exposição de endpoints HTTP.
- **Camada de Aplicação:** Contém a lógica de aplicação específica.
- **Camada de Infraestrutura:** Inclui implementações específicas de infraestrutura, como acesso a banco de dados e integrações externas.
- **Camada de Domínio:** Compartilhada entre todos os serviços, contendo entidades, agregados e regras de negócio.

## Como Executar ▶️

1. Certifique-se de ter o Docker instalado.
2. Clone este repositório: `git clone https://github.com/mendescristian/MicroservicesProject.git`
3. Navegue até a pasta do projeto: `cd MicroservicesProject`
4. Execute `docker-compose up -d` para iniciar todos os serviços em contêineres Docker.

O Projeto ainda não está completamente finalizado, porém, está funcional.
