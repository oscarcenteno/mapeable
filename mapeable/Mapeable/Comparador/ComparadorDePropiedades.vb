Public Class ComparadorDePropiedades

    Private esteObjeto As Object
    Dim lasPropiedades As IEnumerable(Of Propiedad)
    Dim sonIguales As Boolean

    Sub New(objetoBase As Object)
        Me.esteObjeto = objetoBase
        ObtengaPropiedadesDelTipo()
    End Sub

    Dim otroObjeto As Object

    Function DetermineSiEsIgualQue(otroObjeto As Object) As Boolean
        Me.otroObjeto = otroObjeto

        CompareTodasLasPropiedades()

        Return sonIguales
    End Function

    Private Sub ObtengaPropiedadesDelTipo()
        Dim elTipoDelOrigen As Type = esteObjeto.GetType()
        Dim elBuscador As New BuscadorDePropiedadesLegibles(elTipoDelOrigen)
        lasPropiedades = elBuscador.EncuentreLasPropiedadesLegibles()
    End Sub

    Private Sub CompareTodasLasPropiedades()
        Dim elComparador As New ComparadorDeUnaPropiedad(esteObjeto, otroObjeto)
        Dim lasPropiedadesSonIguales As Boolean
        lasPropiedadesSonIguales = True

        For Each unaPropiedad In lasPropiedades
            Dim laPropiedadEsIgual As Boolean
            laPropiedadEsIgual = elComparador.LaPropiedadEsIgual(unaPropiedad)
            lasPropiedadesSonIguales = lasPropiedadesSonIguales And laPropiedadEsIgual
        Next

        sonIguales = lasPropiedadesSonIguales
    End Sub

End Class
