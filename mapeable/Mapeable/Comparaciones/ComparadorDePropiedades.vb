Public Class ComparadorDePropiedades

    Private elObjeto As Object
    Private lasPropiedades As IEnumerable(Of Propiedad)

    Sub New(elObjeto As Object)
        Me.elObjeto = elObjeto
        ObtengaLasPropiedadesDelTipo()
    End Sub

    Private Sub ObtengaLasPropiedadesDelTipo()
        Dim elBuscador As New BuscadorDePropiedadesLegibles(elObjeto.GetType)
        lasPropiedades = elBuscador.EncuentreLasPropiedadesLegibles()
    End Sub

    Function DetermineSiEsIgualQue(otroObjeto As Object) As Boolean
        Dim todasSonIguales As Boolean
        todasSonIguales = True

        For Each unaPropiedad In lasPropiedades
            Dim esIgual As Boolean
            Dim elNombre As String
            elNombre = unaPropiedad.Nombre

            Dim elComparador As New ComparadorDeUnaPropiedad(elNombre, elObjeto.GetType)
            esIgual = elComparador.LaPropiedadEsIgual(elObjeto, otroObjeto)
            todasSonIguales = todasSonIguales And esIgual
        Next

        Return todasSonIguales
    End Function

End Class
