-- Crear base de datos
CREATE DATABASE LavacarBD;
GO

-- Usar la base de datos
USE LavacarBD;
GO

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

-----------------------------------------------------------------------------------------------------------------------------



---------------------------------------------------------------------------------------------------------------------------------------------------
--Tabla de Incapacidades y Vacaciones 
CREATE TABLE Tramites (
idTramite int identity primary key not null, 
idEmpleado nvarchar(128) not null, 
fechaInicio datetime not null, 
fechaFin datetime not null, 
Razon nvarchar(300) not null,
foreign key(idEmpleado) references AspnetUsers(Id));

--Tabla de bonificaciones y deducciones
 CREATE TABLE AjustesSalariales( 
 idAjusteSalariale int identity primary key not null, 
 monto decimal not null, 
 razon nvarchar(300) not null, 
 idEmpleado nvarchar(128) not null, 
 foreign key (idEmpleado) references AspNetUsers(Id)); 

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
-- Tabla Nomina
CREATE TABLE Nomina (
    idNomina INT IDENTITY PRIMARY KEY NOT NULL,
    idEmpleado nvarchar(128) NOT NULL,
    salarioNeto DECIMAL(10,2) NOT NULL,
    salarioBruto DECIMAL(10,2),
    fechaDePago DATE NOT NULL,
    periodoDePago NVARCHAR(50),
    horasOrdinarias INT,
    horasExtras INT,
    horasDobles INT,
    diasDispoVacaciones int not null,
	diasUtiliVacaciones int not null,
    incapacidad DECIMAL(10,2),
    tipoDeContrato NVARCHAR(50),
    estado BIT NOT NULL,
    FOREIGN KEY (idEmpleado) REFERENCES AspNetUsers(Id)
);
GO


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
select * from Movimiento
drop table Movimiento


-- Tabla Compra
CREATE TABLE Compra (
    idCompra INT IDENTITY PRIMARY KEY NOT NULL,
    idUsuario nvarchar(128) NOT NULL,
   
    idServicio INT NOT NULL,
    idReserva INT NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    fecha DATE NOT NULL,
    descripcionServicio NVARCHAR(200) NOT NULL,
    estado BIT NOT NULL,
FOREIGN KEY (idUsuario) REFERENCES AspNetUsers(Id),
  
    FOREIGN KEY (idServicio) REFERENCES Servicios(idServicio),
    FOREIGN KEY (idReserva) REFERENCES Reservas(idReserva)
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
select * from AspNetUsers

SELECT TOP 1 u.Id
FROM [dbo].[AspNetUsers] u
JOIN [dbo].[AspNetUserRoles] ur ON u.Id = ur.UserId
JOIN [dbo].[AspNetRoles] r ON ur.RoleId = r.Id
WHERE r.Name = 'Empleado'  -- Asumiendo que el rol se llama 'Empleado'
ORDER BY NEWID();  -- Esto selecciona un registro aleatorio


Insert into AspNetRoles (Id, Name) values (NEWID(),'Usuario')
Insert into AspNetRoles (Id, Name) values (NEWID(),'Empleado')
Insert into AspNetRoles (Id, Name) values (NEWID(),'Administrador')

INSERT INTO Resenias (idServicio, idCliente, calificacion, comentarios, fecha, estado)  
VALUES  
(1, '123e4567-e89b-12d3-a456-426614174000', 1, 'Excelente servicio, muy satisfecho.', '2025-02-06', 1),  
(1, '123e4567-e89b-12d3-a456-426614174000', 1, 'Muy bueno, pero hay aspectos por mejorar.', '2025-02-06', 1),  
(1, '123e4567-e89b-12d3-a456-426614174000', 1, 'Servicio promedio, esperaba más.', '2025-02-06', 1);


INSERT INTO Respuesta (idEmpleado, comentarios, fecha, estado, idResenia)  
VALUES  
('123e4567-e89b-12d3-a456-426614174000', '¡Gracias por tu reseña! Nos alegra que estés satisfecho.', '2025-02-07', 1, 3),  
('123e4567-e89b-12d3-a456-426614174000', 'Apreciamos tu comentario y trabajaremos en mejorar.', '2025-02-07', 1, 4); 
;


INSERT INTO [dbo].[AspNetUsers]  
    (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, nombre, primer_apellido, segundo_apellido,  
     UserName, estado, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount,  
     cedula, numeroCuenta, turno, puesto)  
VALUES  
    ('123e4567-e89b-12d3-a456-426614174000', 'usuario@example.com', 1, 'hashedpassword123', 'securitystamp123',  
     '1234567890', 'Juan', 'Pérez', 'Gómez', 'juanperez', 1, 1, 0, NULL, 1, 0,  
     102345678, '12345678901234567890', 'Mañana', 'Administrador');
SELECT 
    r.idResenia,
    r.idServicio,
    r.idCliente,
    r.calificacion,
    r.comentarios AS ComentarioResenia,
    r.fecha AS FechaResenia,
    r.estado AS EstadoResenia,
    rp.idRespuesta,
    rp.idEmpleado,
    rp.comentarios AS ComentarioRespuesta,
    rp.fecha AS FechaRespuesta,
    rp.estado AS EstadoRespuesta
FROM Resenias r
LEFT JOIN Respuesta rp ON r.idResenia = rp.idResenia;

select * from Respuesta
INSERT INTO Reservas (idCliente, idEmpleado, idServicio, fecha, hora, estado)  
VALUES  
('123e4567-e89b-12d3-a456-426614174000', '123e4567-e89b-12d3-a456-426614174000', 1, '2025-03-10', '10:00', 1);

select * from Reservas