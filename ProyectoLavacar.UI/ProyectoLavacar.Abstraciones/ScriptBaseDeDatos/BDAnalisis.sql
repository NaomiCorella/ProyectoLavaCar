
-- Crear base de datos
CREATE DATABASE LavacarBD;
GO

-- Usar la base de datos
USE LavacarBD;
GO
-------------------------------------------------------------------------------------------------------------------------------------
--Usuario--

---------------IDENTITY / Tabla de CLientes
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/11/2024 13:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/11/2024 13:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/11/2024 13:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/11/2024 13:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/11/2024 13:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	nombre NVARCHAR(50) NOT NULL,
    primer_apellido NVARCHAR(50) NOT NULL,
    segundo_apellido NVARCHAR(50) NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	 estado BIT NOT NULL,	
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	cedula int , 
	numeroCuenta  nvarchar(30),
	turno nvarchar(30),
	puesto nvarchar(50)
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
-------------------------------------------------------------------------------------------------------------------------------------
--Modulo Reservas--

-- Tabla Servicios
CREATE TABLE Servicios (
    idServicio INT IDENTITY PRIMARY KEY NOT NULL,
    costo DECIMAL(10,2) NOT NULL,
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(200)NOT NULL,
	 modalidad VARCHAR(100) NOT NULL,
    tiempoDuracion NVARCHAR(20)NOT NULL,
    estado BIT NOT NULL
);
GO

-- Tabla Reservas
CREATE TABLE Reservas (
    idReserva INT IDENTITY PRIMARY KEY NOT NULL,
    idCliente [nvarchar](128) NOT NULL,
 idEmpleado [nvarchar](128) NOT NULL,
    idServicio INT NOT NULL,
    fecha DATE NOT NULL,
    hora TIME NOT NULL,
    estado BIT NOT NULL,
    FOREIGN KEY (idCliente) REFERENCES AspNetUsers(Id),
	 FOREIGN KEY (idEmpleado) REFERENCES AspNetUsers(Id)
    
);
GO

-------------------------------------------------------------------------------------------------------------------------------------
--Modulo Nomina--


-- Tabla Nomina
CREATE TABLE Nomina (
    idNomina INT IDENTITY PRIMARY KEY NOT NULL,
    idEmpleado NVARCHAR(128) NOT NULL,
    salarioBruto DECIMAL(10,2) NOT NULL,
    salarioNeto DECIMAL(10,2) NOT NULL,
    fechaDePago DATE NOT NULL,
    periodoDePago NVARCHAR(50),
    horasOrdinarias INT,
    horasExtras INT,
    horasDobles INT,
    diasDispoVacaciones INT NOT NULL,
    diasUtiliVacaciones INT NOT NULL,
    incapacidad DECIMAL(10,2),
    tipoDeContrato NVARCHAR(50),
    estado BIT NOT NULL,
    totalBono DECIMAL(10,2) NOT NULL,
    totalDedu DECIMAL(10,2) NOT NULL,
    deduccionCCSS DECIMAL(10,2),     
    deduccionISR DECIMAL(10,2),  
	bonoHorasExtra decimal(10,2)
    FOREIGN KEY (idEmpleado) REFERENCES AspNetUsers(Id)
);
GO


--Tabla de Incapacidades y Vacaciones 
CREATE TABLE Tramites (
idTramite int identity primary key not null, 
idNomina int not null, 
fechaInicio datetime not null, 
duracion int not null, 
Razon nvarchar(300) not null,
tipo nvarchar(100) not null,
estado int,
aseguradora nvarchar(300)
foreign key(idNomina) references Nomina(idNomina));

--Tabla de bonificaciones y deducciones
 CREATE TABLE AjustesSalariales( 
 idAjusteSalarial int identity primary key not null, 
 monto decimal not null, 
 razon nvarchar(300) not null, 
 idNomina int not null, 
tipo nvarchar(100) not null,
foreign key(idNomina) references Nomina(idNomina));

CREATE TABLE REGISTROHORAS(
idRegistro int identity primary key not null, 
HoraEntrada datetime not null,
HoraSalida datetime not null, 
 idEmpleado NVARCHAR(128) NOT NULL,
 totalHoras int not null,
 estado bit not null,
    FOREIGN KEY (idEmpleado) REFERENCES AspNetUsers(Id)
)


