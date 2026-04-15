Public Class ServicioOProcesoMetaData


#Region "propiedades"

    ''' <summary>
    ''' Identificador único global del <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see>
    ''' </summary>
    ''' <returns></returns>
    Public Property ServicioOProcesoId As Guid

    ''' <summary>
    ''' El <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see> relacionado
    ''' </summary>
    ''' <returns></returns>
    Public Property ServicioOProceso As ServicioOProceso

    ''' <summary>
    ''' La ruta por defecto en la que suele encontrarse el servicio o proceso
    ''' </summary>
    ''' <returns></returns>
    Public Property RutaComunPorDefecto As String

    ''' <summary>
    ''' Las rutas alternativas donde se puede encontrar el ejecutable
    ''' </summary>
    ''' <returns></returns>
    Public Property RutasAlternativas As String()

    ''' <summary>
    ''' Descripción del <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see>
    ''' </summary>
    ''' <returns></returns>
    Public Property Descripcion As String



#End Region

#Region "constructores"

    Public Sub New(servicioOProceso As ServicioOProceso)
        Me.ServicioOProceso = servicioOProceso
        Me.ServicioOProcesoId = servicioOProceso.GetHashCode()
    End Sub


    Public Sub New()

    End Sub

#End Region

#Region "operadores"


#End Region


End Class
