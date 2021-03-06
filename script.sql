USE [Hotel6]
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 6/10/2018 15:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[id_cargo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[id_cargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 6/10/2018 15:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[id_empleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](150) NULL,
	[apellido] [varchar](150) NULL,
	[edad] [int] NULL,
	[direccion] [varchar](150) NULL,
	[telefono] [varchar](50) NULL,
	[id_cargo] [int] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Habitaciones]    Script Date: 6/10/2018 15:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habitaciones](
	[id_habitaciones] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](50) NULL,
	[precio] [money] NULL,
	[cantidad] [int] NULL,
	[id_promociones] [int] NULL,
 CONSTRAINT [PK_Habitaciones] PRIMARY KEY CLUSTERED 
(
	[id_habitaciones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Huesped]    Script Date: 6/10/2018 15:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Huesped](
	[id_huesped] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](150) NULL,
	[direccion] [varchar](150) NULL,
	[dui] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[correo] [varchar](150) NULL,
	[id_tipo_huesped] [int] NULL,
 CONSTRAINT [PK_Huesped] PRIMARY KEY CLUSTERED 
(
	[id_huesped] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promociones]    Script Date: 6/10/2018 15:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promociones](
	[id_promocion] [int] IDENTITY(1,1) NOT NULL,
	[promocion] [varchar](50) NULL,
	[descuento] [money] NULL,
 CONSTRAINT [PK_Promociones] PRIMARY KEY CLUSTERED 
(
	[id_promocion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 6/10/2018 15:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[id_reservas] [int] IDENTITY(1,1) NOT NULL,
	[numero_habitaciones] [int] NULL,
	[fecha_entrada] [date] NULL,
	[fecha_salida] [date] NULL,
	[dias] [int] NULL,
	[total] [money] NULL,
	[id_huesped] [int] NOT NULL,
	[id_usuario] [int] NULL,
	[id_empleado] [int] NULL,
	[id_habitacion] [int] NULL,
	[id_pago] [int] NULL,
 CONSTRAINT [PK_Reservas] PRIMARY KEY CLUSTERED 
(
	[id_reservas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 6/10/2018 15:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[rol] [nchar](10) NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salida_reservas]    Script Date: 6/10/2018 15:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salida_reservas](
	[id_salida_reservas] [int] IDENTITY(1,1) NOT NULL,
	[observaciones] [varchar](50) NULL,
	[ud_usuario] [int] NULL,
	[id_reserva] [int] NULL,
 CONSTRAINT [PK_salida_reservas] PRIMARY KEY CLUSTERED 
(
	[id_salida_reservas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_huesped]    Script Date: 6/10/2018 15:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_huesped](
	[id_tipo_huesped] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [nchar](10) NULL,
 CONSTRAINT [PK_Tipo_huesped] PRIMARY KEY CLUSTERED 
(
	[id_tipo_huesped] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_pago]    Script Date: 6/10/2018 15:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_pago](
	[id_tipo_pago] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](50) NULL,
 CONSTRAINT [PK_Tipo_pago] PRIMARY KEY CLUSTERED 
(
	[id_tipo_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 6/10/2018 15:13:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[usuario] [varchar](50) NULL,
	[contrasenia] [varchar](50) NULL,
	[id_rol] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cargo] ON 

INSERT [dbo].[Cargo] ([id_cargo], [nombre]) VALUES (1, N'mesero')
INSERT [dbo].[Cargo] ([id_cargo], [nombre]) VALUES (2, N'cocinero')
SET IDENTITY_INSERT [dbo].[Cargo] OFF
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([id_empleado], [nombre], [apellido], [edad], [direccion], [telefono], [id_cargo]) VALUES (1, N'omar', N'martinez', 33, N'ahuachapan', N'778889944', 1)
INSERT [dbo].[Empleado] ([id_empleado], [nombre], [apellido], [edad], [direccion], [telefono], [id_cargo]) VALUES (2, N'jose', N'hernandez', 22, N'turin', N'44556688', 2)
SET IDENTITY_INSERT [dbo].[Empleado] OFF
SET IDENTITY_INSERT [dbo].[Habitaciones] ON 

INSERT [dbo].[Habitaciones] ([id_habitaciones], [tipo], [precio], [cantidad], [id_promociones]) VALUES (2, N'habitacion doble', 200.0000, 32, 1)
INSERT [dbo].[Habitaciones] ([id_habitaciones], [tipo], [precio], [cantidad], [id_promociones]) VALUES (3, N'V.I.P', 300.0000, 20, 1)
SET IDENTITY_INSERT [dbo].[Habitaciones] OFF
SET IDENTITY_INSERT [dbo].[Huesped] ON 

INSERT [dbo].[Huesped] ([id_huesped], [nombre], [direccion], [dui], [telefono], [correo], [id_tipo_huesped]) VALUES (1, N'mario', N'ahuachapan', N'01010-0102020', N'98784151', N'jorge.trejo@gmail.com', 1)
INSERT [dbo].[Huesped] ([id_huesped], [nombre], [direccion], [dui], [telefono], [correo], [id_tipo_huesped]) VALUES (2, N'juan', N'san salvador', N'01010-0102020', N'98784151', N'ernesto.neto@hoytmail.com', 2)
SET IDENTITY_INSERT [dbo].[Huesped] OFF
SET IDENTITY_INSERT [dbo].[Promociones] ON 

INSERT [dbo].[Promociones] ([id_promocion], [promocion], [descuento]) VALUES (1, N'dia del padre', 25.0000)
SET IDENTITY_INSERT [dbo].[Promociones] OFF
SET IDENTITY_INSERT [dbo].[Reservas] ON 

INSERT [dbo].[Reservas] ([id_reservas], [numero_habitaciones], [fecha_entrada], [fecha_salida], [dias], [total], [id_huesped], [id_usuario], [id_empleado], [id_habitacion], [id_pago]) VALUES (1, 2, CAST(N'2018-03-02' AS Date), CAST(N'2018-03-02' AS Date), 3, 780.0000, 1, 1, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[Reservas] OFF
SET IDENTITY_INSERT [dbo].[rol] ON 

INSERT [dbo].[rol] ([id_rol], [rol]) VALUES (1, N'gerente   ')
INSERT [dbo].[rol] ([id_rol], [rol]) VALUES (2, N'recepcion ')
SET IDENTITY_INSERT [dbo].[rol] OFF
SET IDENTITY_INSERT [dbo].[Tipo_huesped] ON 

INSERT [dbo].[Tipo_huesped] ([id_tipo_huesped], [tipo]) VALUES (1, N' frecuente')
INSERT [dbo].[Tipo_huesped] ([id_tipo_huesped], [tipo]) VALUES (2, N'V.I.P     ')
SET IDENTITY_INSERT [dbo].[Tipo_huesped] OFF
SET IDENTITY_INSERT [dbo].[Tipo_pago] ON 

INSERT [dbo].[Tipo_pago] ([id_tipo_pago], [tipo]) VALUES (1, N'tarjeta de credito')
INSERT [dbo].[Tipo_pago] ([id_tipo_pago], [tipo]) VALUES (2, N'efectivo')
SET IDENTITY_INSERT [dbo].[Tipo_pago] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id_usuario], [nombre], [usuario], [contrasenia], [id_rol]) VALUES (1, N'david', N'david villa', N'123456', 1)
INSERT [dbo].[Usuario] ([id_usuario], [nombre], [usuario], [contrasenia], [id_rol]) VALUES (2, N'andres', N'andres trejo', N'5555555', 2)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Cargo] FOREIGN KEY([id_cargo])
REFERENCES [dbo].[Cargo] ([id_cargo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Cargo]
GO
ALTER TABLE [dbo].[Habitaciones]  WITH CHECK ADD  CONSTRAINT [FK_Habitaciones_Promociones] FOREIGN KEY([id_promociones])
REFERENCES [dbo].[Promociones] ([id_promocion])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Habitaciones] CHECK CONSTRAINT [FK_Habitaciones_Promociones]
GO
ALTER TABLE [dbo].[Huesped]  WITH CHECK ADD  CONSTRAINT [FK_Huesped_Tipo_huesped] FOREIGN KEY([id_tipo_huesped])
REFERENCES [dbo].[Tipo_huesped] ([id_tipo_huesped])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Huesped] CHECK CONSTRAINT [FK_Huesped_Tipo_huesped]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Empleado] FOREIGN KEY([id_empleado])
REFERENCES [dbo].[Empleado] ([id_empleado])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Empleado]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Habitaciones] FOREIGN KEY([id_habitacion])
REFERENCES [dbo].[Habitaciones] ([id_habitaciones])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Habitaciones]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Huesped] FOREIGN KEY([id_huesped])
REFERENCES [dbo].[Huesped] ([id_huesped])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Huesped]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Tipo_pago] FOREIGN KEY([id_pago])
REFERENCES [dbo].[Tipo_pago] ([id_tipo_pago])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Tipo_pago]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Usuario]
GO
ALTER TABLE [dbo].[salida_reservas]  WITH CHECK ADD  CONSTRAINT [FK_salida_reservas_Reservas] FOREIGN KEY([id_reserva])
REFERENCES [dbo].[Reservas] ([id_reservas])
GO
ALTER TABLE [dbo].[salida_reservas] CHECK CONSTRAINT [FK_salida_reservas_Reservas]
GO
ALTER TABLE [dbo].[salida_reservas]  WITH CHECK ADD  CONSTRAINT [FK_salida_reservas_Usuario] FOREIGN KEY([ud_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[salida_reservas] CHECK CONSTRAINT [FK_salida_reservas_Usuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_rol] FOREIGN KEY([id_rol])
REFERENCES [dbo].[rol] ([id_rol])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_rol]
GO
