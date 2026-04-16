
Imports System.ComponentModel.Design
Imports Crkw.BL.KeskeTzeLib

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
    Public Property Nombre As String Implements IServicioOProcesoBase.Nombre

    ''' <summary>
    ''' Alias del servicio o proceso
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>En formato CamelCase y sin espacios</remarks>
    Public Property NombreCorto As String Implements IServicioOProcesoBase.NombreCorto

    ''' <summary>
    ''' Si es un servicio u un proceso
    ''' </summary>
    ''' <returns></returns>
    Public Property Tipo As ETipoServicioOProceso Implements IServicioOProcesoBase.Tipo

    ''' <summary>
    ''' La ruta donde se encuentra el ejecutable
    ''' </summary>
    ''' <returns></returns>
    Public Property Ruta As String Implements IServicioOProcesoBase.Ruta


#End Region

#Region "constructores"

    ''' <summary>
    ''' Copia las propiedades de un modelo instanciado de la misma clase en la clase instanciada actual.
    ''' </summary>
    ''' <param name="servicioOProcesoBase">El <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see> a copiar en la instancia actual</param>
    Public Sub Copiar(servicioOProcesoBase As ServicioOProceso)
        With servicioOProcesoBase
            Me.Nombre = .Nombre
            Me.NombreCorto = .NombreCorto
            Me.Ruta = .Ruta
            Me.Tipo = .Tipo
        End With
    End Sub

    ''' <summary>
    ''' Inicia una instancia de la clase <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see> a partir de una ruta de archivo.
    ''' </summary>
    ''' <param name="rutaEjecucion">Ruta de ejecución o ruta completa al archivo</param>
    ''' <returns></returns>
    ''' <remarks> ësta función invoca al constructor <see cref="ServicioOProceso.New(String)">ServicioOProceso.New(String)</see></remarks>
    Public Shared Function CrearDesdeRuta(rutaEjecucion As String) As ServicioOProceso
        Return New ServicioOProceso(rutaEjecucion)
    End Function

    ''' <summary>
    ''' Inicia una instancia de la clase <see cref="KeskeTzeModelLibrary.ServicioOProceso">servicioOProceso</see> a partir de una ruta de archivo.
    ''' </summary>
    ''' <param name="rutaEjecucion">Ruta de ejecución o ruta completa al archivo.</param>
    Public Sub New(rutaEjecucion As String)
        Dim rutaSinArgs As String = Crkw.BL.KeskeTzeLib.QuitarArgumentosDeEjecucionDeRuta(rutaEjecucion)
        Me.Nombre = Crkw.BL.KeskeTzeLib.ObtenerNombreDeEjecutable(rutaEjecucion)

        If YTuDeQuienEres.EsLibreriaCompilada(rutaEjecucion) Then
            Me.Tipo = ETipoServicioOProceso.Servicio
        ElseIf YTuDeQuienEres.EsEjecutable(rutaEjecucion) Then
            Me.Tipo = ETipoServicioOProceso.Proceso
        Else
            Me.Tipo = ETipoServicioOProceso.Ninguno
        End If

        Me.NombreCorto = Crkw.BL.KeskeTzeLib.GenerarNombreCortoDesdeRuta(rutaEjecucion)

    End Sub

    ''' <summary>
    ''' Constructor vacío por defecto, necesario para algunos serializadores
    ''' </summary>
    Public Sub New()

    End Sub

#End Region

#Region "operadores"

    Public Shared Widening Operator CType(rutaEjecucion As String) As ServicioOProceso
        Return New ServicioOProceso(rutaEjecucion)
    End Operator
    Public Shared Widening Operator CType(servicioOProceso As ServicioOProceso) As String
        Return servicioOProceso.ToString()
    End Operator

    Public Overrides Function ToString() As String
        Return Me.Ruta
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return MyBase.Equals(obj)
    End Function
    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function

#End Region


End Class
