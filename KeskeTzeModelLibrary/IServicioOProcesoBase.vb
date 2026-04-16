
Imports Crkw.BL.KeskeTzeLib

''' <summary>
''' Interfaz que establece la estructura de la clase <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see>.
''' </summary>
''' <remarks>
''' <see cref="KeskeTzeModelLibrary.IServicioOProcesoBase">servicioOProceso</see> sirve para definir un proceso o un servicio.
''' </remarks>
Public Interface IServicioOProcesoBase
    ''' <summary>
    ''' Nombre del servicio o proceso
    ''' </summary>
    ''' <returns></returns>
    Property Nombre As String

    ''' <summary>
    ''' Alias del servicio o proceso
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>En formato CamelCase y sin espacios</remarks>
    Property NombreCorto As String
    ''' <summary>
    ''' Si es un servicio u un proceso
    ''' </summary>
    ''' <returns></returns>
    Property Tipo As ETipoServicioOProceso
    ''' <summary>
    ''' La ruta donde se encuentra el ejecutable
    ''' </summary>
    ''' <returns></returns>
    Property Ruta As String

End Interface
