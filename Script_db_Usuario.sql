create database db_usuario;
GO


use db_usuario;

create table Usuario(
	IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
	NomeCompleto VARCHAR(200) NOT NULL,
	CpfUsuario VARCHAR(11) NOT NULL,
	TelefoneUsuario VARCHAR(11) NOT NULL,
	EmailUsuario VARCHAR(200) NOT NULL,
	DataDeCriacao DATETIME NOT NULL DEFAULT GETDATE(),
	StatusUsuario int NOT NULL
);




