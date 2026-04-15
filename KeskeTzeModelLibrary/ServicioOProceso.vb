
Imports System.ComponentModel.Design


''' <summary>
''' Interfaz que establece la estructura de la clase <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see>.
''' </summary>
''' <remarks>
''' <see cref="KeskeTzeModelLibrary.IServicioOProcesoBase">servicioOProceso</see> sirve para definir un proceso o un servicio.
''' </remarks>
Public Interface IServicioOProcesoBase
    Property Nombre As String

End Interface
''' <summary>
''' Clase que define un servicio o proceso
''' </summary>
''' <remarks>
''' <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see>
''' </remarks>
Public Class ServicioOProceso
    Implements IServicioOProcesoBase

#Region "propiedades"

    ''' <summary>
    ''' Nombre del servicio o proceso
    ''' </summary>
    ''' <returns></returns>
    Public Property Nombre As String

    ''' <summary>
    ''' Alias del servicio o proceso
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>En formato CamelCase y sin espacios</remarks>
    Public Property NombreCorto As String

    ''' <summary>
    ''' Si es un servicio u un proceso
    ''' </summary>
    ''' <returns></returns>
    Public Property Tipo As ETipoServicioOProceso

    ''' <summary>
    ''' La ruta donde se encuentra el ejecutable
    ''' </summary>
    ''' <returns></returns>
    Public Property Ruta As String


#End Region

#Region "constructores"
    Public Sub New()

    End Sub

#End Region

#Region "operadores"


#End Region


End Class
