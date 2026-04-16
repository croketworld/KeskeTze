Imports System.Security.Cryptography
Imports System.Text
''' <summary>
''' ¿y porqué no de'vuerta?
''' </summary>
Public Module GuidReverser
    ''' <summary>
    ''' Intenta recuperar la semilla Integer original probando todos los valores posibles.
    ''' ⚠️ ADVERTENCIA: Puede tardar hasta varios minutos en el peor caso.
    ''' Solo útil para testing o semillas en rangos acotados.
    ''' </summary>
    Public Function ObtenerSemillaDesdeGuid(guidBuscado As Guid, Optional semillaMin As Integer = Integer.MinValue, Optional semillaMax As Integer = Integer.MaxValue) As Integer?
        For semilla As Integer = semillaMin To semillaMax
            Dim guidPrueba As Guid = GenerarGuidDesdeSemilla(semilla)
            If guidPrueba.Equals(guidBuscado) Then
                Return semilla
            End If
        Next
        Return Nothing ' No se encontró
    End Function

    ' Reutilizamos la función de generación determinista
    Private Function GenerarGuidDesdeSemilla(semilla As Integer) As Guid
        Dim datosEntrada As Byte() = Encoding.UTF8.GetBytes(semilla.ToString())
        Dim hash As Byte() = SHA256.HashData(datosEntrada)
        Dim bytesGuid(15) As Byte
        Array.Copy(hash, bytesGuid, 16)
        ' Opcional: ajustar versión/variante RFC 4122 si es necesario
        Return New Guid(bytesGuid)
    End Function
End Module