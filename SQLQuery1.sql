CREATE TABLE Usuarios(
UsuarioId int primary key identity,
Nombre varchar(100),
Correo varchar(100),
Contrasena varchar(100),
);

CREATE TABLE Tareas(
TareaId int primary key identity,
UsuarioId int references Usuarios(UsuarioId),
Titulo varchar(200),
Descripcion varchar(500),
FechaVencimiento datetime,
Prioridad int,
Estado int

);


create proc ProObtenerTareas
@Titulo varchar(200),
@UsuarioId int
as
begin

  select Titulo,TareaId from Tareas where Titulo like @Titulo +'%' and UsuarioId = @UsuarioId

end

go