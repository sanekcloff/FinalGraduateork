USE SalesServiceDB
GO

INSERT INTO [dbo].[Roles]
           ([Title])
     VALUES
           ('�������������'),
		   ('��������'),
		   ('������������')
GO


INSERT INTO [dbo].[Users]
           ([Login],[Password],[RoleID])
     VALUES
           ('admin','admin',1),
		   ('employee','employee',2),
		   ('user','user',3)
GO

INSERT INTO [dbo].[UserProfiles]
           ([LastName],[FirstName],[MiddleName],[DateOfBirth],[Phone],[Email],[DateOfRegister],[NumberOfPurchases],[NumberOfServices],[UserId])
     VALUES
           ('������','���������','��������','20-03-2003','34534534','jop@gmil.cum','28-03-2023',0,0,1),
		   ('�������','���������','��������','20-03-2003','34534534','jop@gmil.cum','28-03-2023',1,0,2),
		   ('��������','���������','��������','20-03-2003','34534534','jop@gmil.cum','28-03-2023',0,1,3)
GO

INSERT INTO [dbo].[ProductCategories]
           ([Title])
     VALUES
           ('�����������'),
		   ('�������� � ���������� ����������'),
		   ('��������'),
		   ('���������� �������'),
		   ('��������'),
		   ('���������� ���������'),
		   ('�������������� �����������'),
		   ('���� ����������, ���������, ����������')
GO

