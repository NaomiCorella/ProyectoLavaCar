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
    idServicio INT NOT NULL,
    fecha DATE NOT NULL,
    hora TIME NOT NULL,
    estado BIT NOT NULL,
    FOREIGN KEY (idCliente) REFERENCES AspNetUsers(Id)
    
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
VALUES ('Naomi', 'Pérez', 'Gómez', '555-1234', 'juan.perez@empresa.com', '1234567890', 'Desarrollador', 'Mañana', 1, '001122334455');


INSERT INTO Servicios (costo, nombre, descripcion, tiempoDuracion, estado)  
VALUES  
(5000.00, 'Lavado Básico', 'Lavado exterior con espuma y enjuague a presión', '30 minutos', 1),  
(8000.00, 'Lavado Completo', 'Lavado exterior e interior con aspirado y encerado', '60 minutos', 1),  
(12000.00, 'Lavado Premium', 'Lavado completo con pulido y tratamiento de pintura', '90 minutos', 1),  
(15000.00, 'Lavado y Desinfección', 'Lavado completo más sanitización con ozono', '75 minutos', 1),  
(10000.00, 'Lavado de Motor', 'Limpieza profunda del motor con desengrasante', '45 minutos', 1);  

INSERT INTO [dbo].[AspNetUsers] (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, nombre, primer_apellido, segundo_apellido, UserName, estado)  
VALUES  
('1A2B3C4D5E6F', 'juan.perez@example.com', 1, 'hashed_password_1', 'security_stamp_1', '555-1234', 'Juan', 'Pérez', 'Gómez', 'juanperez', 1),  
('7G8H9I0J1K2L', 'maria.lopez@example.com', 1, 'hashed_password_2', 'security_stamp_2', '555-5678', 'María', 'López', 'Rodríguez', 'marialopez', 1),  
('3M4N5O6P7Q8R', 'carlos.martinez@example.com', 0, 'hashed_password_3', 'security_stamp_3', '555-9012', 'Carlos', 'Martínez', 'Fernández', 'carlosmartinez', 1),  
('9S0T1U2V3W4X', 'ana.garcia@example.com', 1, 'hashed_password_4', 'security_stamp_4', '555-3456', 'Ana', 'García', 'Hernández', 'anagarcia', 1),  
('5Y6Z7A8B9C0D', 'pedro.sanchez@example.com', 0, 'hashed_password_5', 'security_stamp_5', '555-7890', 'Pedro', 'Sánchez', 'Ramírez', 'pedrosanchez', 1);  

INSERT INTO Resenias (idServicio, idCliente, calificacion, comentarios, fecha, estado)  
VALUES  
(1, '1A2B3C4D5E6F', 5, 'Excelente servicio, el auto quedó impecable.', '2024-08-20', 1),  
(2, '7G8H9I0J1K2L', 4, 'Muy buen trabajo, pero tardaron un poco más de lo esperado.', '2024-08-21', 1),  
(3, '3M4N5O6P7Q8R', 5, 'El mejor lavado que he recibido, volveré pronto.', '2024-08-22', 1),  
(4, '9S0T1U2V3W4X', 3, 'Buen servicio, pero podrían mejorar la atención al cliente.', '2024-08-23', 1),  
(5, '5Y6Z7A8B9C0D', 4, 'Lavado de motor excelente, quedé muy satisfecho.', '2024-08-24', 1);  

INSERT INTO Reservas (idCliente, idEmpleado, idServicio, fecha, hora, estado) 
VALUES 
('1A2B3C4D5E6F', 1, 2, '2024-08-27', '10:30:00', 1),
('7G8H9I0J1K2L', 1, 3, '2024-08-28', '14:00:00', 1),
('3M4N5O6P7Q8R', 1, 1, '2024-08-29', '09:15:00', 0);
select * from AspNetUsers

INSERT INTO Empleados 
(idEmpleado, nombre, primer_apellido, segundo_apellido, telefono, correo, cedula, puesto, turno, estado, contraseña, numeroCuenta)
VALUES 
(1, 'Juan', 'Pérez', 'Gómez', '123-456-7890', 'juan.perez@example.com', '123456789', 'Gerente', 'Mañana', 1, 'contraseñaSegura123', '1234567890');
