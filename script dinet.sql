create database DINETPRUEBA
GO

USE DINETPRUEBA
GO

CREATE TABLE dbo.MOV_INVENTARIO (
	COD_CIA            VARCHAR(5)   NOT NULL,
	COMPANIA_VENTA_3   VARCHAR(5)   NOT NULL,
	ALMACEN_VENTA      VARCHAR(10)  NOT NULL,
	TIPO_MOVIMIENTO    VARCHAR(2)   NOT NULL,
	TIPO_DOCUMENTO     VARCHAR(2)   NOT NULL,
	NRO_DOCUMENTO      VARCHAR(50)  NOT NULL,
	COD_ITEM_2         VARCHAR(50)  NOT NULL,
	PROVEEDOR          VARCHAR(100) NULL,
	ALMACEN_DESTINO    VARCHAR(50)  NULL,
	CANTIDAD           INT          NULL,
	DOC_REF_1          VARCHAR(50)  NULL,
	DOC_REF_2          VARCHAR(50)  NULL,
	DOC_REF_3          VARCHAR(50)  NULL,
	DOC_REF_4          VARCHAR(50)  NULL,
	DOC_REF_5          VARCHAR(50)  NULL,
	FECHA_TRANSACCION  DATE         NULL,
	CONSTRAINT PK_MOV_INVENTARIO PRIMARY KEY CLUSTERED (
		COD_CIA,
		COMPANIA_VENTA_3,
		ALMACEN_VENTA,
		TIPO_MOVIMIENTO,
		TIPO_DOCUMENTO,
		NRO_DOCUMENTO,
		COD_ITEM_2
	)
);
go

CREATE TABLE dbo.LOG_ERRORES (
    IdError         INT IDENTITY(1,1) PRIMARY KEY,
    NombreSP        VARCHAR(200),
    MensajeError    NVARCHAR(4000),
    FechaError      DATETIME DEFAULT GETDATE(),
    Parametros      NVARCHAR(1000),
    UsuarioSQL      VARCHAR(100)
)
go

CREATE TABLE dbo.USUARIOS
(IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(200) not null,
Usuario VARCHAR(30) not null,
Clave VARCHAR(20) not null,
Estado INT DEFAULT 1)
go

