USE [Thesis]
GO

CREATE TABLE [dbo].[DiskType](
	[DiskTypeId] [int] IDENTITY(1,1) NOT NULL,
	[DiskTypeDesc] [varchar](50) NOT NULL,
	CONSTRAINT [PK_DiskType] PRIMARY KEY CLUSTERED (DiskTypeId)
)
GO

--------------

CREATE TABLE [dbo].[Disk](
	[DiskId] [int] IDENTITY(1,1) NOT NULL,
	[DiskSize] [varchar](50) NOT NULL,
	[DiskTypeId] [int] NOT NULL,
	CONSTRAINT [PK_Disk] PRIMARY KEY CLUSTERED (DiskId)
)
GO

ALTER TABLE dbo.[Disk]
ADD CONSTRAINT [FK_DiskType] FOREIGN KEY (DiskTypeId) REFERENCES [dbo].[DiskType] ([DiskTypeId])
GO

--------------

CREATE TABLE [dbo].[Memory](
	[MemoryId] [int] IDENTITY(1,1) NOT NULL,
	[MemoryDesc] [varchar](50) NOT NULL,
	CONSTRAINT [PK_Memory] PRIMARY KEY CLUSTERED (MemoryId)
)
GO

--------------

CREATE TABLE [dbo].[PowerSupply](
	[PowerSupplyId] [int] IDENTITY(1,1) NOT NULL,
	[PowerSupplyDesc] [varchar](50) NOT NULL,
	CONSTRAINT [PK_PowerSupply] PRIMARY KEY CLUSTERED (PowerSupplyId)
)
GO

----------------

CREATE TABLE [dbo].[Processor](
	[ProcessorId] [int] IDENTITY(1,1) NOT NULL,
	[ProcessorDesc] [varchar](50) NOT NULL,
	CONSTRAINT [PK_Processor] PRIMARY KEY CLUSTERED (ProcessorId)
)
GO

----------------

CREATE TABLE [dbo].[UsbType](
	[UsbTypeId] [int] IDENTITY(1,1) NOT NULL,
	[UsbTypeDesc] [varchar](50) NOT NULL,
	CONSTRAINT [PK_UsbType] PRIMARY KEY CLUSTERED (UsbTypeId)
)
GO

-----------------

CREATE TABLE [dbo].[VideoCard](
	[VideoCardId] [int] IDENTITY(1,1) NOT NULL,
	[VideoCardDesc] [varchar](50) NOT NULL,
	CONSTRAINT [PK_VideoCard] PRIMARY KEY CLUSTERED (VideoCardId)
)
GO

------------------

CREATE TABLE [dbo].[WeightUnit](
	[WeightUnitId] [int] IDENTITY(1,1) NOT NULL,
	[WeightUnitDesc] [varchar](50) NOT NULL,
	CONSTRAINT [PK_WeightUnit] PRIMARY KEY CLUSTERED (WeightUnitId)
)
GO

------------------

CREATE TABLE dbo.Computer(
	ComputerId int IDENTITY(1,1) NOT NULL,
	DiskId int,
	VideoCardId int ,
	WeightAmount int,
	WeightUnitId int,
	PowerSupplyId int,
	ProcessorId int,
	MemoryId int,
	CONSTRAINT [PK_Computer] PRIMARY KEY CLUSTERED (ComputerId)
)
GO

ALTER TABLE dbo.Computer
ADD 
	CONSTRAINT FK_Disk FOREIGN KEY (DiskId) REFERENCES dbo.[Disk] (DiskId),
	CONSTRAINT FK_VideoCard FOREIGN KEY (VideoCardId) REFERENCES dbo.VideoCard (VideoCardId),
	CONSTRAINT FK_WeightUnit FOREIGN KEY (WeightUnitId) REFERENCES dbo.WeightUnit (WeightUnitId),
	CONSTRAINT FK_PowerSupply FOREIGN KEY (PowerSupplyId) REFERENCES dbo.PowerSupply (PowerSupplyId),
	CONSTRAINT FK_Processor FOREIGN KEY (ProcessorId) REFERENCES dbo.Processor (ProcessorId),
	CONSTRAINT FK_Memory FOREIGN KEY (MemoryId) REFERENCES dbo.Memory (MemoryId)
GO

-------------

CREATE TABLE dbo.ComputerUsb(
	ComputerUsbId int IDENTITY(1,1) NOT NULL,
	ComputerId int,
	UsbTypeId int,
	CONSTRAINT [PK_ComputerUsb] PRIMARY KEY CLUSTERED (ComputerUsbId)
)
GO

ALTER TABLE dbo.ComputerUsb
ADD
	CONSTRAINT FK_Computer FOREIGN KEY (ComputerId) REFERENCES dbo.Computer (ComputerId),
	CONSTRAINT FK_UsbType FOREIGN KEY (UsbTypeId) REFERENCES dbo.UsbType (UsbTypeId)
GO


