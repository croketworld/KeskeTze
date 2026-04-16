Imports System.IO

''' <summary>
''' Genera un nombre corto, alias o abreviatura desde un nombre largo o una ruta de archivo o ejecución.
''' </summary>
Public Module NombreCorto

    ''' <summary>
    ''' Función que invoca <see cref="GenerarNombreCortoDesdeLargo(String)">GenerarNombreCortoDesdeLargo</see> o <see cref="GenerarNombreCortoDesdeRuta(String)">GenerarNombreCortoDesdeLargo</see> dependiendo de si
    ''' </summary>
    ''' <param name="nombreLargoORuta">EL nombre largo o ruta de ejecución (con o sin argumentos)</param>
    ''' <returns></returns>
    Public Function GenerarNombreCortoDesdeNombreLargoORuta(nombreLargoORuta As String) As String
        Dim rutaONombreLargoSinArgumentos As String = QuitarArgumentosDeEjecucionDeRuta(nombreLargoORuta)
        Dim res As String =
        IIf(IO.File.Exists(rutaONombreLargoSinArgumentos),
            GenerarNombreCortoDesdeRuta(nombreLargoORuta),
            GenerarNombreCortoDesdeLargo(nombreLargoORuta))
        Return res
    End Function

    ''' <summary>
    ''' Devuelve un string en CamelCase obteniendo las dos primeras letras de cada parte del texto introducido cómo parametro de nombreLargo.
    ''' </summary>
    ''' <param name="nombreLargo">El nombre completo a recortar</param>
    ''' <returns>Devuelve un string en CamelCase obteniendo las dos primeras letras de cada parte del texto.</returns>
    ''' <remarks>Si un tramo sólo tiene una letra o es preposición, se usa una letra en vez de dos</remarks>
    ''' <example>
    ''' (entrada)  Estacion de trabajo
    ''' (salida) EsDTr
    ''' </example>
    Public Function GenerarNombreCortoDesdeLargo(nombreLargo As String) As String
        Dim nombrelargoSinLineas As String = nombreLargo.Replace(Environment.NewLine, " ").Trim
        Dim partes As String() = nombrelargoSinLineas.Split(" ")
        Dim res As String = ""

        For indiceParte As Integer = 0 To partes.Length
            Dim parte As String = partes(indiceParte).ToLower
            ''' SI la longitud es superior a 1 carácter, tomamos los dos primeros solamente
            Dim trozoParte As String = IIf(parte.Length > 1, parte.Substring(0, 2), parte.Substring(0, 1))

            Dim esArticulo As Boolean = Constantes.Articulos.Contains(trozoParte)
            Dim anteriorEsPreposicion As Boolean = False
            If indiceParte > 0 Then anteriorEsPreposicion = Constantes.Preposiciones.Contains(partes(indiceParte - 1))

            If esArticulo And anteriorEsPreposicion Then
                '''Si es artículo.  tomar todo en minúsculas
                If trozoParte.Length = 3 Then
                    '''SI el artículo tiene tres letras, tomar la primera y la ultima
                    trozoParte = trozoParte(0) & trozoParte(2)
                ElseIf trozoParte.Length = 4 Then
                    '''SI el artículo tiene cuatro letras, tomar la primera, la segunda y la ultima
                    trozoParte = trozoParte(0) & trozoParte(1) & trozoParte(3)
                Else '''SI el artículo tiene dos letras, se toma tal cual
                    '''No hay nada que hacer si pasa por aquí, que es en el caso de que el artículo tenga dos letras.
                End If
            Else ''En cualqier otro caso de que no sea artículo
                '''Primero se obtiene la primera letra en mayúscula 
                '''Dim primeraLetraMayuscula As Char = Char.ToUpper(trozoParte.FirstOrDefault)
                trozoParte = Char.ToUpper(trozoParte.FirstOrDefault)
                If Constantes.Preposiciones.Contains(trozoParte) = False Then
                    '''si no es preposición, tomamos más allá de la primera letra en mayúscula
                    '''Si es preposición, por ejemplo "de" se convierte en "D"
                    trozoParte += trozoParte.Substring(1)
                End If
            End If
            res += trozoParte
        Next
        Return res.Trim
    End Function

    ''' <summary>
    ''' Devuelve el nombre de un archivo sin extensión desde su ruta completa de ejecución
    ''' </summary>
    ''' <param name="ruta">Ruta completa de ejecución</param>
    ''' <returns></returns>
    Public Function GenerarNombreCortoDesdeRuta(ruta As String) As String
        Dim rutaAlArchivo As String = QuitarArgumentosDeEjecucionDeRuta(ruta)
        If IO.File.Exists(rutaAlArchivo) = False Then
            Throw New FileNotFoundException(
                $"No existe el archivo {rutaAlArchivo}.{Environment.NewLine} La ruta completa introducida es {ruta} .")
        End If
        Dim ff As New IO.FileInfo(rutaAlArchivo)
        Dim nombreArchivo As String = ff.Name
        If nombreArchivo.Contains(ff.Extension) Then nombreArchivo = nombreArchivo.Replace(ff.Extension, "")
        Return GenerarNombreCortoDesdeLargo(nombreArchivo)
    End Function

    ''' <summary>
    ''' Devuelve la ruta completa a un archivo desde su ruta de ejecución
    ''' </summary>
    ''' <param name="rutaEjecucion">Ruta de ejecución</param>
    ''' <returns></returns>
    ''' <example>
    ''' (entrada) rutaEjecución = "C:\WINDOWS\System32\svchost.exe -k NetworkService -p"
    ''' (salida) resultado = "C:\WINDOWS\System32\svchost.exe"
    ''' </example>
    Public Function QuitarArgumentosDeEjecucionDeRuta(rutaEjecucion As String) As String
        Dim partePrincipal As String = rutaEjecucion.Trim()
        If rutaEjecucion.Contains(" -") Then
            partePrincipal = rutaEjecucion.Split(" -")(0).Trim
        End If
        Return partePrincipal
    End Function

    ''' <summary>
    ''' Devuelve el nombre de un archivo sin extensión, y si estaba en formato CamelCase, añade espacios delante de las mayúsculas
    ''' </summary>
    ''' <param name="rutaEjecucion">Ruta de ejecución o ruta completa al archivo</param>
    ''' <returns></returns>
    ''' <example>
    ''' (entrada) rutaEjecución = "C:\WINDOWS\System32\svchost.exe -k NetworkService -p"
    ''' (salida) resultado = "C:\WINDOWS\System32\svchost.exe"
    ''' </example>
    Public Function ObtenerNombreDeEjecutable(rutaEjecucion As String) As String
        Dim partePrincipal As String = rutaEjecucion.Trim()
        If rutaEjecucion.Contains(" -") Then
            partePrincipal = rutaEjecucion.Split(" -")(0).Trim
        End If
        Dim existeYs As Boolean = False
        Dim ff As System.IO.FileInfo = Nothing
        Try
            ff = New IO.FileInfo(rutaEjecucion)
            existeYs = True
        Catch ex As Exception

        End Try
        Dim resultado As String = partePrincipal.Replace(ff.DirectoryName, "").Replace(ff.Extension, "")
        If resultado.First = "\" Then resultado = resultado.Substring(1)
        If ContieneAlgunaMayuscula(resultado) Then
            Dim ooaoaoao As String = ""
            Dim anteriorMayusIndice As Integer = 0
            For i As Integer = 0 To resultado.Length
                Dim caracter As Char = resultado(i)
                If Char.IsUpper(caracter) Then
                    If anteriorMayusIndice > 0 Then ooaoaoao += " "
                    anteriorMayusIndice = i
                End If
                ooaoaoao += caracter
            Next
            Return ooaoaoao
        End If
        Return resultado
    End Function

    ''' <summary>
    ''' Determina si una cadena contiene alguna mayúscula
    ''' </summary>
    ''' <param name="cadena"></param>
    ''' <returns></returns>

    Public Function ContieneAlgunaMayuscula(cadena As String) As Boolean
        For i As Integer = 0 To cadena.Length
            If Char.IsUpper(cadena(i)) Then Return True
        Next
        Return False
    End Function

End Module
