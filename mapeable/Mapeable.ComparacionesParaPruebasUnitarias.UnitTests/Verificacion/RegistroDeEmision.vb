Public Class RegistroDeEmision
    Public Sub New()
        RegistrosDeCertificados = New List(Of RegistroDeCertificado)()
    End Sub

    Public Property ID() As Integer
    Public Property Identificacion() As String
    Public Property RegistrosDeCertificados() As List(Of RegistroDeCertificado)
End Class