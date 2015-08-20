Public Class ComparadorDePropiedades

    Private esteObjeto As Object
    Dim lasPropiedades As IEnumerable(Of Propiedad)

    Sub New(objetoBase As Object)
        Me.esteObjeto = objetoBase
        ObtengaLasPropiedadesDelTipo()
    End Sub

    Function DetermineSiEsIgualQue(otroObjeto As Object) As Boolean
        Dim lasPropiedadesSonIguales As Boolean
        lasPropiedadesSonIguales = True
        Dim elComparador As New ComparadorDeUnaPropiedad(esteObjeto, otroObjeto)

        For Each unaPropiedad In lasPropiedades
            Dim laPropiedadEsIgual As Boolean
            laPropiedadEsIgual = elComparador.LaPropiedadEsIgual(unaPropiedad)
            lasPropiedadesSonIguales = lasPropiedadesSonIguales And laPropiedadEsIgual
        Next

        Return lasPropiedadesSonIguales
    End Function

    Private Sub ObtengaLasPropiedadesDelTipo()
        Dim elTipoDelOrigen As Type = esteObjeto.GetType()
        Dim elBuscador As New BuscadorDePropiedadesLegibles(elTipoDelOrigen)
        lasPropiedades = elBuscador.EncuentreLasPropiedadesLegibles()
    End Sub

End Class
