Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' Genera un GUID con semilla Integer para dar el mismo resultado desde cualquier equipo generador y en cualquier momento
''' </summary>
Public Module GuidDeterminista
    ''' <summary>
    ''' Genera un GUID determinista a partir de un entero.
    ''' El mismo entero siempre producirá el mismo GUID en cualquier espacio/tiempo de este universo.
    ''' </summary>
    Public Function GenerarGuidDesdeSemilla(semilla As Integer) As Guid
        ''' 1. Convertimos la semilla a bytes usando UTF8 para garantizar consistencia multiplataforma
        Dim datosEntrada As Byte() = Encoding.UTF8.GetBytes(semilla.ToString())

        ''' 2. Calculamos SHA-256 (32 bytes) como fuente de entropía determinista
        Dim hash As Byte() = SHA256.HashData(datosEntrada)

        ''' 3. Tomamos los primeros 16 bytes para construir el GUID
        Dim bytesGuid(15) As Byte
        Array.Copy(hash, bytesGuid, 16)

        ''' 4. Opcional: Ajustar versión y variante para cumplir RFC 4122 (UUID v5)
        ''' Si necesitas que herramientas externas lo reconozcan como UUID v5, descomenta estas líneas:
        ''' bytesGuid(6) = CByte((bytesGuid(6) And &H0F) Or &H50) ' Versión 5
        ''' bytesGuid(8) = CByte((bytesGuid(8) And &H3F) Or &H80) ' Variante 1 (RFC 4122)

        Return New Guid(bytesGuid)
    End Function
End Module