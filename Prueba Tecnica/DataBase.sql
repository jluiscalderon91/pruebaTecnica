create database Prueba
go
use Prueba
go

create table Usuario
(
codigoUsuario int primary key identity
nombre varchar(100) 
apellido varchar(100)
genero char(1)
email varchar(100)
estado int 
)

insert into Usuario values ('juan M', 'prieto L', 'M' , 'juan20@hotmail', 1)

-- codigo | nombre | apellido | genero |     email      | estado
--     1  | juan M | prieto L |   M    | juan20@hotmail |    1


create table Perfil
(
 codigoPerfil int primary key identity
 nombrePerfil varchar(100)
 estado int 
)

insert into Perfil values ('Administrador',1)
insert into Perfil values ('Supervisor',1)
insert into Perfil values ('Operario',1)

-- codigoPerfil | nombrePerfil | estado
--      1       | Administrador| 1 
--      2       | Supervisor   | 1 
--      3       | Operario     | 1 

create table UsuarioPerfil
(
 codigoUsuarioPerfil int primary key identity
 codigoUsuario int 
 CodigoPerfil int
 estado int 
)

-- codigoUsuarioPerfil | codigoUsuario | CodigoPerfil | estado
--           1         |        1      |      1       |   1
--           2         |        1      |      2       |   1
--           3         |        1      |      3       |   1

insert into UsuarioPerfil values (1,1,1)
insert into UsuarioPerfil values (1,2,1)
insert into UsuarioPerfil values (1,3,1)


Select u.codigoUsuario,u.nombre,u.apellido, p.nombrePerfil from Usuario u
Inner join UsuarioPerfil up u.codigoUsuario = up.codigoUsuario
Inner join Perfil p up.codigoPerfil = u.codigoPerfil
group by u.codigoUsuario
order by u.codigoUsuario desc
