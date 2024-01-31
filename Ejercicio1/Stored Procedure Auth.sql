CREATE PROCEDURE test_AuthUser
    @Username NVARCHAR(100),
    @Password NVARCHAR(100),
    @AuthenticationResult INT OUTPUT
AS
BEGIN
    DECLARE @Result INT;
    IF EXISTS (SELECT 1 FROM test_Usuarios WHERE NombreUsuario = @Username AND Clave = @Password)
    BEGIN
        SET @Result = 1;
    END
    ELSE
    BEGIN
        SET @Result = 0;
    END

    -- Asignar el valor de @Result al parámetro de salida
    SET @AuthenticationResult = @Result;
END;