INSERT INTO [dbo].[Products]
           ([Title],[Description],[Picture],[Cost],[Discount],[DateOfAdd],[ProductCategoryId])
     VALUES
			--�����������
           ('������ ����','�������� ���� �������� ��������, �������� � ���������� ��������, ���������� �����, ������������������� � �������� ����, ��� ��������� ���������������� ����� ���������� � ������� �������. ����� ��������� ������������ ���������� ������������������ ����������, �������� ��� ����� ������� ���������������.','product_1.png',13000,1,'13-04-2012',1),
		   ('����','����������� ��� ����������� ���, ��� � ��� �������������� ����������������. ������������ ��������������������� �����, �������� ��� ����������� �� ������� ������������ ���������� �������������, � ������� ������������ ���� �� ���������� ������������ ��� �������������� �������������� ����� ������.','product_1.png',33600,1,'13-04-2012',1),
		   ('������� ������','����� ������� � �������� ���������, ��������� �� ������� ������ � ����� ����������������. ������ ���������� �������� ����� ����������������, ��� ��������� ��������� ����� � �������� ������. ��������� ��������� ������ ����������, �������� ���� ����������� ������������ ��� ������� �������� ��������, ��� ���� ��������� ������� ���������.','product_1.png',5400,0.5,'13-04-2012',1),
		   ('�������� �� 5 �������������','��� ������� 1�:����������� 8. �������� �� 5 ������������� �� ��������� �� ��������� � �������� �������� 1� ����������� 8 ���� � �������� �� 5 ������� ����.','product_2.png',26000,0.5,'13-04-2012',1),
		   ('����','�������������� ����������� ��������� ����� ������������������� ������������. ������ ���� ������������ ���������� ��������, � ����� � ���� � ��������� ��� ����������� ��������, � ������������ � ������������ �� ��.','product_3.png',43200,1,'13-04-2012',1),
		   ('����','��������� �������� � ���� ��������� �1�:����������� 8.3� � ������������ ������������ �������������� �����������. ��� ����������� � ������������ � �������� ������� �� ��� ����������� ����� ������ �������������� ����� ���������-������������� ������������ ����������� � ���������� �� ��� ����������� �� 31.10.2000 � 94�.','product_4.png',14400,1,'15-04-2012',1),
		   ('���. ������� ������','������� �1�:����������� ��Ҕ ������������� ��� ������������� �������������� � ���������� �����, ������� ���������� ������������ (������������������) ���������� � �������������/�������������� �������������� �������������, ������ ������������, ���������� �������� � �������-������������ (��������) ������������ (���), ������� ���� � �������� �������������� �����������.','product_5.png',7200,1,'15-04-2012',1),
		   ('��������� 8','����������� ������� �1� ��������� 8� � ��� ��������������������, ������������������ �������� ������������ �1�:����������� 8. ������� ������� ��� �������� � ����������� ������� �������������� � ���������� ����� �� ���, � ����� ��� ���������� ������������������ ����������.','product_6.png',5400,1,'15-04-2012',1),

		   --�������� � ���������� ���������v
		   ('����','� ��������� 1�:�������� � ���������� ���������� 8 ���� ����� ������������ ���������� ���� ������������ ����� ����� � � ���� �� ��������� ������ � ����������: ����������������� �������� �������� ����������, �������� ����������� ������������ � ���� HR �������.','product_7.png',100900,1,'18-04-2012',2),
		   ('����','������ ������� ������� �����������, � ������ �������, ��� �������� ����� � ����������� ������� �����������, ���� ���������� � ������ � ������������.','product_7.png',22600,1,'18-04-2012',2),
		   ('������� ������','������ ��������� � ��� ������� ������� � ������� ������������. Ÿ �� ����� ������������ � ������������ ����������� �����������, � ����� ����� ������ ������������ ��������� ��������� ������� ��� ������ ������ ����������������.','product_7.png',8100,1,'18-04-2012',2),

		   --��������
		   ('�������','(���������)','product_8.png',3600,1,'20-04-2012',3),
		   ('���������� ���������','������� ��������� ����������� ��������� ���� ������������� �������, ��������� ����������� ������ ������������� �������� ������������ � ����������� �������� �������� �����������, � ����� ��������� ���������, ��������, ����������, �������������� � ���������� ��������.','product_9.png',22600,0.9,'20-04-2012',3),
		   ('������� ������','���������� ������� 1�:���������� ��������� 8. ������� ������ ������������ ����������� ������������ ��������� �������: �� ������ � �������� ������, �� ����������� ��������� �����������, �� ������� ������ �������, ������� � ���������� ����� ������������ ��� ���������� ������ ������� �������� ������������ �����������.','product_9.png',7200,1,'20-04-2012',3),

		   --���������� �������
		   ('�����:����� ���������� ����������','����������� ������� �1�-�����:����� ���������� ����������. ������ 5.5� ��� ���������� ��������� �������� ����� ���������� � ��������� �1�-�����:�������� ��� ��������� ����������. ������ 5.5�.','product_5.png',8000,1,'10-05-2012',4),
		   ('����� �������','������������ ������������� ����� � ���������� ��� ����� ��� � ��������� ������� �������, ���������� � ��������� �������, ������ ������� � ��������������.','product_12.png',25000,1,'10-05-2012',4),
		   ('����������','�������� ���������� �������� ��� ������������� ���������� ������� ��������� ������������, ��������, ������� ������������ ������������ �����������.','product_10.png',28000,1,'10-05-2012',4),
		   ('����������','��������� ��� ������������� ������������ ��������� ������ ���� � ����������.','product_11.png',30000,1,'10-05-2012',4),

		   --��������
		   ('����. ���������� �������� �� ������� �����','�������������� ���������� �������� ������������ ����������� ������ ������� ���������� ������������� � �������������� �� ������ ���������� ������� ����: 1, 5, 10, 20, 50, 100, 300 ��� 500.','product_13.png',6300,0.3,'18-04-2012',5),
		   ('����������� ������������� ��������','�1�:����������� 8. ����������� ������������� ��������� (����� 1�:���) ����������� �� ������������ ����, � ������� �������� ����� ������������ ������ � ������ ��������� �1�:����������� 8 ���ϻ, ���������� �� ��������� �������� 1�:���.','product_5.png',300000,1,'18-04-2012',5),
		   ('����. �������� �� ������','�������� ��� ������������� ������-���������� �������� ������ �� ������������ �������� � �������� �������. ��� ��������, ������� ��������� ������������� ������� ���������� ������� ���� �� ����������� ������ �������� �� ������ ������ ����. ��� ����� ����� ������� ����������� ����������, ������� ���������� ��������� �� ��������� ������������.','product_5.png',50400,0.4,'18-04-2012',5),

		   --���������� ���������
		   ('����������� �������������','������ ��������� � ��� ������� ������� � ������� ������������. Ÿ �� ����� ������������ � ������������ ����������� �����������, � ����� ����� ������ ������������ ��������� ��������� ������� ��� ������ ������ ����������������.','product_14.png',61700,1,'26-04-2012',6),
		   ('���������� ����� ������','������� ����������� ������� ��� ����������� ������ �������. � ��������� ����������� ��� ����������� �������� ��� ������������� �����, �������, ������������ � ��������. ','product_15.png',17400,1,'26-04-2012',6),

		   --�������������� �����������

		   --���� ����������, ���������, ���������
		   ('�������������� ���������� ����� �� ��������� ������������� ������� ����� ������� ��� 1�:�����������','�������������� ���������� ����� �� ��������� ������������� ������� ����� ������� �� ��� ���������, �� ��������� ������� ��� ����������� ���������� ���������� �������. ����� ��� ������ ��������� ������� ���� �� ������� ����� �������������.','product_16.png',16800,1,'18-04-2012',8),
		   ('����� ������������������� ��������� � ����','������� ����� ��� 1�:����������� ������������������ ��������� � ������������ �������� �������, � ���������� ������������ ��� ���� �����: ��� ����������� ����� ��������� ������� ���� ��������� �������������� � �������� ��� �������� ��� ��� ���� ������ ������. ���� ����������� �� �������� �����������.','product_16.png',9600,1,'18-04-2012',8),
		   ('������� ����� ��� 1�: ����������� ��������������������� �����������','��������� ����� ��������� ������������: ������� ����� ��� 1�: ����������� ��������������������� �����������, ��������� �������� ����� ��������, ��� ����� �������, ���� �������, ������������ �������������, ��������� ������ �������� �������, ������� � ����.','product_16.png',7800,1,'18-04-2012',8)
