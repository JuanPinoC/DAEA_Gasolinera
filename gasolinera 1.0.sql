USE [master]
GO
/****** Object:  Database [Gasolinera]    Script Date: 5/11/2018 18:41:21 ******/
CREATE DATABASE [Gasolinera] ON  PRIMARY 
( NAME = N'Gasolinera', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Gasolinera.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Gasolinera_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Gasolinera_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Gasolinera] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Gasolinera].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Gasolinera] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Gasolinera] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Gasolinera] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Gasolinera] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Gasolinera] SET ARITHABORT OFF 
GO
ALTER DATABASE [Gasolinera] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Gasolinera] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Gasolinera] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Gasolinera] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Gasolinera] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Gasolinera] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Gasolinera] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Gasolinera] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Gasolinera] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Gasolinera] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Gasolinera] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Gasolinera] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Gasolinera] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Gasolinera] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Gasolinera] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Gasolinera] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Gasolinera] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Gasolinera] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Gasolinera] SET  MULTI_USER 
GO
ALTER DATABASE [Gasolinera] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Gasolinera] SET DB_CHAINING OFF 
GO
USE [Gasolinera]
GO
/****** Object:  Table [dbo].[Boleta]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boleta](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[venta] [int] NULL,
	[dni] [varchar](50) NULL,
	[total] [float] NULL,
 CONSTRAINT [PK_Boleta] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[tipo_doc] [varchar](50) NULL,
	[documento] [varchar](20) NULL,
	[nom_ape] [varchar](100) NULL,
	[direccion] [varchar](100) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contribuyente]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contribuyente](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[empresa] [varchar](100) NULL,
	[ruc] [varchar](50) NULL,
	[departamento] [varchar](50) NULL,
	[provincia] [varchar](50) NULL,
	[distrito] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[igv] [float] NULL,
	[impresora] [varchar](50) NULL,
 CONSTRAINT [PK_Contribuyente] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[venta] [int] NULL,
	[raz_soc] [varchar](50) NULL,
	[ruc] [varchar](50) NULL,
	[pretotal] [float] NULL,
	[igv] [float] NULL,
	[total] [float] NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[precio] [float] NULL,
	[cantidad] [float] NULL,
	[medida] [varchar](50) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[dni] [varchar](8) NOT NULL,
	[nom_ape] [varchar](100) NULL,
	[tipo] [varchar](50) NULL,
	[nickname] [varchar](100) NULL,
	[password] [varchar](127) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [int] NULL,
	[producto] [int] NULL,
	[cantidad] [float] NULL,
	[fecha] [datetime] NULL,
	[contribuyente] [int] NULL,
	[cliente] [int] NULL,
	[sede] [varchar](50) NULL,
	[placa] [varchar](50) NULL,
	[observacion] [varchar](200) NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Boleta]  WITH CHECK ADD  CONSTRAINT [FK_Boleta_Venta] FOREIGN KEY([venta])
REFERENCES [dbo].[Venta] ([codigo])
GO
ALTER TABLE [dbo].[Boleta] CHECK CONSTRAINT [FK_Boleta_Venta]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Venta] FOREIGN KEY([venta])
REFERENCES [dbo].[Venta] ([codigo])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Venta]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([cliente])
REFERENCES [dbo].[Cliente] ([codigo])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Contribuyente] FOREIGN KEY([contribuyente])
REFERENCES [dbo].[Contribuyente] ([codigo])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Contribuyente]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Producto] FOREIGN KEY([producto])
REFERENCES [dbo].[Producto] ([codigo])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Producto]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Usuario] FOREIGN KEY([usuario])
REFERENCES [dbo].[Usuario] ([codigo])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[deleteBoleta]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteBoleta]
	@codigo int
	AS 
	DELETE FROM dbo.Boleta
		WHERE codigo = @codigo;
GO
/****** Object:  StoredProcedure [dbo].[deleteCliente]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteCliente]
	@codigo int
	AS 
	DELETE FROM dbo.Cliente
		WHERE codigo = @codigo;
GO
/****** Object:  StoredProcedure [dbo].[deleteContribuyente]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteContribuyente]
	@codigo int
	AS 
	DELETE FROM dbo.Contribuyente
		WHERE codigo = @codigo;
GO
/****** Object:  StoredProcedure [dbo].[deleteFactura]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteFactura]
	@codigo int
	AS 
	DELETE FROM dbo.Factura
		WHERE codigo = @codigo;
GO
/****** Object:  StoredProcedure [dbo].[deleteProducto]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteProducto]
	@codigo int
	AS 
	DELETE FROM dbo.Producto 
		WHERE codigo = @codigo;
GO
/****** Object:  StoredProcedure [dbo].[deleteUsuario]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteUsuario]
	@codigo int
	AS 
	DELETE FROM dbo.Usuario 
		WHERE codigo = @codigo;
GO
/****** Object:  StoredProcedure [dbo].[deleteVenta]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteVenta]
	@codigo int
	AS 
	DELETE FROM dbo.Venta
		WHERE codigo = @codigo;
GO
/****** Object:  StoredProcedure [dbo].[insertBoleta]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertBoleta]
	@venta int,
	@dni nvarchar(50),
	@total float
	AS INSERT INTO dbo.Boleta(venta,dni,total) 
	VALUES (@venta,@dni,@total)
	SELECT SCOPE_IDENTITY() AS NuevoCodigo;
GO
/****** Object:  StoredProcedure [dbo].[insertCliente]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertCliente]
	@tipo_doc nvarchar(50),
	@documento nvarchar(20),
	@nom_ape nvarchar(100),
	@direccion nvarchar(100)
	AS INSERT INTO dbo.Cliente (tipo_doc,documento,nom_ape,direccion) 
	VALUES (@tipo_doc,@documento,@nom_ape,@direccion)
	SELECT SCOPE_IDENTITY() AS NuevoCodigo;
GO
/****** Object:  StoredProcedure [dbo].[insertContribuyente]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertContribuyente]
	@empresa nvarchar(100),
	@ruc nvarchar(50),
	@departamento nvarchar(50),
	@provincia nvarchar(50),
	@distrito nvarchar(50),
	@direccion nvarchar(50),
	@igv float,
	@impresora nvarchar(50)
	AS INSERT INTO dbo.Contribuyente(empresa,ruc,departamento,provincia,distrito,direccion,igv,impresora) 
	VALUES (@empresa,@ruc,@departamento,@provincia,@distrito,@direccion,@igv,@impresora)
	SELECT SCOPE_IDENTITY() AS NuevoCodigo;
GO
/****** Object:  StoredProcedure [dbo].[insertFactura]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertFactura]
	@venta int,
	@raz_soc nvarchar(50),
	@ruc nvarchar(50),
	@pretotal float,
	@igv float,
	@total float
	AS INSERT INTO dbo.Factura(venta,raz_soc,ruc,pretotal,igv,total) 
	VALUES (@venta,@raz_soc,@ruc,@pretotal,@igv,@total)
	SELECT SCOPE_IDENTITY() AS NuevoCodigo
GO
/****** Object:  StoredProcedure [dbo].[insertProducto]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertProducto]
	@nombre nvarchar(100),
	@precio float,
	@cantidad float,
	@medida nvarchar(50)
	AS INSERT INTO dbo.Producto (nombre,precio,cantidad,medida) 
	VALUES (@nombre,@precio,@cantidad,@medida)
	SELECT SCOPE_IDENTITY() AS NuevoCodigo;
GO
/****** Object:  StoredProcedure [dbo].[insertUsuario]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertUsuario]
	@dni nvarchar(8),
	@nom_ape nvarchar(100),
	@tipo nvarchar(50),
	@nickname nvarchar(100),
	@password nvarchar(127)
	AS INSERT INTO dbo.Usuario (dni,nom_ape,tipo,nickname,password) 
	VALUES (@dni,@nom_ape,@tipo,@nickname,@password)
	SELECT SCOPE_IDENTITY() AS Nuevocodigo;
GO
/****** Object:  StoredProcedure [dbo].[insertVenta]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertVenta]
	@usuario int,
	@producto int,
	@cantidad float,
	@fecha datetime,
	@contribuyente int,
	@cliente int,
	@sede nvarchar(50),
	@placa nvarchar(50),
	@observacion nvarchar(200)
	AS INSERT INTO dbo.Venta(usuario,producto,cantidad,fecha,contribuyente,cliente,sede,placa,observacion) 
	VALUES (@usuario,@producto,@cantidad,@fecha,@contribuyente,@cliente,@sede,@placa,@observacion)
	SELECT SCOPE_IDENTITY() AS Nuevocodigo;
GO
/****** Object:  StoredProcedure [dbo].[updateBoleta]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateBoleta]
	@codigo int,
	@venta int,
	@dni nvarchar(50),
	@total float
	AS UPDATE dbo.Boleta SET 
		venta = @venta,
		dni = @dni,
		total = @total
	WHERE codigo = @codigo;
GO
/****** Object:  StoredProcedure [dbo].[updateCliente]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateCliente]
	@codigo int,
	@tipo_doc nvarchar(50),
	@documento nvarchar(20),
	@nom_ape nvarchar(100),
	@direccion nvarchar(100)
	AS UPDATE dbo.Cliente SET 
		tipo_doc = @tipo_doc,
		documento = @documento,
		nom_ape = @nom_ape,
		direccion = @direccion
	WHERE codigo = @codigo;
GO
/****** Object:  StoredProcedure [dbo].[updateContribuyente]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateContribuyente]
	@codigo int,
	@empresa nvarchar(100),
	@ruc nvarchar(50),
	@departamento nvarchar(50),
	@provincia nvarchar(50),
	@distrito nvarchar(50),
	@direccion nvarchar(50),
	@igv float,
	@impresora nvarchar(50)
	AS UPDATE dbo.Contribuyente SET 
		empresa = @empresa,
		ruc = @ruc,
		departamento = @departamento,
		provincia = @provincia,
		distrito = @distrito,
		direccion = @direccion,
		igv = @igv,
		impresora = @impresora
	WHERE codigo = @codigo;
GO
/****** Object:  StoredProcedure [dbo].[updateFactura]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateFactura]
	@codigo int,
	@venta int,
	@raz_soc nvarchar(50),
	@ruc nvarchar(50),
	@pretotal float,
	@igv float,
	@total float
	AS UPDATE dbo.Factura SET 
		venta = @venta,
		raz_soc = @raz_soc,
		ruc = @ruc,
		pretotal = @pretotal,
		igv = @igv,
		total = @total
	WHERE codigo = @codigo;
GO
/****** Object:  StoredProcedure [dbo].[updateProducto]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateProducto]
	@codigo int,
	@nombre nvarchar(100),
	@precio float,
	@cantidad float,
	@medida nvarchar(50)
	AS UPDATE dbo.Producto SET 
		nombre = @nombre,
		precio = @precio,
		cantidad = @cantidad,
		medida = @medida
	WHERE codigo = @codigo;
GO
/****** Object:  StoredProcedure [dbo].[updateUsuario]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateUsuario]
	@codigo int,
	@dni nvarchar(100),
	@nom_ape nvarchar(100),
	@tipo nvarchar(50),
	@nickname nvarchar(100),
	@password nvarchar(127)
	AS UPDATE dbo.Usuario SET 
		dni=@dni,
		nom_ape=@nom_ape,
		tipo=@tipo,
		nickname=@nickname,
		password=@password
	WHERE codigo=@codigo;
GO
/****** Object:  StoredProcedure [dbo].[updateVenta]    Script Date: 5/11/2018 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateVenta]
	@codigo int,
	@usuario int,
	@producto int,
	@cantidad float,
	@fecha datetime,
	@contribuyente int,
	@cliente int,
	@sede nvarchar(50),
	@placa nvarchar(50),
	@observacion nvarchar(200)
	AS UPDATE dbo.Venta SET 
		usuario = @usuario,
		producto = @producto,
		cantidad = @cantidad,
		fecha = @fecha,
		contribuyente = @contribuyente,
		cliente = @cliente,
		sede = @sede,
		placa = @placa,
		observacion = @observacion
	WHERE codigo = @codigo;
GO
USE [master]
GO
ALTER DATABASE [Gasolinera] SET  READ_WRITE 
GO
