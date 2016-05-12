Imports System.Linq.Expressions

Namespace Mapeos
    Public Class ConfiguradorDeMapeoPersonalizado(Of ClaseDestino, TipoDeLaPropiedad)
        Private elMapeo As MapeoPersonalizado

        Public Sub New(elMapeo As MapeoPersonalizado)
            Me.elMapeo = elMapeo
        End Sub

        Public Sub Hacia(laPropiedadDestino As Expression(Of Func(Of ClaseDestino, TipoDeLaPropiedad)))
            Dim elMiembroDeLaPropiedad = laPropiedadDestino.GetMember()
            elMapeo.LaPropiedadDestino = elMiembroDeLaPropiedad.Name
        End Sub
    End Class
End Namespace