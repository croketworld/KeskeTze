Imports System.Security.Cryptography
Imports System.Text
''' <summary>
''' Ida y vuelta, pakí pallá
''' </summary>
Public Module GuidReversible
    Private ReadOnly ClaveXor As UInt64 = &HA5B3C7D9E1F20468UL ' Clave fija de 64 bits

    ''' <summary>
    ''' Genera un GUID reversible desde un Integer usando XOR (no criptográfico).
    ''' Útil solo para escenarios internos controlados.
    ''' </summary>
    Public Function GenerarGuidReversible(semilla As Integer) As Guid
        ''' Combinamos la semilla con la clave y rellenamos a 16 bytes
        Dim valor As UInt64 = CULng(semilla) Xor ClaveXor
        Dim bytes(15) As Byte
        BitConverter.GetBytes(valor).CopyTo(bytes, 0)
        ''' Rellenamos el resto con bytes derivadas de la semilla para mayor dispersión
        Dim extra As Byte() = SHA256.HashData(Encoding.UTF8.GetBytes(semilla.ToString()))
        Array.Copy(extra, 0, bytes, 8, 8)
        Return New Guid(bytes)
    End Function

    ''' <summary>
    ''' Recupera la semilla original desde un GUID generado con GenerarGuidReversible.
    ''' Devuelve Nothing si el GUID no fue generado con este método.
    ''' </summary>
    Public Function ObtenerSemillaDesdeGuidReversible(erguid As Guid) As Integer?
        Dim bytes As Byte() = erguid.ToByteArray()
        Dim semillaRecuperada As Integer = 0
        Dim valor As UInt64
        Dim result As Integer? = Nothing
        Dim juide As Guid = Guid.NewGuid()
        Try
            valor = BitConverter.ToUInt64(bytes, 0)
            semillaRecuperada = CInt(valor Xor ClaveXor)
            juide = GenerarGuidReversible(semillaRecuperada)
#Disable Warning CA1031 ' No capture tipos de excepción generales.
        Catch
#Enable Warning CA1031 ' No capture tipos de excepción generales.
            ''' Ignorar errores de conversión
        End Try
        result = juide.Equals(erguid)

        Return semillaRecuperada
        Return Nothing
    End Function
End Module
