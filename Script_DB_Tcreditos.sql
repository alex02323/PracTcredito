CREATE DATABASE Tcreditos
GO

USE [Tcreditos]

GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [nvarchar](64) NOT NULL,
	[apellidos] [nvarchar](64) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InteresBonificable]    Script Date: 9/10/2023 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InteresBonificable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Porcentaje] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_InteresBonificable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InteresSaldoMinimo]    Script Date: 9/10/2023 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InteresSaldoMinimo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Porcentaje] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Interes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 9/10/2023 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idTarjeta] [int] NOT NULL,
	[fTransaccion] [datetime] NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
	[Monto] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tarjetas]    Script Date: 9/10/2023 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tarjetas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[nombre] [nvarchar](64) NOT NULL,
	[nTarjeta] [nvarchar](64) NOT NULL,
	[fVencimiento] [nvarchar](64) NOT NULL,
	[activa] [bit] NOT NULL,
	[limite] [decimal](12, 2) NOT NULL,
	[disponible] [decimal](12, 2) NOT NULL,
	[pContado] [decimal](12, 2) NOT NULL,
	[pMinimo] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_tarjetas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([id], [nombres], [apellidos], [activo]) VALUES (1, N'Juan Antonio', N'Perez Cruz', 1)
INSERT [dbo].[Clientes] ([id], [nombres], [apellidos], [activo]) VALUES (2, N'Maria Angelica', N'Sanchez Ruiz', 1)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[InteresBonificable] ON 

INSERT [dbo].[InteresBonificable] ([id], [Porcentaje]) VALUES (1, CAST(8.25 AS Decimal(5, 2)))
SET IDENTITY_INSERT [dbo].[InteresBonificable] OFF
GO
SET IDENTITY_INSERT [dbo].[InteresSaldoMinimo] ON 

INSERT [dbo].[InteresSaldoMinimo] ([id], [Porcentaje]) VALUES (1, CAST(10.00 AS Decimal(5, 2)))
SET IDENTITY_INSERT [dbo].[InteresSaldoMinimo] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimientos] ON 

INSERT [dbo].[Movimientos] ([id], [idTarjeta], [fTransaccion], [descripcion], [Monto]) VALUES (46, 1, CAST(N'2023-10-10T00:00:00.000' AS DateTime), N'Compra-Walmart', CAST(100.00 AS Decimal(12, 2)))
INSERT [dbo].[Movimientos] ([id], [idTarjeta], [fTransaccion], [descripcion], [Monto]) VALUES (47, 1, CAST(N'2023-10-11T00:00:00.000' AS DateTime), N'Pago-Caja1', CAST(-50.00 AS Decimal(12, 2)))
SET IDENTITY_INSERT [dbo].[Movimientos] OFF
GO
SET IDENTITY_INSERT [dbo].[tarjetas] ON 

