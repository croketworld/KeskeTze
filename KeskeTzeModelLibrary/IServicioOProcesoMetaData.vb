Public Interface IServicioOProcesoMetaData
    ''' <summary>
    ''' Descripción del <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see>
    ''' </summary>
    ''' <returns></returns>
    Property Descripcion As String

    ''' <summary>
    ''' La ruta por defecto en la que suele encontrarse el servicio o proceso
    ''' </summary>
    ''' <returns></returns>
    Property RutaComunPorDefecto As String
    ''' <summary>
    ''' Las rutas alternativas donde se puede encontrar el ejecutable
    ''' </summary>
    ''' <returns></returns>
    Property RutasAlternativas As String()
    ''' <summary>
    ''' El <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see> relacionado
    ''' </summary>
    ''' <returns></returns>
    Property ServicioOProceso As ServicioOProceso
    ''' <summary>
    ''' Identificador único global del <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see>
    ''' </summary>
    ''' <returns></returns>
    Property ServicioOProcesoId As Guid
End Interface
