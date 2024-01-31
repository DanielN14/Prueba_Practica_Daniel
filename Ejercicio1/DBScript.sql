CREATE DATABASE UserRegistryApp;

USE UserRegistryApp;

CREATE TABLE test_Usuarios (
  IdUsuario INT IDENTITY(1, 1),
  Nombre VARCHAR(30) NOT NULL,
  PrimerApellido VARCHAR(30) NOT NULL,
  SegundoApellido VARCHAR(30),
  Identificacion VARCHAR(15) UNIQUE NOT NULL,
  TipoIdentificacion VARCHAR(15) NOT NULL,-- (Nacional, Extranjero.)
  Email VARCHAR(100) NOT NULL,
  NombreUsuario VARCHAR(30) NOT NULL,
  Clave VARCHAR(50) NOT NULL,
  IdRolUsuario INT NOT NULL,
  IsDeleted BIT NOT NULL DEFAULT 0,

  CONSTRAINT PK_test_Users PRIMARY KEY(IdUsuario)
);

CREATE TABLE test_Telefonos (
  IdTelefono INT IDENTITY(1, 1),
  IdUsuario INT NOT NULL,
  NumeroTelefono VARCHAR(15) NOT NULL,
  IsDeleted BIT NOT NULL DEFAULT 0,

  CONSTRAINT PK_test_Telefonos PRIMARY KEY(IdTelefono, IdUsuario)
);

CREATE TABLE test_Roles (
  IdRolUsuario INT IDENTITY(1, 1),
  NombreRol VARCHAR(40) NOT NULL, -- (administrador o consultor) 
  IsDeleted BIT NOT NULL DEFAULT 0,

  CONSTRAINT PK_test_Roles PRIMARY KEY(IdRolUsuario)
);

CREATE TABLE test_HabilidadesBlandas (
  IdHabilidadBlanda INT IDENTITY(1, 1),
  NombreHabilidadBlanda VARCHAR(40) NOT NULL,
  IsDeleted BIT NOT NULL DEFAULT 0,

  CONSTRAINT PK_test_HabilidadesBlandas PRIMARY KEY(IdHabilidadBlanda)
);

CREATE TABLE test_HabilidadesBlandasXUsuario (
  IdHabilidadBlanda INT NOT NULL,
  IdUsuario INT NOT NULL,
  IsDeleted BIT NOT NULL DEFAULT 0,

  CONSTRAINT PK_test_HabilidadesBlandasXUsuario PRIMARY KEY(IdHabilidadBlanda, IdUsuario)
);

-- USUARIOS 
ALTER TABLE test_Usuarios ADD FOREIGN KEY (idRolUsuario) REFERENCES test_Roles(idRolUsuario);

-- Telefonos 
ALTER TABLE test_Telefonos ADD FOREIGN KEY (IdUsuario) REFERENCES test_Usuarios(IdUsuario);

-- HabilidadesBlandasXUsuario 
ALTER TABLE test_HabilidadesBlandasXUsuario ADD FOREIGN KEY (IdHabilidadBlanda) REFERENCES test_HabilidadesBlandas(IdHabilidadBlanda);
ALTER TABLE test_HabilidadesBlandasXUsuario ADD FOREIGN KEY (IdUsuario) REFERENCES test_Usuarios(IdUsuario);

-- Registro 1
INSERT INTO test_Roles (NombreRol)
VALUES ('Administrador');

-- Registro 2
INSERT INTO test_Roles (NombreRol)
VALUES ('Consultor');


-- Registro 1
INSERT INTO test_HabilidadesBlandas (NombreHabilidadBlanda)
VALUES ('Buena comunicación');

INSERT INTO test_HabilidadesBlandas (NombreHabilidadBlanda)
VALUES ('Buena organización');

INSERT INTO test_HabilidadesBlandas (NombreHabilidadBlanda)
VALUES ('Trabajo en equipo');

INSERT INTO test_HabilidadesBlandas (NombreHabilidadBlanda)
VALUES ('Puntualidad');

INSERT INTO test_HabilidadesBlandas (NombreHabilidadBlanda)
VALUES ('Ser creativo');

INSERT INTO test_HabilidadesBlandas (NombreHabilidadBlanda)
VALUES ('Facilidad de adaptación');