-- Datos de prueba
INSERT INTO dbo.MOV_INVENTARIO (
	COD_CIA, COMPANIA_VENTA_3, ALMACEN_VENTA, TIPO_MOVIMIENTO, TIPO_DOCUMENTO,
	NRO_DOCUMENTO, COD_ITEM_2, PROVEEDOR, ALMACEN_DESTINO, CANTIDAD,
	DOC_REF_1, DOC_REF_2, DOC_REF_3, DOC_REF_4, DOC_REF_5,
	FECHA_TRANSACCION
)
VALUES
('01', 'A001', 'ALM001', 'IN', 'FV', 'INV001', 'ITEM001', 'Proveedor 1', 'ALM002', 10, NULL, NULL, NULL, NULL, NULL, '2025-01-05'),
('01', 'A001', 'ALM001', 'IN', 'FV', 'INV002', 'ITEM002', 'Proveedor 2', 'ALM002', 20, NULL, NULL, NULL, NULL, NULL, '2025-01-10'),
('01', 'A001', 'ALM001', 'IN', 'FV', 'INV003', 'ITEM003', 'Proveedor 3', 'ALM002', 15, NULL, NULL, NULL, NULL, NULL, '2025-01-15'),
('01', 'A001', 'ALM001', 'OU', 'FV', 'INV004', 'ITEM004', 'Proveedor 4', 'ALM003', 8, NULL, NULL, NULL, NULL, NULL, '2025-02-01'),
('01', 'A001', 'ALM001', 'OU', 'FV', 'INV005', 'ITEM005', 'Proveedor 5', 'ALM003', 12, NULL, NULL, NULL, NULL, NULL, '2025-02-10'),
('01', 'A001', 'ALM001', 'IN', 'NC', 'INV006', 'ITEM006', 'Proveedor 6', 'ALM002', 30, NULL, NULL, NULL, NULL, NULL, '2025-02-15'),
('01', 'A001', 'ALM001', 'OU', 'NC', 'INV007', 'ITEM007', 'Proveedor 7', 'ALM004', 5, NULL, NULL, NULL, NULL, NULL, '2025-03-05'),
('01', 'A001', 'ALM001', 'IN', 'FV', 'INV008', 'ITEM008', 'Proveedor 8', 'ALM002', 18, NULL, NULL, NULL, NULL, NULL, '2025-03-12'),
('01', 'A001', 'ALM001', 'OU', 'FV', 'INV009', 'ITEM009', 'Proveedor 9', 'ALM004', 9, NULL, NULL, NULL, NULL, NULL, '2025-03-15'),
('01', 'A001', 'ALM001', 'IN', 'FV', 'INV010', 'ITEM010', 'Proveedor 10', 'ALM002', 25, NULL, NULL, NULL, NULL, NULL, '2025-03-20'),
('01', 'A001', 'ALM001', 'OU', 'FV', 'INV011', 'ITEM011', 'Proveedor 11', 'ALM005', 14, NULL, NULL, NULL, NULL, NULL, '2025-04-01'),
('01', 'A001', 'ALM001', 'IN', 'FV', 'INV012', 'ITEM012', 'Proveedor 12', 'ALM002', 7, NULL, NULL, NULL, NULL, NULL, '2025-04-05'),
('01', 'A001', 'ALM001', 'OU', 'NC', 'INV013', 'ITEM013', 'Proveedor 13', 'ALM006', 11, NULL, NULL, NULL, NULL, NULL, '2025-04-10'),
('01', 'A001', 'ALM001', 'IN', 'FV', 'INV014', 'ITEM014', 'Proveedor 14', 'ALM002', 6, NULL, NULL, NULL, NULL, NULL, '2025-04-15'),
('01', 'A001', 'ALM001', 'OU', 'FV', 'INV015', 'ITEM015', 'Proveedor 15', 'ALM006', 13, NULL, NULL, NULL, NULL, NULL, '2025-04-20'),
('01', 'A001', 'ALM001', 'IN', 'NC', 'INV016', 'ITEM016', 'Proveedor 16', 'ALM002', 19, NULL, NULL, NULL, NULL, NULL, '2025-05-01'),
('01', 'A001', 'ALM001', 'OU', 'FV', 'INV017', 'ITEM017', 'Proveedor 17', 'ALM007', 10, NULL, NULL, NULL, NULL, NULL, '2025-05-10'),
('01', 'A001', 'ALM001', 'IN', 'FV', 'INV018', 'ITEM018', 'Proveedor 18', 'ALM002', 22, NULL, NULL, NULL, NULL, NULL, '2025-05-15'),
('01', 'A001', 'ALM001', 'OU', 'FV', 'INV019', 'ITEM019', 'Proveedor 19', 'ALM007', 16, NULL, NULL, NULL, NULL, NULL, '2025-05-20'),
('01', 'A001', 'ALM001', 'IN', 'FV', 'INV020', 'ITEM020', 'Proveedor 20', 'ALM002', 21, NULL, NULL, NULL, NULL, NULL, '2025-05-25');
go


insert into USUARIOS(Nombre,Usuario,Clave)
values('ADMINISTRADOR','admin','admin')
go

-- CONSULTA
/*
EXEC sp_ConsultarInventario;
EXEC sp_ConsultarInventario @FechaInicio = '2025-03-01', @FechaFin = '2025-06-30';
EXEC sp_ConsultarInventario @TipoMovimiento = 'IN';
EXEC sp_ConsultarInventario @NroDocumento = 'INV011';
*/
CREATE PROCEDURE sp_ConsultarInventario
    @FechaInicio        date        = NULL,
    @FechaFin           date        = NULL,
    @TipoMovimiento     varchar(2)  = NULL,
    @NroDocumento       varchar(50) = NULL
