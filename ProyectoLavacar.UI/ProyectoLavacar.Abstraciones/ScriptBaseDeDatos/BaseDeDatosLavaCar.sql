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
	 estado BIT NOT NULL
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

--------------------------------------Secuencia del IDEMPLEADO-------------------------------------------------------------------
CREATE SEQUENCE Empleados_Seq
AS INT
START WITH 1  
INCREMENT BY 1;
--------------------------------------------------------------------------------------------------------------------------------

-- Tabla Empleados
CREATE TABLE Empleados (
    idEmpleado  int  PRIMARY KEY NOT NULL,
    nombre NVARCHAR(50) NOT NULL,
    primer_apellido NVARCHAR(50) NOT NULL,
    segundo_apellido NVARCHAR(50),
    telefono NVARCHAR(15),
    correo NVARCHAR(100),
    cedula NVARCHAR(20),
    puesto NVARCHAR(50),
    turno NVARCHAR(20),
    estado BIT NOT NULL,
    numeroCuenta NVARCHAR(20)
);
GO
----------------------------------------------------------Triggger de id de Empleado-------------------------------------
CREATE TRIGGER trg_InsteadOfInsertEmpleados
ON Empleados
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @idEmpleado INT,
            @nombre NVARCHAR(50),
            @primer_apellido NVARCHAR(50),
            @segundo_apellido NVARCHAR(50),
            @telefono NVARCHAR(15),
            @correo NVARCHAR(100),
            @cedula NVARCHAR(20),
            @puesto NVARCHAR(50),
            @turno NVARCHAR(20),
            @estado BIT,
            @numeroCuenta NVARCHAR(20);

  
    SELECT @nombre = nombre,
           @primer_apellido = primer_apellido,
           @segundo_apellido = segundo_apellido,
           @telefono = telefono,
           @correo = correo,
           @cedula = cedula,
           @puesto = puesto,
           @turno = turno,
           @estado = estado,
           @numeroCuenta = numeroCuenta
    FROM INSERTED;

 
    SELECT @idEmpleado = NEXT VALUE FOR Empleados_Seq;


    INSERT INTO Empleados (idEmpleado, nombre, primer_apellido, segundo_apellido, telefono, correo, cedula, puesto, turno, estado, numeroCuenta)
    VALUES (@idEmpleado, @nombre, @primer_apellido, @segundo_apellido, @telefono, @correo, @cedula, @puesto, @turno, @estado, @numeroCuenta);
END;
GO

---------------------------------------------------------------------------------------------------------------------------------------------------

------------------------Trigger de creacion de usuarios(empleados en la tabla de aspnertuser)------------------------------------------------------
CREATE TRIGGER trg_InsertEmpleados
ON Empleados
AFTER INSERT
AS
BEGIN
    DECLARE @idEmpleado INT,
            @nombre NVARCHAR(50),
            @primer_apellido NVARCHAR(50),
            @segundo_apellido NVARCHAR(50),
            @correo NVARCHAR(100),
            @estado BIT;

 
    SELECT @idEmpleado = idEmpleado,
           @nombre = nombre,
           @primer_apellido = primer_apellido,
           @segundo_apellido = segundo_apellido,
           @correo = correo,
           @estado = estado
    FROM INSERTED;


    INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, UserName, nombre, primer_apellido, segundo_apellido, estado)
    VALUES (CAST(@idEmpleado AS NVARCHAR(128)), 
            @correo, 
            0,  
            @correo,  
            @nombre,
            @primer_apellido,
            @segundo_apellido,
            @estado);
END;
GO
---------------------------------------------------------------------------------------------------------------------------------------------------

-- Tabla Servicios
CREATE TABLE Servicios (
    idServicio INT IDENTITY PRIMARY KEY NOT NULL,
    costo DECIMAL(10,2) NOT NULL,
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(200)NOT NULL,
    tiempoDuracion NVARCHAR(20)NOT NULL,
    estado BIT NOT NULL
);
GO

