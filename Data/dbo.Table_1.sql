CREATE TABLE [Pim8].[Cliente]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [nome] VARCHAR(256) NULL, 
    [cpf] BIGINT NULL, 
    [email] VARCHAR(70) NULL, 
    [senha] VARCHAR(25) NULL, 
    [carrinho] NCHAR(10) NULL
)
CREATE TABLE [Pim8].[Carrinho]
(   [cliente_id] INT NOT NULL, 
	[Id] INT NOT NULL PRIMARY KEY, 
    [data_pedido] DATE NULL, 
    [valor_total] FLOAT(7,2) NULL
)