AS
BEGIN
    set nocount on;

    select	COD_CIA,
			COMPANIA_VENTA_3,
			ALMACEN_VENTA,
			TIPO_MOVIMIENTO,
			TIPO_DOCUMENTO,
			NRO_DOCUMENTO,
			COD_ITEM_2,
			PROVEEDOR,
			ALMACEN_DESTINO,
			CANTIDAD,
			DOC_REF_1,
			DOC_REF_2,
			DOC_REF_3,
			DOC_REF_4,
			DOC_REF_5,
			FECHA_TRANSACCION
    from MOV_INVENTARIO
    where (@FechaInicio is null or FECHA_TRANSACCION >= @FechaInicio)
        and (@FechaFin is null or FECHA_TRANSACCION <= @FechaFin)
        and (@TipoMovimiento is null or TIPO_MOVIMIENTO = @TipoMovimiento)
        and (@NroDocumento is null or NRO_DOCUMENTO LIKE '%' + @NroDocumento + '%')
    order by FECHA_TRANSACCION desc, NRO_DOCUMENTO;
END
go

-- Obtener por ID
/*
EXEC sp_ObtenerPorID
    @COD_CIA = '01',
    @COMPANIA_VENTA_3 = 'A001',
    @ALMACEN_VENTA = 'ALM001',
    @TIPO_MOVIMIENTO = 'OU',
    @TIPO_DOCUMENTO = 'FV',
    @NRO_DOCUMENTO = 'INV011',
    @COD_ITEM_2 = 'ITEM011'
*/
CREATE PROCEDURE sp_ObtenerPorID
    @COD_CIA VARCHAR(10),
    @COMPANIA_VENTA_3 VARCHAR(10),
    @ALMACEN_VENTA VARCHAR(10),
    @TIPO_MOVIMIENTO VARCHAR(10),
    @TIPO_DOCUMENTO VARCHAR(10),
    @NRO_DOCUMENTO VARCHAR(20),
    @COD_ITEM_2 VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Validación mínima de entrada
        IF @COD_CIA IS NULL OR @COMPANIA_VENTA_3 IS NULL OR @ALMACEN_VENTA IS NULL OR 
           @TIPO_MOVIMIENTO IS NULL OR @TIPO_DOCUMENTO IS NULL OR @NRO_DOCUMENTO IS NULL OR
           @COD_ITEM_2 IS NULL
        BEGIN
            RAISERROR('Todos los campos de clave son obligatorios.', 16, 1);
            RETURN;
        END

        -- Consulta del registro específico
        SELECT
            COD_CIA,
            COMPANIA_VENTA_3,
            ALMACEN_VENTA,
            TIPO_MOVIMIENTO,
            TIPO_DOCUMENTO,
            NRO_DOCUMENTO,
            COD_ITEM_2,
            PROVEEDOR,
            ALMACEN_DESTINO,
            CANTIDAD,
            DOC_REF_1,
            DOC_REF_2,
            DOC_REF_3,
            DOC_REF_4,
            DOC_REF_5,
            FECHA_TRANSACCION
        FROM MOV_INVENTARIO
        WHERE
            COD_CIA = @COD_CIA AND
            COMPANIA_VENTA_3 = @COMPANIA_VENTA_3 AND
            ALMACEN_VENTA = @ALMACEN_VENTA AND
            TIPO_MOVIMIENTO = @TIPO_MOVIMIENTO AND
            TIPO_DOCUMENTO = @TIPO_DOCUMENTO AND
            NRO_DOCUMENTO = @NRO_DOCUMENTO AND
            COD_ITEM_2 = @COD_ITEM_2;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMsg, 16, 1);
    END CATCH
END
go

