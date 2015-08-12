
Class ComparadorBase

    Dim sonIguales As Boolean
    Dim hayNulos As Boolean
    Dim esteObjeto As Object
    Dim elOtroObjeto As Object
    Dim elTipodeEste As Type
    Dim elTipoDelOtro As Type

    Function EsIgualQue(esteObjeto As Object, elOtroObjeto As Object) As Boolean
        Me.esteObjeto = esteObjeto
        Me.elOtroObjeto = elOtroObjeto

        CompareEnCasoDeNulos()
        ComparePorSusTipos()
        ComparePorSusPropiedades()

        Return sonIguales
    End Function

    Private Sub CompareEnCasoDeNulos()
        If esteObjeto Is Nothing And elOtroObjeto Is Nothing Then
            sonIguales = True
            hayNulos = True
        ElseIf esteObjeto Is Nothing Or elOtroObjeto Is Nothing Then
            sonIguales = False
            hayNulos = True
        End If
    End Sub

    Private Sub ComparePorSusTipos()
        If NoHayNulos() Then
            ObtengaLosTipos()
            ReporteSiLosTiposSonDiferentes()
        End If
    End Sub

    Private Sub ObtengaLosTipos()
        elTipodeEste = esteObjeto.GetType
        elTipoDelOtro = elOtroObjeto.GetType
    End Sub

    Private Sub ReporteSiLosTiposSonDiferentes()
        If LosTiposSonDiferentes() Then
            sonIguales = False
        End If
    End Sub

    Private Function LosTiposSonDiferentes() As Boolean
        Return Not LosTiposSonIguales()
    End Function

    Private Sub ComparePorSusPropiedades()
        If NoHayNulos() AndAlso LosTiposSonIguales() Then
            AnaliceSiSusPropiedadesSonIguales()
        End If
    End Sub

    Private Function NoHayNulos() As Boolean
        Return Not hayNulos
    End Function

    Private Function LosTiposSonIguales() As Boolean
        Return Type.Equals(elTipodeEste, elTipoDelOtro)
    End Function

    Private Sub AnaliceSiSusPropiedadesSonIguales()

        Dim elComparador As New ComparadorDePropiedades(esteObjeto)
        sonIguales = elComparador.DetermineSiEsIgualQue(elOtroObjeto)
    End Sub

End Class
