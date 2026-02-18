create database MantClientesBD;
GO
use MantClientesBD;
GO
--drop TABLE Clientes;
CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(15) NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(), 
    UsuarioCreacion NVARCHAR(50) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion NVARCHAR(50) NULL
);
GO
