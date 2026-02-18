use MantClientesBD;
GO
-- Procedimiento para agregar un cliente
CREATE PROCEDURE sp_AgregarCliente
    @Nombre NVARCHAR(100),
    @Email NVARCHAR(100),
    @Telefono NVARCHAR(15),
    @UsuarioCreacion NVARCHAR(50)
AS
BEGIN
    INSERT INTO Clientes (Nombre, Email, Telefono, UsuarioCreacion)
    VALUES (@Nombre, @Email, @Telefono, @UsuarioCreacion);
END;
GO
-- Procedimiento para obtener todos los clientes
CREATE PROCEDURE sp_ObtenerClientes
AS
BEGIN
    SELECT * FROM Clientes;
END;
GO
-- Procedimiento para obtener un cliente por ID
CREATE PROCEDURE sp_ObtenerClientePorId
    @Id INT
AS
BEGIN
    SELECT * FROM Clientes WHERE Id = @Id;
END;
GO
-- Procedimiento para actualizar un cliente
CREATE PROCEDURE sp_ActualizarCliente
    @Id INT,
    @Nombre NVARCHAR(100),
    @Email NVARCHAR(100),
    @Telefono NVARCHAR(15),
    @UsuarioModificacion NVARCHAR(50)
AS
BEGIN
    UPDATE Clientes
    SET Nombre = @Nombre,
        Email = @Email,
        Telefono = @Telefono,
        FechaModificacion = GETDATE(),
        UsuarioModificacion = @UsuarioModificacion
    WHERE Id = @Id;
END;
GO
-- Procedimiento para eliminar un cliente
CREATE PROCEDURE sp_EliminarCliente
    @Id INT
AS
BEGIN
    DELETE FROM Clientes WHERE Id = @Id;
END;
