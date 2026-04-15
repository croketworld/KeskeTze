Imports System.Runtime.CompilerServices
Imports Crkw.BL.KeskeTzeLib
Imports KeskeTzeModelLibrary

Public Module ServicioOProcesoFunctions

    <Extension>
    Public Function GetGuid(servicioOProceso As ServicioOProceso) As Guid
        Dim resultado As Guid = Guid.Empty

        resultado = GuidDeterminista.GenerarGuidDesdeSemilla(servicioOProceso.GetHashCode)

        Return resultado
    End Function

    ''' <summary>
    ''' Obtiene el <see cref="KeskeTzeModelLibrary.ServicioOProceso.NombreCorto">NombreCorto</see>  de un <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see>
    ''' </summary>
    ''' <param name="servicioOProceso"> Instancia de <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see></param>
    ''' <remarks>El <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see>debe estar instanciado y tener un valor en algunas de las propiedades <see cref="KeskeTzeModelLibrary.ServicioOProceso.Nombre"></see> o <see cref="KeskeTzeModelLibrary.ServicioOProceso.Ruta"></see> </remarks>
    ''' <returns>Devuelve <see cref="KeskeTzeModelLibrary.ServicioOProceso.NombreCorto">NombreCorto</see>  de un <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see></returns>
    ''' <example>
    ''' (entrada) servicioOProceso.Nombre = " Estacion de trabajo"
    ''' (salida) resultado = " EsdeTr"
    ''' </example>
    <Extension>
    Public Function GetNombreCorto(servicioOProceso As ServicioOProceso) As String
        Dim resultado As String = ""
        If String.IsNullOrEmpty(servicioOProceso.Nombre) And (String.IsNullOrEmpty(servicioOProceso.Ruta) = False) Then
            resultado = NombreCorto.GenerarNombreCortoDesdeRuta(servicioOProceso.Ruta)
        ElseIf String.IsNullOrEmpty(servicioOProceso.Ruta) And (String.IsNullOrEmpty(servicioOProceso.Nombre) = False) Then
            resultado = NombreCorto.GenerarNombreCortoDesdeLargo(servicioOProceso.Nombre)
        Else
            Throw New ArgumentNullException("El ServicioOProceso usado cómo argumento no tiene establecidas la propiedad Ruta ni la propiedad nombre." & Environment.NewLine &
                                            "Se requiere al menos una de las dos propiedades para obtener el NombreCorto")
        End If
        Return resultado
    End Function


End Module