-- INSERT
/*
-- Caso ok
EXEC sp_InsertarInventario
    @COD_CIA = '01',
    @COMPANIA_VENTA_3 = 'A005',
    @ALMACEN_VENTA = 'ALM009',
    @TIPO_MOVIMIENTO = 'IN',
    @TIPO_DOCUMENTO = 'FV',
    @NRO_DOCUMENTO = 'INV100',
    @COD_ITEM_2 = 'ITEM100',
    @PROVEEDOR = 'Proveedor 100',
    @ALMACEN_DESTINO = 'ALM002',
    @CANTIDAD = 25,
    @FECHA_TRANSACCION = '2025-06-19';
go


-- Caso error
EXEC sp_InsertarInventario
    @COD_CIA = '01',
    @COMPANIA_VENTA_3 = 'A001',
    @ALMACEN_VENTA = 'ALM001',
    @TIPO_MOVIMIENTO = 'IN',
    @TIPO_DOCUMENTO = 'FV',
    @NRO_DOCUMENTO = 'INV001',
    @COD_ITEM_2 = 'ITEM001',
    @PROVEEDOR = 'Proveedor 1',
    @ALMACEN_DESTINO = 'ALM002',
    @CANTIDAD = 10,
    @FECHA_TRANSACCION = '2025-01-05';
go
*/
create PROCEDURE sp_InsertarInventario
    @COD_CIA            varchar(5),
    @COMPANIA_VENTA_3   varchar(5),
    @ALMACEN_VENTA      varchar(10),
    @TIPO_MOVIMIENTO    varchar(2),
    @TIPO_DOCUMENTO     varchar(2),
    @NRO_DOCUMENTO      varchar(50),
    @COD_ITEM_2         varchar(50),
    @PROVEEDOR          varchar(100) = NULL,
    @ALMACEN_DESTINO    varchar(50)  = NULL,
    @CANTIDAD           int          = NULL,
    @DOC_REF_1          varchar(50)  = NULL,
    @DOC_REF_2          varchar(50)  = NULL,
    @DOC_REF_3          varchar(50)  = NULL,
    @DOC_REF_4          varchar(50)  = NULL,
    @DOC_REF_5          varchar(50)  = NULL,
    @FECHA_TRANSACCION  DATE         = NULL
AS
BEGIN
    set nocount on;

    BEGIN TRY
        -- Validar campos obligatorios
        if @COD_CIA IS NULL OR @COMPANIA_VENTA_3 IS NULL OR @ALMACEN_VENTA IS NULL OR
           @TIPO_MOVIMIENTO IS NULL OR @TIPO_DOCUMENTO IS NULL OR
           @NRO_DOCUMENTO IS NULL OR @COD_ITEM_2 IS NULL
        begin
            raiserror('Campos clave obligatorios no pueden ser NULL.', 16, 1)
            return;
        end

        -- Verificar si el registro ya existe
        if exists(select 1
				  from dbo.MOV_INVENTARIO
				  where	COD_CIA = @COD_CIA 
						and COMPANIA_VENTA_3 = @COMPANIA_VENTA_3
						and ALMACEN_VENTA = @ALMACEN_VENTA
						and TIPO_MOVIMIENTO = @TIPO_MOVIMIENTO
						and TIPO_DOCUMENTO = @TIPO_DOCUMENTO
						and NRO_DOCUMENTO = @NRO_DOCUMENTO
						and COD_ITEM_2 = @COD_ITEM_2
				)
        begin
            raiserror('El registro ya existe. No se puede insertar duplicado.', 16, 1)
            return
        end

        -- Insertar
        BEGIN TRANSACTION
			insert into MOV_INVENTARIO (
				COD_CIA, COMPANIA_VENTA_3, ALMACEN_VENTA, TIPO_MOVIMIENTO, TIPO_DOCUMENTO,
				NRO_DOCUMENTO, COD_ITEM_2, PROVEEDOR, ALMACEN_DESTINO, CANTIDAD,
				DOC_REF_1, DOC_REF_2, DOC_REF_3, DOC_REF_4, DOC_REF_5, FECHA_TRANSACCION
			)
			values (
				@COD_CIA, @COMPANIA_VENTA_3, @ALMACEN_VENTA, @TIPO_MOVIMIENTO, @TIPO_DOCUMENTO,
				@NRO_DOCUMENTO, @COD_ITEM_2, @PROVEEDOR, @ALMACEN_DESTINO, @CANTIDAD,
				@DOC_REF_1, @DOC_REF_2, @DOC_REF_3, @DOC_REF_4, @DOC_REF_5, @FECHA_TRANSACCION
			)

        COMMIT TRANSACTION

        print 'Registro insertado exitosamente.';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        declare @ErrorMessage nvarchar(4000) = ERROR_MESSAGE()
        declare @ErrorSeverity int = ERROR_SEVERITY()
        declare @ErrorState int = ERROR_STATE()

		-- Registrar error en LOG_ERRORES
		insert into dbo.LOG_ERRORES (NombreSP, MensajeError, Parametros, UsuarioSQL)
		VALUES ('sp_InsertarInventario',
				@ErrorMessage,
				concat('DOC: ', @NRO_DOCUMENTO, ', ITEM: ', @COD_ITEM_2),
				SYSTEM_USER)

        raiserror(@ErrorMessage, @ErrorSeverity, @ErrorState)
    END CATCH