--Procedimiento para que las nominas se generen cada mes
CREATE PROCEDURE GenerarNuevaNominaMensual
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar la nueva n�mina basada en la del mes anterior
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

    PRINT 'N�minas anteriores desactivadas correctamente.';
END;
GO

-------------------------------------------------------------------------------------------------------------------------------------
--Modulo Inventario--

-- Tabla Producto
CREATE TABLE Producto (
    idProducto INT IDENTITY PRIMARY KEY NOT NULL,
    nombre NVARCHAR(100) NOT NULL,
    categoria NVARCHAR(50) NOT NULL,
    precioUnitario DECIMAL(10,2) NOT NULL,
    cantidadDisponible INT NOT NULL,
    estado BIT NOT NULL
);
GO

Create Table Movimiento(
idMovimiento int identity primary key not null, 
idProducto int not null, 
nombre nvarchar(20) not null, 
cantidad int not null,
fecha Datetime not null,
foreign key (idProducto) references Producto(idProducto)

);

-------------------------------------------------------------------------------------------------------------------------------------
--Modulo NotificacionCompra-- ?????
-- Tabla Compra
CREATE TABLE Compra (
    idCompra uniqueidentifier PRIMARY KEY NOT NULL,
    idCliente nvarchar(128) NOT NULL, 
    total DECIMAL(10,2) NOT NULL,
    fecha DATE NOT NULL,
    descripcionServicio NVARCHAR(200) NOT NULL,
    estado BIT NOT NULL,
FOREIGN KEY (idCliente) REFERENCES AspNetUsers(Id),
);
GO
CREATE TABLE CompraServicios (
    idCompra uniqueidentifier,
	idCompraServicios INT IDENTITY PRIMARY KEY NOT NULL,
    idServicio INT,
    FOREIGN KEY (idCompra) REFERENCES Compra(idCompra),
    FOREIGN KEY (idServicio) REFERENCES Servicios(idServicio)
);

select * from CompraServicios
-------------------------------------------------------------------------------------------------------------------------------------
--Modulo Resenias-- 


-- Tabla Resenias
CREATE TABLE Resenias (
    idResenia INT IDENTITY PRIMARY KEY NOT NULL,
    idServicio INT NOT NULL,
    idCliente nvarchar (128) NOT NULL,
    calificacion INT CHECK (calificacion BETWEEN 1 AND 5)  NOT NULL,
    comentarios NVARCHAR(MAX)  NOT NULL,
    fecha DATE NOT NULL,
    estado BIT NOT NULL,

    FOREIGN KEY (idServicio) REFERENCES Servicios(idServicio),
   FOREIGN KEY (idCliente) REFERENCES AspNetUsers(Id),

);
GO
-- Tabla Respuestas de resenia
CREATE TABLE Respuesta (
    idRespuesta INT IDENTITY PRIMARY KEY NOT NULL,
    idEmpleado nvarchar (128) NOT NULL,
    comentarios NVARCHAR(MAX)  NOT NULL,
    fecha DATE NOT NULL,
    estado BIT NOT NULL,
	idResenia int not null, 
   FOREIGN KEY (idEmpleado) REFERENCES AspNetUsers(Id),
      FOREIGN KEY (idResenia) REFERENCES Resenias(idResenia),
);
GO

-------------------------------------------------------------------------------------------------------------------------------------
--Modulo Reportes-- 

-- Tabla Evaluaciones
CREATE TABLE Evaluaciones (
    idEvaluacion INT IDENTITY PRIMARY KEY NOT NULL,
    idEmpleado nvarchar(128) NOT NULL,
    fechaEvaluacion DATE NOT NULL DEFAULT GETDATE() ,
    calificacion INT CHECK (calificacion BETWEEN 1 AND 10),
    comentarios NVARCHAR(MAX)  NOT NULL,
    areaMejora NVARCHAR(MAX)  NOT NULL,
    recomendaciones NVARCHAR(MAX) NOT NULL,
FOREIGN KEY (idEmpleado) REFERENCES AspNetUsers(Id)
);
GO
-------------------------------------------------------------------------------------------------------------------------------------
--Modulo Triggers e inster NECESARIOS--

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

Insert into AspNetRoles (Id, Name) values (NEWID(),'Usuario')
Insert into AspNetRoles (Id, Name) values (NEWID(),'Empleado')
Insert into AspNetRoles (Id, Name) values (NEWID(),'Administrador')