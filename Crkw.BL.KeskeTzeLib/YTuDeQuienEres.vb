Imports System.IO
Imports System.Linq.Expressions

''' <summary>
''' De marujitaaaa le dije yo
''' </summary>
Public Class YTuDeQuienEres

    ''' <summary>
    ''' Determina si un archivo es un ejecutable en base a su extensión.
    ''' </summary>
    ''' <remarks> Comprueba si la extensión está en la lista de <see cref="Constantes.ExtensionesEjecutables">Crkw.BL.KeskeTzeLib.Constantes.ExtensionesEjecutables</see> </remarks>
    ''' <param name="rutaAlArchivo">ruta completa al archivo</param>
    ''' <returns></returns>
    Public Shared Function EsEjecutable(rutaAlArchivo As String) As Boolean
        Dim ff As System.IO.FileInfo = Nothing
        Try
            ff = New IO.FileInfo(rutaAlArchivo)
        Catch ex As Exception

        End Try
        If ff IsNot Nothing And ff.Exists Then Return Constantes.ExtensionesEjecutables.Contains(ff.Extension.Substring(1))
        Return False
    End Function

    ''' <summary>
    ''' Determina si el archivo es una librería dll compilada
    ''' </summary>
    ''' <param name="rutaAlArchivo"></param>
    ''' <returns></returns>
    Public Shared Function EsLibreriaCompilada(rutaAlArchivo As String) As Boolean
        Return ExtensionDeArchivoSinPuntoPorFavor(rutaAlArchivo) = "dll"
    End Function

    ''' <summary>
    ''' Determina si un archivo existe, está presente y accesible
    ''' </summary>
    ''' <param name="rutaAlArchivo">Ruta completa al archivo</param>
    ''' <returns></returns>
    Public Shared Function ExisteYEs(rutaAlArchivo As String) As Boolean
        Dim existeYs As Boolean = False
        Dim ff As System.IO.FileInfo
        Try
            ff = New IO.FileInfo(rutaAlArchivo)
            existeYs = True
        Catch ex As Exception

        End Try
        Return existeYs
    End Function

    ''' <summary>
    ''' Devuelve la extensión de un archivo desde su ruta completa, sin punto y en minúsculas
    ''' </summary>
    ''' <param name="rutaAlArchivo">Ruta completa al archivo</param>
    ''' <returns></returns>
    Public Shared Function ExtensionDeArchivoSinPuntoPorFavor(rutaAlArchivo As String) As String
        Dim existeYs As Boolean = False
        Dim ff As System.IO.FileInfo = Nothing
        Dim excepcionCapturada As Exception = Nothing
        Dim errorMessageBase As String = "No se ha podido determinar la extensión del archivo con el método YTuDeQuienEres.ExtensionDeArchivoSinPuntoPorFavor debido a "
        Try
            ff = New IO.FileInfo(rutaAlArchivo)
            existeYs = ff.Exists
        Catch ex As Exception
            excepcionCapturada = ex
        End Try
        If existeYs And ff IsNot Nothing Then
            Dim extension As String = ff.Extension
            Return IIf(extension.Length > 1, ff.Extension.Substring(1).ToLower(), Nothing)
        End If
        If excepcionCapturada IsNot Nothing Then
            Dim tipoExceep As String = excepcionCapturada.GetType().Name
            Select Case tipoExceep
                Case GetType(ArgumentNullException).Name, GetType(ArgumentException).Name
                    errorMessageBase += "qué el argumento introducido no es válido (argumento: " & rutaAlArchivo & Environment.NewLine
                Case GetType(Security.SecurityException).Name, GetType(UnauthorizedAccessException).Name
                    errorMessageBase += "la seguridad y permisos en el sistema de archivos sobre el archivo " & rutaAlArchivo & Environment.NewLine
                Case GetType(PathTooLongException).Name, GetType(NotSupportedException).Name
                    errorMessageBase += "que la ruta es muy larga o el stream del archivo está bloqueado" & rutaAlArchivo & Environment.NewLine
            End Select
            Dim msgErroor As String = errorMessageBase
            Dim exresult As New ApplicationException(msgErroor, excepcionCapturada)
            Throw exresult
        End If
        Return Nothing
    End Function

End Class
