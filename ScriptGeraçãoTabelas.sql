CREATE TABLE endereco (
    id INT PRIMARY KEY,
    descricao VARCHAR(255),
    cep VARCHAR(10)
);
CREATE TABLE vendedor (
    id INT PRIMARY KEY,
    endereco_id INT FOREIGN KEY REFERENCES endereco(id),
    nome_fantasia VARCHAR(100),
    razao_social VARCHAR(100),
    cnpj VARCHAR(18),
    email VARCHAR(70),
    senha VARCHAR(25),
    comissao DECIMAL(3,2)
);
CREATE TABLE categoria (
    id INT PRIMARY KEY,
    nome VARCHAR(50),
    descricao VARCHAR(255)
);
CREATE TABLE produto (
    id INT PRIMARY KEY,
    vendedor_id INT FOREIGN KEY REFERENCES vendedor(id),
    categoria_id INT FOREIGN KEY REFERENCES categoria(id),
    descricao VARCHAR(255),
    preco DECIMAL(10,2),
    imagem VARCHAR(200),
    status BIT,
    CONSTRAINT fk_produto_vendedor FOREIGN KEY (vendedor_id) REFERENCES vendedor(id),
    CONSTRAINT fk_produto_categoria FOREIGN KEY (categoria_id) REFERENCES categoria(id)
);
CREATE TABLE cliente (
    id INT PRIMARY KEY,
    nome NVARCHAR(256) NULL,
    cpf BIGINT NULL,
    email NVARCHAR(70) NULL,
    senha NVARCHAR(25) NULL
);
CREATE TABLE status_carrinho (
    id INT PRIMARY KEY,
    nome VARCHAR(50),
    descricao VARCHAR(255)
);
CREATE TABLE carrinho (
    id INT PRIMARY KEY,
    cliente_id INT FOREIGN KEY REFERENCES cliente(id),
    status_carrinho_id INT FOREIGN KEY REFERENCES status_carrinho(id),
    data_pedido DATE NULL,
    valor_total DECIMAL(10,2) NULL
);
CREATE TABLE item_carrinho (
    id INT PRIMARY KEY,
    carrinho_id INT FOREIGN KEY REFERENCES carrinho(id),
    produto_id INT FOREIGN KEY REFERENCES produto(id),
    quantidade INT,
    total DECIMAL(10,2)
);
