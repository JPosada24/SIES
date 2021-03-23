create table usuarios(
	usu_id int identity Primary Key,
	usu_documento bigint,
	usu_tipoDoc varchar(30),
	usu_nombre varchar(40),
	usu_celular bigint,
	usu_email varchar(50),
	usu_genero varchar(20),
	usu_aprendiz varchar(20),
	usu_egresado varchar(20),
	usu_areaFormacion varchar(30),
	usu_fechaEgresado date,
	usu_direccion varchar(50),
	usu_barrio varchar(30),
	usu_ciudad varchar(30),
	usu_departamento varchar(30),
	usu_fechaRegistro date
);