INSERT [dbo].[tarjetas] ([id], [idCliente], [nombre], [nTarjeta], [fVencimiento], [activa], [limite], [disponible], [pContado], [pMinimo]) VALUES (1, 1, N'Juan Perez', N'oDpsUz4YfZDYs3htxAMayA==mPDsAVlSe+AvMlcEYF4qhpc=', N'10/23', 1, CAST(1000.00 AS Decimal(12, 2)), CAST(950.00 AS Decimal(12, 2)), CAST(50.00 AS Decimal(12, 2)), CAST(5.00 AS Decimal(12, 2)))
INSERT [dbo].[tarjetas] ([id], [idCliente], [nombre], [nTarjeta], [fVencimiento], [activa], [limite], [disponible], [pContado], [pMinimo]) VALUES (2, 1, N'Juan Perez', N'pqkrgoBwlkF3g5ZsNdTMiQ==irOIEuWJL/5dcO12yo8p34U=', N'12/24', 1, CAST(700.00 AS Decimal(12, 2)), CAST(700.00 AS Decimal(12, 2)), CAST(0.00 AS Decimal(12, 2)), CAST(0.00 AS Decimal(12, 2)))
SET IDENTITY_INSERT [dbo].[tarjetas] OFF
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_tarjetas] FOREIGN KEY([idTarjeta])
REFERENCES [dbo].[tarjetas] ([id])
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_tarjetas]
GO
ALTER TABLE [dbo].[tarjetas]  WITH CHECK ADD  CONSTRAINT [FK_tarjetas_Clientes] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Clientes] ([id])
GO
ALTER TABLE [dbo].[tarjetas] CHECK CONSTRAINT [FK_tarjetas_Clientes]
GO
/****** Object:  StoredProcedure [dbo].[sp_cliente]    Script Date: 9/10/2023 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_cliente]
    @ID INT
AS
BEGIN
    SELECT *
    FROM Clientes
    WHERE id = @ID and activo = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_compra]    Script Date: 9/10/2023 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_compra]
	@IdTarjeta INT,
    @Descripcion NVARCHAR(50),
    @FTransaccion DATETIME,
    @Monto DECIMAL(12, 2),
	@id int OUTPUT
AS
BEGIN
    INSERT INTO Movimientos (IdTarjeta, Descripcion, FTransaccion, Monto)
    VALUES (@IdTarjeta, @Descripcion, @FTransaccion, @Monto);
	SELECT @id = SCOPE_IDENTITY()
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_movimientos]    Script Date: 9/10/2023 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_movimientos]
    @ID INT
AS
BEGIN
    SELECT *
    FROM Movimientos
    WHERE idTarjeta = @ID
	ORDER BY id DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_movimientosMesActual]    Script Date: 9/10/2023 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_movimientosMesActual]
    @ID INT
AS
BEGIN

-- Obtener el primer día del mes actual
    DECLARE @primerDiaMesActual DATETIME
    SET @primerDiaMesActual = DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)

    -- Calcular el último día del mes actual
    DECLARE @ultimoDiaMesActual DATETIME
    SET @ultimoDiaMesActual = DATEADD(DAY, -1, DATEADD(MONTH, 1, @primerDiaMesActual))

    SELECT *
    FROM Movimientos
    WHERE idTarjeta = @ID and FTransaccion >= @primerDiaMesActual AND FTransaccion <= @ultimoDiaMesActual and idTarjeta = @ID and Monto > 0
	ORDER BY id DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerMontosMes]    Script Date: 9/10/2023 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Crear el procedimiento almacenado
CREATE PROCEDURE [dbo].[sp_ObtenerMontosMes]
@ID INT
AS
BEGIN
    -- Obtener el primer día del mes actual
    DECLARE @primerDiaMesActual DATETIME
    SET @primerDiaMesActual = DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)

    -- Calcular el último día del mes actual
    DECLARE @ultimoDiaMesActual DATETIME
    SET @ultimoDiaMesActual = DATEADD(DAY, -1, DATEADD(MONTH, 1, @primerDiaMesActual))

	-- Obtener el primer día del mes anterior
    DECLARE @primerDiaMesAnterior DATETIME
    SET @primerDiaMesAnterior = DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)

    -- Calcular el último día del mes anterior
    DECLARE @ultimoDiaMesAnterior DATETIME
    SET @ultimoDiaMesAnterior = DATEADD(DAY, -1, @primerDiaMesActual)

    -- Calcular el monto total en el mes actual
    SELECT SUM(Monto) AS ContadoMesActual
    FROM Movimientos
    WHERE FTransaccion >= @primerDiaMesActual AND FTransaccion <= @ultimoDiaMesActual and idTarjeta = @ID

    ---- Calcular el monto total en el mes anterior
    --SELECT SUM(Monto) AS ContadoMesAnterior
    --FROM Movimientos
    --WHERE FTransaccion >= @primerDiaMesAnterior AND FTransaccion <= @ultimoDiaMesAnterior and idTarjeta = @ID

	 -- Calcular el monto total de compras en el mes actual
    SELECT SUM(Monto) AS ComprasMesActual
    FROM Movimientos
    WHERE FTransaccion >= @primerDiaMesActual AND FTransaccion <= @ultimoDiaMesActual and idTarjeta = @ID and Monto > 0

	 -- Calcular el monto total de compras en el mes anterior
    SELECT SUM(Monto) AS ComprasMesAnterior
    FROM Movimientos
    WHERE FTransaccion >= @primerDiaMesAnterior AND FTransaccion <= @ultimoDiaMesAnterior and idTarjeta = @ID and Monto > 0
END
GO
/****** Object:  StoredProcedure [dbo].[sp_pago]    Script Date: 9/10/2023 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_pago]
	@IdTarjeta INT,
    @Descripcion NVARCHAR(50),
    @FTransaccion DATETIME,
    @Monto DECIMAL(12, 2),
	@id int OUTPUT
AS
BEGIN
    INSERT INTO Movimientos (IdTarjeta, Descripcion, FTransaccion, Monto)
    VALUES (@IdTarjeta, @Descripcion, @FTransaccion, @Monto*-1);
	SELECT @id = SCOPE_IDENTITY()
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_tarjetas]    Script Date: 9/10/2023 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_tarjetas]
    @ID INT
AS
BEGIN
    SELECT *
    FROM tarjetas
    WHERE idCliente = @ID and activa = 1;
END;
GO
/****** Object:  Trigger [dbo].[ActualizarTarjetas]    Script Date: 9/10/2023 23:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[ActualizarTarjetas]
ON [dbo].[Movimientos] 
AFTER INSERT
AS
BEGIN
	DECLARE @Porcentaje DECIMAL (4,2)
	SELECT @Porcentaje = Porcentaje 
	FROM InteresSaldoMinimo

    UPDATE tarjetas
    SET Disponible = Disponible - Inserted.Monto,
        PContado = PContado + Inserted.Monto
    FROM tarjetas
    JOIN Inserted ON tarjetas.Id = Inserted.IdTarjeta;

	UPDATE tarjetas
	SET PMinimo = PContado * (@Porcentaje /100)
	FROM tarjetas
    JOIN Inserted ON tarjetas.Id = Inserted.IdTarjeta;
END
GO
ALTER TABLE [dbo].[Movimientos] ENABLE TRIGGER [ActualizarTarjetas]
GO
