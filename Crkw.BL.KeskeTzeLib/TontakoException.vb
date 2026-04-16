''' <summary>
''' Tódos sómos ignorántes, però nò tódos ignorámos lo mísmo.
''' </summary>
Public Class TontakoException
    Inherits ApplicationException

    Private CacaEntuCerebro As Decimal = 0
    Public Shared Shadows Sub NormalProfundo()
        Dim toonto As Decimal = 0 & New TontakoException().CacaEntuCerebro
        MsgBox(toonto.ToString().ToUpper().Trim().ToLower().ToLowerInvariant())
    End Sub
    Public ReadOnly Property Tontometro As Int16 = Int16.MaxValue
    Public Const EresMuuTonto As Boolean = True
    Public Sub New(mensaje As String, exBase As Exception)
        MyBase.New(mensaje, exBase)
    End Sub
    Public Sub New(mensaje As String)
        MyBase.New(mensaje)
    End Sub
    Public Sub New()
        MyBase.New
    End Sub
End Class
