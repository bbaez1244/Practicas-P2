

create procedure CreateEmpresa @Nombre varchar (30), @Representante varchar (30), @RNC varchar (30), @Direccion varchar (30)
as
INSERT INTO empresas (Nombre, Representante, RNC, Direccion, Borrado) VALUES (@Nombre, @Representante, @RNC, @Direccion, 0)

go

create procedure GetAll
as
SELECT RNC, Nombre, Representante FROM empresas WHERE borrado = 0

go

create procedure FindByRNC @RNC varchar (30)
as
SELECT RNC, Nombre, Representante FROM empresas WHERE RNC = @RNC AND borrado = 0

go

create procedure UpdateEmpresa @Direccion varchar (30), @Representante varchar (30), @RNC varchar (30)
as
UPDATE empresas SET Direccion = @Direccion, Representante = @Representante WHERE RNC = @RNC AND Borrado=0

go

create procedure SoftDelete @RNC varchar (30)
as
UPDATE empresas SET Borrado = 1 WHERE RNC = @RNC

go

EXEC CreateEmpresa 'Empresa Mercedes', 'Genaro Mercedes', '1-45-67890-1', 'Villa Mella'
EXEC GetAll
EXEC FindByRNC '1-12-34567-9'
EXEC UpdateEmpresa 'Sol de Luz', 'Matilde Mercedes', '1-45-67890-1'
EXEC SoftDelete '1-12-34567-9'