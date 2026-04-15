
#	ToDo List

##	Capa 0-Externa


###	Crkw.BL.KeskeTzeLib

------------------------------------------------------------------------------------
|                         Crkw.BL.KeskeTzeLib\NombreCorto.vb                       |
------------------------------------------------------------------------------------
####	NombreCorto.vb
------------------------------------------------------------------------------------
|xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|
------------------------------------------------------------------------------------
(Tests)	-	[Lugar]	
				.Articulos
			[Descripción]
				Añadir test de integridad conforme ningún valor tiene más de 4 carácteres.
			[Explicación]
				La lógica de GenerarNombreCortoDesdeLargo(nombreLargo) 
				se apoya en que los artículos de la lengua Española (es-ES)
				tienen cómo máximo 4 carácteres de longitud.
				El test valida que no se han modificado los valores de texto "hardcodeado".
				[{Futuro,Modificación,Tests}]	El test tendrá que ser modificado si la RAE añade alguna palabra a la lista de lo que se considera, son Artículos aceptados.
------------------------------------------------------------------------------------
(Code)	-	[Lugar]	
				.QuitarArgumentosDeEjecucionDeRuta(rutaEjecucion)
			[Descripción]
				Además de argumentos con "-argumento", deberá poder trabajar con "/argumento".
			[Explicación]
				Hay desarrolladores que no se enteran de la copla,
				y no entienden el desastre que es usar "/" 
				para definir parámetros en línea de comandos,
				y esto es debido principalmente, al sistema de rutas de archivos Unix, que usa "/" cómo separador de niveles.
------------------------------------------------------------------------------------
(Code)	-	[Lugar]	
				.QuitarArgumentosDeEjecucionDeRuta(rutaEjecucion)
			[Descripción]
				Debe funcionar con rutas de directorios además de rutas de archivos. 
			[Explicación]
				Aunque la aplicación KeskeTze se base en servicios y aplicaciones 
				(ejecutables, que siempre son archivos), 
				la librería Crkw.BL.KeskeTzeLib está diseñada por arquitectura,
				para ser usada en más sitios en una unificación futura con más librerías, 
				y las funciones de la clase NombreCorto se unirán en otra librería destinada a funciones de texto.
------------------------------------------------------------------------------------
|xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|
------------------------------------------------------------------------------------
