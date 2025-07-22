CREATE TRIGGER TR_Auditoria_AspNetUsers
ON AspNetUsers
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'AspNetUsers',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla AspNetUsers.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO


CREATE TRIGGER TR_Auditoria_Servicios
ON Servicios
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'Servicios',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla Servicios.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO

CREATE TRIGGER TR_Auditoria_Reservas
ON Reservas
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'Reservas',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla Reservas.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO


CREATE TRIGGER TR_Auditoria_Nomina
ON Nomina
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'Nomina',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla Nomina.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO

CREATE TRIGGER TR_Auditoria_Tramites
ON Tramites
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'Tramites',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla Tramites.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO


CREATE TRIGGER TR_Auditoria_AjustesSalariales
ON AjustesSalariales
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'AjustesSalariales',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla AjustesSalariales.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO

CREATE TRIGGER TR_Auditoria_REGISTROHORAS
ON REGISTROHORAS
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'REGISTROHORAS',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla REGISTROHORAS.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO


CREATE TRIGGER TR_Auditoria_Producto
ON Producto
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'Producto',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla Producto.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO

CREATE TRIGGER TR_Auditoria_Movimiento
ON Movimiento
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'Movimiento',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla Movimiento.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO


CREATE TRIGGER TR_Auditoria_Compra
ON Compra
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'Compra',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla Compra.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO

CREATE TRIGGER TR_Auditoria_CompraServicios
ON CompraServicios
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'CompraServicios',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla CompraServicios.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO



CREATE TRIGGER TR_Auditoria_Respuesta
ON Respuesta
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'Respuesta',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla Respuesta.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO

CREATE TRIGGER TR_Auditoria_Evaluaciones
ON Evaluaciones
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'Evaluaciones',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla Evaluaciones.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO


CREATE TRIGGER TR_Auditoria_Resenias
ON Resenias
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @tipoEvento VARCHAR(50)
    SET @tipoEvento = CASE 
                        WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED) THEN 'UPDATE'
                        WHEN EXISTS(SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED) THEN 'INSERT'
                     END;

    DECLARE @fecha DATETIME = GETDATE();
    DECLARE @datosAnteriores VARCHAR(MAX) = NULL;
    DECLARE @datosPosteriores VARCHAR(MAX) = NULL;

    -- Convertimos los registros a JSON para almacenar como texto
    IF @tipoEvento = 'UPDATE'
    BEGIN
        SELECT @datosAnteriores = (
            SELECT * FROM DELETED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        ),
        @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END
    ELSE IF @tipoEvento = 'INSERT'
    BEGIN
        SELECT @datosPosteriores = (
            SELECT * FROM INSERTED FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
        );
    END

    -- Insertamos el evento en la bitácora
    INSERT INTO BITACORA_EVENTOS (
        TablaDeEvento,
        TipoDeEvento,
        FechaDeEvento,
        DescripcionDeEvento,
        StackTrace,
        DatosAnteriores,
        DatosPosteriores
    )
    VALUES (
        'Resenias',
        @tipoEvento,
        @fecha,
        'Se realizó un ' + @tipoEvento + ' en la tabla Resenias.',
        '', -- Aquí puedes añadir info del código fuente o dejarlo vacío
        @datosAnteriores,
        @datosPosteriores
    );
END;
GO




Insert into AspNetRoles (Id, Name) values (NEWID(),'Usuario')
Insert into AspNetRoles (Id, Name) values (NEWID(),'Empleado')
Insert into AspNetRoles (Id, Name) values (NEWID(),'Administrador')
go
--Procedimiento para que las nominas se generen cada mes
CREATE PROCEDURE GenerarNuevaNominaMensual
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar la nueva nómina basada en la del mes anterior
    INSERT INTO Nomina (
        idEmpleado, 
        salarioBruto, 
        salarioNeto, 
        fechaDePago, 
        periodoDePago, 
        horasOrdinarias, 
        horasExtras, 
        horasDobles, 
        diasDispoVacaciones, 
        diasUtiliVacaciones, 
        incapacidad, 
        tipoDeContrato, 
        estado, 
        totalBono, 
        totalDedu, 
        deduccionCCSS, 
        deduccionISR, 
        bonoHorasExtra
    )
    SELECT 
        n.idEmpleado, 
        n.salarioBruto, 
        0, 
        DATEADD(MONTH, 1, n.fechaDePago) AS fechaDePago, 
        FORMAT(DATEADD(MONTH, 1, n.fechaDePago), 'yyyy-MM') AS periodoDePago, 
        n.horasOrdinarias, 
        0 AS horasExtras, 
        0 AS horasDobles, 
        n.diasDispoVacaciones, 
        n.diasUtiliVacaciones-2, 
        NULL AS incapacidad, 
        n.tipoDeContrato, 
        1 AS estado,  -- Activo
        0 AS totalBono, 
        0 AS totalDedu, 
        0 AS deduccionCCSS, 
        0 AS deduccionISR, 
        0 AS bonoHorasExtra
    FROM Nomina n
    WHERE n.fechaDePago = (SELECT MAX(fechaDePago) 
                           FROM Nomina 
                           WHERE idEmpleado = n.idEmpleado);

END;
GO
-- EXEC GenerarNuevaNominaMensual; esto hay que hacerlo como un job

---trigger para desactivar las nominas pasadas
CREATE TRIGGER TR_DesactivarNominasAntiguas
ON Nomina
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

  
    UPDATE n
    SET estado = 0
    FROM Nomina n
    WHERE FORMAT(n.fechaDePago, 'yyyy-MM') <> FORMAT(GETDATE(), 'yyyy-MM')
    AND estado = 1; 

    PRINT 'Nóminas anteriores desactivadas correctamente.';
END;
GO
CREATE TRIGGER trg_InsertReserva
ON Reservas
AFTER INSERT
AS
BEGIN
    -- Variables para almacenar el ID del empleado aleatorio
    DECLARE @idEmpleado NVARCHAR(128);

    -- Seleccionar un empleado aleatorio con el rol "Empleado"
    SELECT TOP 1 @idEmpleado = u.Id
    FROM [dbo].[AspNetUsers] u
    JOIN [dbo].[AspNetUserRoles] ur ON u.Id = ur.UserId
    JOIN [dbo].[AspNetRoles] r ON ur.RoleId = r.Id
    WHERE r.Name = 'Empleado' -- Filtramos por el rol "Empleado"
    ORDER BY NEWID(); -- Aleatorio

    -- Actualizamos la fila insertada en la tabla Reservas para asignar el idEmpleado
    UPDATE Reservas
    SET idEmpleado = @idEmpleado
    FROM Reservas r
    INNER JOIN inserted i ON r.idReserva = i.idReserva;
END;
GO
