
Class ComparadorBase

    Private sonIguales As Boolean
    Private esteObjeto As Object
    Private elOtroObjeto As Object

    Function EsIgualQue(esteObjeto As Object, elOtroObjeto As Object) As Boolean
        Me.esteObjeto = esteObjeto
        Me.elOtroObjeto = elOtroObjeto

        CompareSiSonNulos()
        CompareSusPropiedadesYSusTipos()

        Return sonIguales
    End Function

    Private Sub CompareSiSonNulos()
        If esteObjeto Is Nothing And elOtroObjeto Is Nothing Then
            sonIguales = True
        End If
    End Sub

    Private Function LosTiposSonIguales() As Boolean
        Dim elTipodeEste As Type
        elTipodeEste = esteObjeto.GetType
        Dim elTipoDelOtro As Type
        elTipoDelOtro = elOtroObjeto.GetType

        Dim sonElMismoTipo As Boolean
        sonElMismoTipo = Type.Equals(elTipodeEste, elTipoDelOtro)

        Return sonElMismoTipo
    End Function

    Private Sub CompareSusPropiedadesYSusTipos()
        If NoHayNulos() AndAlso LosTiposSonIguales() Then
            AnaliceSiSusPropiedadesSonIguales()
        End If
    End Sub

    Private Function NoHayNulos() As Boolean
        Dim hayNulos As Boolean
        hayNulos = esteObjeto Is Nothing Or elOtroObjeto Is Nothing

        Return Not hayNulos
    End Function

    Private Sub AnaliceSiSusPropiedadesSonIguales()
        Dim elComparador As New ComparadorDePropiedades(esteObjeto)
        sonIguales = elComparador.DetermineSiEsIgualQue(elOtroObjeto)
    End Sub

End Class