END
go

-- UPDATE
/*
-- Caso OK
EXEC sp_ActualizarInventario
    @COD_CIA = '01',
    @COMPANIA_VENTA_3 = 'A001',
    @ALMACEN_VENTA = 'ALM001',
    @TIPO_MOVIMIENTO = 'IN',
    @TIPO_DOCUMENTO = 'FV',
    @NRO_DOCUMENTO = 'INV001',
    @COD_ITEM_2 = 'ITEM001',
    @PROVEEDOR = 'Proveedor Actualizado2',
    @ALMACEN_DESTINO = 'ALM020',
    @CANTIDAD = 99,
    @FECHA_TRANSACCION = '2025-06-20';
go

-- Caso error
EXEC sp_ActualizarInventario
    @COD_CIA = '01',
    @COMPANIA_VENTA_3 = 'X999',
    @ALMACEN_VENTA = 'ALM000',
    @TIPO_MOVIMIENTO = 'OU',
    @TIPO_DOCUMENTO = 'FV',
    @NRO_DOCUMENTO = 'NOEXISTE',
    @COD_ITEM_2 = 'XXX',
    @PROVEEDOR = 'Ninguno',
    @ALMACEN_DESTINO = NULL,
    @CANTIDAD = 1,
    @FECHA_TRANSACCION = '2025-01-01';
go
*/
CREATE PROCEDURE sp_ActualizarInventario
    @COD_CIA            VARCHAR(5),
    @COMPANIA_VENTA_3   VARCHAR(5),
    @ALMACEN_VENTA      VARCHAR(10),
    @TIPO_MOVIMIENTO    VARCHAR(2),
    @TIPO_DOCUMENTO     VARCHAR(2),
    @NRO_DOCUMENTO      VARCHAR(50),
    @COD_ITEM_2         VARCHAR(50),
    @PROVEEDOR          VARCHAR(100) = NULL,
    @ALMACEN_DESTINO    VARCHAR(50)  = NULL,
    @CANTIDAD           INT          = NULL,
    @DOC_REF_1          VARCHAR(50)  = NULL,
    @DOC_REF_2          VARCHAR(50)  = NULL,
    @DOC_REF_3          VARCHAR(50)  = NULL,
    @DOC_REF_4          VARCHAR(50)  = NULL,
    @DOC_REF_5          VARCHAR(50)  = NULL,
    @FECHA_TRANSACCION  DATE         = NULL