GO


INSERT INTO [dbo].[Services]
           ([Title],[Description],[CostPerHour],[DateOfAdd])
     VALUES
           ('������������ 1�','���������� ���������, �������� �������, ������ � ��������� - ������ ������ �������������� �� ��������� ����� ����������� ��������� 1�. ������ ��������� ������� ������, ������������ ���������, ����� �������������� ��������� � ������. ����������� ���������� � �������, �������24, � ��������������,  � �����������.',1600,'14-05-2012'),
		   ('������ 1�','������ 1� � ��� ����� �����������, ������������ �� ��, ����� 1� � �������� ����������.',1600,'14-05-2012'),
		   ('��������� 1�','��������� �������� 1�, ���������� � ������� �����������, ���������� ���������, ���� ������� ��� ������� � ����.',0,'14-05-2012'),
		   ('�������� ������������� 1�','������� ��������� ��� ���������� �������� � ���������� ������� � ������� �������������. ���� ����� ������ � ���� ������������� ��� ������� ������ �������.',0,'14-05-2012'),
		   ('������������ 1�','��������� 1� � ���������������� ������� �������� �� ������������� 1� ��� ����������� �� ���������� ���������. �� ������������� ����������� �����.',1600,'14-05-2012')

GO

INSERT INTO [dbo].[Statuses]
           ([Title])
     VALUES
           ('������� ������'),
		   ('�����������'),
		   ('��������')
GO


INSERT INTO [dbo].[UserProducts]
           ([Quantity],[DateOfOrder],[DateOfCompletion],[ProductId],[UserId],[StatusId])
     VALUES
           (3,'01-04-2023',null,1,2,1)
GO

INSERT INTO [dbo].[UserServices]
           ([DateOfOrder],[DateOfCompletion],[ServiceId],[UserId],[StatusId])
     VALUES
           ('02-03-2023',null,3,3,2)
GO