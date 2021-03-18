CREATE DATABASE MLegariaItalika

USE MLegariaItalika

CREATE TABLE Tipo(
	IdTipo int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(15)
)

	INSERT INTO Tipo VALUES('Trabajo')
	INSERT INTO Tipo VALUES('Deportiva')
	INSERT INTO Tipo VALUES('Infantil')


	CREATE PROCEDURE TipoGet
	AS
	SELECT 
		IdTipo, Nombre
	FROM Tipo


	CREATE PROCEDURE GetByTipo
	@IdTipo int
	as
	SELECT 
		IdTipo, 
		Nombre		
	FROM Tipo
	WHERE IdTipo = @IdTipo


CREATE TABLE Producto(
	IdProducto int IDENTITY(1,1) PRIMARY KEY,
	Fert varchar(20),
	Modelo varchar(20),
	Tipo int FOREIGN KEY REFERENCES Tipo(IdTipo),
	NumeroDeSerie varchar(20),
	Fecha datetime
)	

	INSERT INTO Producto VALUES('FERT01', '2021IT', 3,'0001', GETDATE())
	INSERT INTO Producto VALUES('FERT05', '2020IT', 1,'0002', GETDATE())
	INSERT INTO Producto VALUES('FERT06', '2021IT', 2,'0003', GETDATE())


	CREATE PROCEDURE ProductoGet
	AS
	SELECT 
		Producto.IdProducto, 
		Producto.Fert,
		Producto.Modelo,
		Tipo.Nombre,
		Producto.NumeroDeSerie,
		Producto.Fecha
	FROM Producto
	INNER JOIN Tipo ON Producto.Tipo = Tipo.IdTipo

	CREATE PROCEDURE ProductoAdd
	@Fert varchar(20),
	@Modelo varchar(20),
	@Tipo int,
	@NumeroDeSerie varchar(20),
	@Fecha date
	as
	INSERT INTO [Producto]([Fert],[Modelo],[Tipo],[NumeroDeSerie],[Fecha]) 
	VALUES (@Fert, @Modelo,@Tipo,@NumeroDeSerie,@Fecha)


	CREATE PROCEDURE ProductoGetById
	@IdProducto int
	as
	SELECT 
		Producto.IdProducto, 
		Producto.Fert,
		Producto.Modelo,
		Tipo.IdTipo,
		Tipo.Nombre,
		Producto.NumeroDeSerie,
		Producto.Fecha
	FROM Producto
	INNER JOIN Tipo ON Producto.Tipo = Tipo.IdTipo
	WHERE Producto.IdProducto = @IdProducto


	CREATE PROCEDURE ProductoGetByModelo
	@Modelo varchar(20)
	as
	SELECT 
		Producto.IdProducto, 
		Producto.Fert,
		Producto.Modelo,
		Tipo.IdTipo,
		Tipo.Nombre,
		Producto.NumeroDeSerie,
		Producto.Fecha
	FROM Producto
	INNER JOIN Tipo ON Producto.Tipo = Tipo.IdTipo
	WHERE Producto.Modelo = @Modelo


	CREATE PROCEDURE ProductoUpdate
	@IdProducto int,
	@Fert varchar(20),
	@Modelo varchar(20),
	@Tipo int,
	@NumeroDeSerie varchar(20),
	@Fecha date
	as
	UPDATE 
		Producto 
		SET  
			Fert = @Fert, 
			Modelo = @Modelo, 
			Tipo = @Tipo, 
			NumeroDeSerie = @NumeroDeSerie,
			Fecha = @Fecha 
		WHERE IdProducto = @IdProducto
	
	CREATE PROCEDURE ProductoDelete
	@IdProducto int
	as
	DELETE FROM Producto WHERE IdProducto = @IdProducto


	CREATE PROCEDURE ProductoGetBusqueda
	@Fert varchar(20),
	@Modelo varchar(20)	
	AS
	SELECT
		Producto.IdProducto, 
		Producto.Fert,
		Producto.Modelo,
		Tipo.Nombre,
		Producto.NumeroDeSerie,
		Producto.Fecha
	FROM Producto
	INNER JOIN Tipo ON Producto.Tipo = Tipo.IdTipo
	WHERE Fert LIKE '%' + @Fert+'%' 
	AND Modelo LIKE '%' + @Modelo+'%'