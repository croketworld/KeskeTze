Public Class Constantes
    ''' <summary>
    ''' Lista de preposiciones para el acortado de nombre.
    ''' </summary>
    ''' <example>
    ''' (entrada)  Estacion de trabajo
    ''' (salida) EsDTr
    ''' convirtiendo la preposuición 'de' en 'D'
    ''' </example>
    Public Shared Preposiciones As String() = {"a", "ante", "bajo", "cabe", "con", "contra", "de", "desde", "durante", "en", "entre", "hacia", "hasta", "mediante", "para", "por", "según", "sin", "so", "sobre", "tras"}

    Public Shared ExtensionesEjecutables As String() = {"exe", "msi", "ps1", "vbs"}

    ''' <summary>
    ''' Lista de artículos para el acortado de nombres.
    ''' </summary>
    ''' <remarks>Usado en combinación de las preposiciones.</remarks>
    ''' <example>
    ''' (entrada)  Estacion de los trabajos
    ''' (salida) EsDlsTr
    ''' </example>
    Public Shared Articulos As String() = {"el", "la", "los", "las", "lo", "un", "una", "unos", "unas"}
End Class
