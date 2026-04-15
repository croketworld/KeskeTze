Imports System.IO

Public Module NombreCorto

    ''' <summary>
    ''' Lista de preposiciones para el acortado de nombre.
    ''' </summary>
    ''' <example>
    ''' (entrada)  Estacion de trabajo
    ''' (salida) EsDTr
    ''' convirtiendo la preposuición 'de' en 'D'
    ''' </example>
    Private Preposiciones As String() = {"a", "ante", "bajo", "cabe", "con", "contra", "de", "desde", "durante", "en", "entre", "hacia", "hasta", "mediante", "para", "por", "según", "sin", "so", "sobre", "tras"}


    ''' <summary>
    ''' Lista de artículos para el acortado de nombres.
    ''' </summary>
    ''' <remarks>Usado en combinación de las preposiciones.</remarks>
    ''' <example>
    ''' (entrada)  Estacion de los trabajos
    ''' (salida) EsDlsTr
    ''' </example>
    Private Articulos As String() = {"el", "la", "los", "las", "lo", "un", "una", "unos", "unas"}


    Public Function GenerarNombreCortoDesdeNombreLargoORuta(nombreLargoORuta As String) As String
        Dim res As String =
        IIf(IO.File.Exists(nombreLargoORuta),
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

            Dim esArticulo As Boolean = Articulos.Contains(trozoParte)
            Dim anteriorEsPreposicion As Boolean = False
            If indiceParte > 0 Then anteriorEsPreposicion = Preposiciones.Contains(partes(indiceParte - 1))

            If esArticulo And anteriorEsPreposicion Then ''Si es artículo.  tomar todo en minúsculas
                'SI el artículo tiene dos letras, se toma tal cual
                If trozoParte.Length = 3 Then 'SI el artículo tiene tres letras, tomar la primera y la ultima
                    trozoParte = trozoParte(0) & trozoParte(2)
                ElseIf trozoParte.Length = 4 Then 'SI el artículo tiene cuatro letras, tomar la primera, la segunda y la ultima
                    trozoParte = trozoParte(0) & trozoParte(1) & trozoParte(3)
                End If
            Else ''En cualqier otro caso de que no sea artículo
                '''Primero se obtiene la primera letra en mayúscula 
                '''Dim primeraLetraMayuscula As Char = Char.ToUpper(trozoParte.FirstOrDefault)
                trozoParte = Char.ToUpper(trozoParte.FirstOrDefault)
                If Preposiciones.Contains(trozoParte) = False Then
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
    Private Function QuitarArgumentosDeEjecucionDeRuta(rutaEjecucion As String) As String
        Dim partePrincipal As String = rutaEjecucion.Trim
        If rutaEjecucion.Contains(" -") Then
            partePrincipal = rutaEjecucion.Split(" -")(0).Trim
        End If
        Return partePrincipal
    End Function

End Module
