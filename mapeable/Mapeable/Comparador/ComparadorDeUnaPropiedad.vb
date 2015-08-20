Imports System.Reflection

Public Class ComparadorDeUnaPropiedad

    Private esteObjeto As Object
    Private otroObjeto As Object

    Sub New(esteObjeto As Object, otroObjeto As Object)
        Me.esteObjeto = esteObjeto
        Me.otroObjeto = otroObjeto
    End Sub

    Dim laPropiedadOrigen As PropertyInfo
    Dim esIgual As Boolean
    Function LaPropiedadEsIgual(unaPropiedad As Propiedad) As Boolean

        ObtengaLaPropiedadQueSeComparara(unaPropiedad)
        ObtengaElValorDeUnObjeto()
        ObtengaElValorDelOtroObjeto()
        CompareLosValores()

        Return esIgual
    End Function

    Const losAtributos As BindingFlags = BindingFlags.Instance Or BindingFlags.Public
    Private Sub ObtengaLaPropiedadQueSeComparara(unaPropiedad As Propiedad)
        Dim elTipoDelOrigen As Type = esteObjeto.GetType()
        laPropiedadOrigen = elTipoDelOrigen.GetProperty(unaPropiedad.Nombre,
                                                        losAtributos)
    End Sub

    Dim elValor As Object
    Dim elOtroValor As Object
    Private Sub ObtengaElValorDeUnObjeto()
    End Sub

    Private Sub ObtengaElValorDelOtroObjeto()
        elOtroValor = laPropiedadOrigen.GetValue(otroObjeto, Nothing)
    End Sub

    Private Sub CompareLosValores()
        ObtengaElTipoDeLaPropiedad()

        If LaPropiedadEsUnString() Then
            CompareComoStrings()
        ElseIf LaPropiedadEsUnaClase() Then
            CompareComoObjetos()
        Else
            CompareComoValoresPrimitivos()
        End If

    End Sub

    Dim elTipoDeLaPropiedad As Type
    Private Sub ObtengaElTipoDeLaPropiedad()
        elTipoDeLaPropiedad = laPropiedadOrigen.PropertyType
    End Sub

    Private Function LaPropiedadEsUnString() As Boolean
        Return elTipoDeLaPropiedad.FullName.Equals("System.String")
    End Function

    Private Sub CompareComoStrings()
        esIgual = String.Equals(elValor, elOtroValor)
    End Sub

    Private Function LaPropiedadEsUnaClase() As Boolean
        Return elTipoDeLaPropiedad.IsClass
    End Function

    Private Sub CompareComoObjetos()
        Dim elComparador As New ComparadorBase()
        esIgual = elComparador.EsIgualQue(elValor, elOtroValor)
    End Sub

    Private Sub CompareComoValoresPrimitivos()
        esIgual = Object.Equals(elValor, elOtroValor)
    End Sub



End Class
