/****************************************************************************************/
/****************************		 TABLA USUARIOS		   ******************************/
/****************************************************************************************/
ALTER TABLE USR01(
-- DATOS DE SESIÓN
USRNAME		CHAR(50)	PRIMARY KEY		NOT NULL, --NOMBRE DE USUARIO
USPASS		CHAR(32)					NOT NULL, --CONTRASEÑA
-- DATOS DEL USUARIO
FNAME		CHAR(50)					NOT NULL, --NOMBRES
LNAME		CHAR(50)					NOT NULL, --APELLIDOS
BDATE		DATE						NOT NULL, --FECHA DE NACIMIENTO
SEX			CHAR(1)						NOT NULL, --SEXO
-- DATOS DE CONTROL DE SESIÓN
USTRIES		INT							NOT NULL, --INTENTOS DE INICIO DE SESION
ISBLOCKED	CHAR(1)						NOT NULL, --MARCA DE BLOQUEO DE USUARIO
ISRECOV		CHAR(1)						NOT NULL, --MARCA DE CONTRASEÑA RECUPERADA
-- DÍGITO VERIFICADOR DE REGISTRO
DVH			INT							NOT NULL  --DIGITO VERIFICADOR HORIZONTAL
)

