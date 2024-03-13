INSERT dbo.DiskType (DiskTypeDesc)
VALUES
('SSD'),
('HDD'),
('SDD')
GO

INSERT dbo.Memory (MemoryDesc)
VALUES
('8 GB'),
('16 GB'),
('32 GB'),
('2 GB'),
('512 MB')
GO

INSERT dbo.Processor(ProcessorDesc)
VALUES
(' Intel® Celeron™ N3050 Processor'),
('AMD FX 4300 Processor'),
('AMD Athlon Quad-Core APU Athlon 5150 '),
('AMD FX 8-Core Black Edition FX-8350'),
('AMD FX 8-Core Black Edition FX-8370 '),
('Intel Core i7-6700K 4GHz Processor'),
('Intel® Core™ i5-6400 Processor'),
('Intel® Core™ i5-6400 Processor'),
('Intel Core i7 Extreme Edition 3 GHz Processor'),
('Intel® Core™ i5-6400 Processor')
GO

INSERT dbo.PowerSupply (PowerSupplyDesc)
VALUES
('500 W PSU'),
('450 W PSU'),
('1000 W PSU'),
('750 W PSU'),
('508 W PSU'),
('700 W PSU')
GO

INSERT dbo.VideoCard (VideoCardDesc)
VALUES
('NVIDIA GeForce GTX 770'),
('NVIDIA GeForce GTX 960'),
('Radeon R7360'),
('Radeon RX 480'),
('Radeon R9 380'),
('NVIDIA GeForce GTX 1080'),
('AMD FirePro W4100')
GO

INSERT dbo.WeightUnit (WeightUnitDesc)
VALUES
('kg'),
('lb')
GO

INSERT dbo.[Disk] (DiskSize, DiskTypeId)
VALUES
('1 TB', 1),
('2 TB', 2),
('3 TB', 2),
('4 TB', 2),
('750 GB', 3),
('2 TB', 3),
('500 GB', 3),
('80 GB', 1)
GO

INSERT dbo.UsbType (UsbTypeDesc)
VALUES
('USB 3.0'),
('USB 2.0'),
('USB C')
GO