AS
BEGIN
    set nocount on;

    BEGIN TRY
        -- Validar existencia del registro
        if not exists (
            select 1
            from dbo.MOV_INVENTARIO
            where COD_CIA = @COD_CIA
				  and COMPANIA_VENTA_3 = @COMPANIA_VENTA_3
				  and ALMACEN_VENTA = @ALMACEN_VENTA
				  and TIPO_MOVIMIENTO = @TIPO_MOVIMIENTO
				  and TIPO_DOCUMENTO = @TIPO_DOCUMENTO
				  and NRO_DOCUMENTO = @NRO_DOCUMENTO
				  and COD_ITEM_2 = @COD_ITEM_2
			)
        begin
            raiserror('El registro que desea actualizar no existe.', 16, 1)
            return
        end

        BEGIN TRANSACTION;

			-- actualizar registro
			update dbo.MOV_INVENTARIO
			set
				PROVEEDOR = @PROVEEDOR,
				ALMACEN_DESTINO = @ALMACEN_DESTINO,
				CANTIDAD = @CANTIDAD,
				DOC_REF_1 = @DOC_REF_1,
				DOC_REF_2 = @DOC_REF_2,
				DOC_REF_3 = @DOC_REF_3,
				DOC_REF_4 = @DOC_REF_4,
				DOC_REF_5 = @DOC_REF_5,
				FECHA_TRANSACCION = @FECHA_TRANSACCION
			where
				COD_CIA = @COD_CIA AND
				COMPANIA_VENTA_3 = @COMPANIA_VENTA_3 AND
				ALMACEN_VENTA = @ALMACEN_VENTA AND
				TIPO_MOVIMIENTO = @TIPO_MOVIMIENTO AND
				TIPO_DOCUMENTO = @TIPO_DOCUMENTO AND
				NRO_DOCUMENTO = @NRO_DOCUMENTO AND
				COD_ITEM_2 = @COD_ITEM_2

        COMMIT TRANSACTION

        print 'Registro actualizado exitosamente.'
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        declare @ErrorMessage nvarchar(4000) = ERROR_MESSAGE();
        declare @ErrorSeverity int = ERROR_SEVERITY();
        declare @ErrorState int = ERROR_STATE();

        insert into LOG_ERRORES (NombreSP, MensajeError, Parametros, UsuarioSQL)
        VALUES (
            'sp_ActualizarInventario',
            @ErrorMessage,
            CONCAT('DOC: ', @NRO_DOCUMENTO, ', ITEM: ', @COD_ITEM_2),
            SYSTEM_USER
			)

        raiserror(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
go

-- DELETE
/*
-- Caso OK
EXEC sp_EliminarInventario
    @COD_CIA = '01',
    @COMPANIA_VENTA_3 = 'A001',
    @ALMACEN_VENTA = 'ALM001',
    @TIPO_MOVIMIENTO = 'IN',
    @TIPO_DOCUMENTO = 'FV',
    @NRO_DOCUMENTO = 'INV003',
    @COD_ITEM_2 = 'ITEM003';
go

-- Caso error
EXEC sp_EliminarInventario
    @COD_CIA = '01',
    @COMPANIA_VENTA_3 = 'ZZZZ',
    @ALMACEN_VENTA = 'NULO',
    @TIPO_MOVIMIENTO = 'OU',
    @TIPO_DOCUMENTO = 'NV',
    @NRO_DOCUMENTO = 'NOEXISTE',
    @COD_ITEM_2 = 'NOITEM';
go
*/
CREATE PROCEDURE sp_EliminarInventario
    @COD_CIA            VARCHAR(5),
    @COMPANIA_VENTA_3   VARCHAR(5),
    @ALMACEN_VENTA      VARCHAR(10),
    @TIPO_MOVIMIENTO    VARCHAR(2),
    @TIPO_DOCUMENTO     VARCHAR(2),
    @NRO_DOCUMENTO      VARCHAR(50),
    @COD_ITEM_2         VARCHAR(50)
AS
BEGIN
    set nocount on;

    BEGIN TRY
        -- Validar existencia
        if not exists (
            select 1
            from MOV_INVENTARIO
            where COD_CIA = @COD_CIA
				  and COMPANIA_VENTA_3 = @COMPANIA_VENTA_3
				  and ALMACEN_VENTA = @ALMACEN_VENTA
				  and TIPO_MOVIMIENTO = @TIPO_MOVIMIENTO
				  and TIPO_DOCUMENTO = @TIPO_DOCUMENTO
				  and NRO_DOCUMENTO = @NRO_DOCUMENTO
				  and COD_ITEM_2 = @COD_ITEM_2
			)
        begin
            raiserror('No se encontró el registro que se desea eliminar.', 16, 1)
            return
        end

        BEGIN TRANSACTION

			DELETE FROM dbo.MOV_INVENTARIO
			WHERE COD_CIA = @COD_CIA
				  and COMPANIA_VENTA_3 = @COMPANIA_VENTA_3
				  and ALMACEN_VENTA = @ALMACEN_VENTA
				  and TIPO_MOVIMIENTO = @TIPO_MOVIMIENTO
				  and TIPO_DOCUMENTO = @TIPO_DOCUMENTO
				  and NRO_DOCUMENTO = @NRO_DOCUMENTO
				  and COD_ITEM_2 = @COD_ITEM_2

        COMMIT TRANSACTION;

        PRINT 'Registro eliminado correctamente.'
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        declare @ErrorMessage nvarchar(4000) = ERROR_MESSAGE()
        declare @ErrorSeverity int = ERROR_SEVERITY()
        declare @ErrorState int = ERROR_STATE()

        -- Log del error
        insert into LOG_ERRORES (NombreSP, MensajeError, Parametros, UsuarioSQL)
        VALUES ('sp_EliminarInventario',
				@ErrorMessage,
				CONCAT('DOC: ', @NRO_DOCUMENTO, ', ITEM: ', @COD_ITEM_2),
				SYSTEM_USER
				)

        raiserror(@ErrorMessage, @ErrorSeverity, @ErrorState)
    END CATCH
END
go

-- LOGIN
/*
exec sp_Login @Usuario = 'admin', @Clave = 'admin'
*/
CREATE PROCEDURE sp_Login
    @Usuario VARCHAR(30),
    @Clave VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IdUsuario INT,
            @Nombre VARCHAR(200),
            @Estado INT;

    IF NOT EXISTS (SELECT 1 FROM dbo.USUARIOS WHERE Usuario = @Usuario)
    BEGIN
        SELECT 
            0 AS Codigo,
            'El usuario no existe.' AS Mensaje,
            NULL AS IdUsuario,
            NULL AS Nombre,
            NULL AS Usuario;
        RETURN;
    END

    SELECT TOP 1 
        @IdUsuario = IdUsuario,
        @Nombre = Nombre,
        @Estado = Estado
    FROM dbo.USUARIOS
    WHERE Usuario = @Usuario AND Clave = @Clave

    IF @IdUsuario IS NULL
    BEGIN
        SELECT 
            0 AS Codigo,
            'Contraseña incorrecta.' AS Mensaje,
            NULL AS IdUsuario,
            NULL AS Nombre,
            NULL AS Usuario
        RETURN
    END

    IF @Estado = 0
    BEGIN
        SELECT 
            0 AS Codigo,
            'El usuario está inactivo.' AS Mensaje,
            NULL AS IdUsuario,
            NULL AS Nombre,
            NULL AS Usuario
        RETURN
    END

    -- Éxito
    SELECT 
        1 AS Codigo,
        'Inicio de sesión correcto.' AS Mensaje,
        @IdUsuario AS IdUsuario,
        @Nombre AS Nombre,
        @Usuario AS Usuario
END
GO

-- select * from MOV_INVENTARIO
-- select * from LOG_ERRORES