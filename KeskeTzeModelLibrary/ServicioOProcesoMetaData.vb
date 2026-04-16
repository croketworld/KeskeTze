
''' <summary>
''' Los metadatos de un <see cref="ServicioOProceso">ServicioOProceso</see>.
''' </summary>
Public Class ServicioOProcesoMetaData
    Implements IServicioOProcesoMetaData


#Region "propiedades"

    ''' <summary>
    ''' Identificador único global del <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see>
    ''' </summary>
    ''' <returns></returns>
    Public Property ServicioOProcesoId As Guid Implements IServicioOProcesoMetaData.ServicioOProcesoId

    ''' <summary>
    ''' El <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see> relacionado
    ''' </summary>
    ''' <returns></returns>
    Public Property ServicioOProceso As ServicioOProceso Implements IServicioOProcesoMetaData.ServicioOProceso

    ''' <summary>
    ''' La ruta por defecto en la que suele encontrarse el servicio o proceso
    ''' </summary>
    ''' <returns></returns>
    Public Property RutaComunPorDefecto As String Implements IServicioOProcesoMetaData.RutaComunPorDefecto

    ''' <summary>
    ''' Las rutas alternativas donde se puede encontrar el ejecutable
    ''' </summary>
    ''' <remarks>Rutas conocidas</remarks>
    ''' <returns></returns>
    Public Property RutasAlternativas As String() Implements IServicioOProcesoMetaData.RutasAlternativas

    ''' <summary>
    ''' Descripción del <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see>
    ''' </summary>
    ''' <returns></returns>
    Public Property Descripcion As String Implements IServicioOProcesoMetaData.Descripcion



#End Region

#Region "constructores"


    Public Sub New(servicioOProceso As ServicioOProceso, Optional descripcion As String = "", Optional rutasAlternativas As String() = Nothing)
        Me.ServicioOProceso = servicioOProceso
        Me.ServicioOProcesoId = Crkw.BL.KeskeTzeLib.GenerarGuidDesdeSemilla(servicioOProceso.GetHashCode())
        Me.RutaComunPorDefecto = servicioOProceso.Ruta
    End Sub


    Public Sub New()

    End Sub

#End Region

#Region "operadores"


#End Region


End Class
