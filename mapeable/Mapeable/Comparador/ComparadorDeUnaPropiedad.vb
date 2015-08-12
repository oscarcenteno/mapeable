Imports System.Reflection

Public Class ComparadorDeUnaPropiedad

    Private esteObjeto As Object
    Private otroObjeto As Object

    Sub New(esteObjeto As Object, otroObjeto As Object)
        Me.esteObjeto = esteObjeto
        Me.otroObjeto = otroObjeto
    End Sub

    Function LaPropiedadEsIgual(unaPropiedad As Propiedad) As Boolean

        Dim elTipoDelOrigen As Type = esteObjeto.GetType()
        Dim laPropiedadOrigen As PropertyInfo
        laPropiedadOrigen = elTipoDelOrigen.GetProperty(unaPropiedad.Nombre, BindingFlags.Instance Or BindingFlags.Public)
        Dim elValor As Object
        elValor = laPropiedadOrigen.GetValue(esteObjeto, Nothing)
        Dim elOtroValor As Object
        elOtroValor = laPropiedadOrigen.GetValue(otroObjeto, Nothing)

        Dim elTipoDeLaPropiedad As Type
        elTipoDeLaPropiedad = laPropiedadOrigen.PropertyType

        Dim esIgual As Boolean

        If elTipoDeLaPropiedad.FullName.Equals("System.String") Then
            esIgual = String.Equals(elValor, elOtroValor)
        ElseIf elTipoDeLaPropiedad.IsClass Then
            Dim elComparador As New ComparadorBase()
            esIgual = elComparador.EsIgualQue(elValor, elOtroValor)
        Else
            esIgual = Object.Equals(elValor, elOtroValor)
        End If

        Return esIgual
    End Function

End Class
