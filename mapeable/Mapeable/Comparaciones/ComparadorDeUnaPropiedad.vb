Imports System.Reflection

Namespace Comparaciones
    Public Class ComparadorDeUnaPropiedad
        Private laPropiedadOrigen As PropertyInfo
        Private elValor As Object
        Private elOtroValor As Object
        Private esIgual As Boolean

        Sub New(laPropiedad As String, elTipoDeLaClase As Type)
            Dim losFiltros As BindingFlags = BindingFlags.Instance Or BindingFlags.Public
            laPropiedadOrigen = elTipoDeLaClase.GetProperty(laPropiedad, losFiltros)
        End Sub

        Function LaPropiedadEsIgual(unObjeto As Object, otroObjeto As Object) As Boolean
            ObtengaElValor(unObjeto)
            ObtengaElOtroValor(otroObjeto)
            CompareLosValores()

            Return esIgual
        End Function

        Private Sub ObtengaElOtroValor(unObjeto As Object)
            elValor = laPropiedadOrigen.GetValue(unObjeto, Nothing)
        End Sub

        Private Sub ObtengaElValor(otroObjeto As Object)
            elOtroValor = laPropiedadOrigen.GetValue(otroObjeto, Nothing)
        End Sub

        Private Sub CompareLosValores()
            Dim elTipo As Type
            elTipo = laPropiedadOrigen.PropertyType

            If elTipo.Equals(GetType(String)) Then
                esIgual = String.Equals(elValor, elOtroValor)
            ElseIf elTipo.IsClass Then
                Dim elComparador As New ComparadorBase()
                esIgual = elComparador.EsIgualQue(elValor, elOtroValor)
            Else
                esIgual = Object.Equals(elValor, elOtroValor)
            End If
        End Sub
    End Class
End Namespace