-- Tabla Reservas
CREATE TABLE Reservas (
    idReserva INT IDENTITY PRIMARY KEY NOT NULL,
    idCliente [nvarchar](128) NOT NULL,
    idEmpleado INT NOT NULL,
    idServicio INT NOT NULL,
    fecha DATE NOT NULL,
    hora TIME NOT NULL,
    estado BIT NOT NULL,
    FOREIGN KEY (idCliente) REFERENCES AspNetUsers(Id),
    FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado),
    FOREIGN KEY (idServicio) REFERENCES Servicios(idServicio)
);
GO

-- Tabla Nomina
CREATE TABLE Nomina (
    idNomina INT IDENTITY PRIMARY KEY NOT NULL,
    idEmpleado INT NOT NULL,
    salarioNeto DECIMAL(10,2) NOT NULL,
    salarioBruto DECIMAL(10,2),
    fechaDePago DATE NOT NULL,
    periodoDePago NVARCHAR(50)  NOT NULL,
    horasOrdinarias INT  NOT NULL,
    horasExtras INT  NOT NULL,
    horasDobles INT  NOT NULL,
    bonos DECIMAL(10,2) NOT NULL,
    deducciones DECIMAL(10,2) NOT NULL,
    vacaciones DECIMAL(10,2) NOT NULL,
    incapacidad DECIMAL(10,2) NOT NULL,
    tipoDeContrato NVARCHAR(50) NOT NULL,
    estado BIT NOT NULL,
    FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado)
);
GO

-- Tabla Producto
CREATE TABLE Producto (
    idProducto INT IDENTITY PRIMARY KEY NOT NULL,
    nombre NVARCHAR(100) NOT NULL,
    categoria NVARCHAR(50) NOT NULL,
    marca NVARCHAR(50) NOT NULL,
    precioUnitario DECIMAL(10,2) NOT NULL,
    cantidadDisponible INT NOT NULL,
    estado BIT NOT NULL
);
GO

-- Tabla Inventario
CREATE TABLE Inventario (
    idInventario INT IDENTITY PRIMARY KEY NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    estado BIT NOT NULL
);
GO

-- Tabla Linea
CREATE TABLE Linea (
    idLinea INT IDENTITY PRIMARY KEY NOT NULL,
    idEmpleado INT NOT NULL,
    idInventario INT NOT NULL,
    idProducto INT NOT NULL,
    cantidad INT NOT NULL,
    totalLinea DECIMAL(10,2) NOT NULL,
    estado BIT NOT NULL,
    FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado),
    FOREIGN KEY (idInventario) REFERENCES Inventario(idInventario),
    FOREIGN KEY (idProducto) REFERENCES Producto(idProducto)
);
GO

-- Tabla Compra
CREATE TABLE Compra (
    idCompra INT IDENTITY PRIMARY KEY NOT NULL,
    idEmpleado INT NOT NULL,
    idCliente [nvarchar](128) NOT NULL,
    idServicio INT NOT NULL,
    idReserva INT NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    fecha DATE NOT NULL,
    descripcionServicio NVARCHAR(200) NOT NULL,
    estado BIT NOT NULL,
    FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado),
   FOREIGN KEY (idCliente) REFERENCES AspNetUsers(Id),
    FOREIGN KEY (idServicio) REFERENCES Servicios(idServicio),
    FOREIGN KEY (idReserva) REFERENCES Reservas(idReserva)
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
    idEmpleado INT NOT NULL,
    fechaEvaluacion DATE NOT NULL DEFAULT GETDATE() ,
    calificacion INT CHECK (calificacion BETWEEN 1 AND 10),
    comentarios NVARCHAR(MAX)  NOT NULL,
    areaMejora NVARCHAR(MAX)  NOT NULL,
    recomendaciones NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado)
);
GO
 


-----Ejemplo de funcionamiento del trigger
INSERT INTO Empleados (nombre, primer_apellido, segundo_apellido, telefono, correo, cedula, puesto, turno, estado, numeroCuenta)
VALUES ('Naomi', 'P�rez', 'G�mez', '555-1234', 'juan.perez@empresa.com', '1234567890', 'Desarrollador', 'Ma�ana', 1, '001122334455');


select * from AspNetUsers
