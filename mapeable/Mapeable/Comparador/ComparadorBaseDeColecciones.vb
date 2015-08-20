
Class ComparadorBaseDeColecciones

    Dim sonIguales As Boolean
    Dim estaColeccion As IEnumerable(Of Object)
    Dim laOtraColeccion As IEnumerable(Of Object)

    Function EsIgualQueLaColeccion(estaColeccion As IEnumerable(Of Object),
                                   laOtraColeccion As IEnumerable(Of Object)) As Boolean
        Me.estaColeccion = estaColeccion
        Me.laOtraColeccion = laOtraColeccion

        CompareSiSonNulos()
        CompareLasColecciones()

        Return sonIguales
    End Function

    Private Sub CompareSiSonNulos()
        If estaColeccion Is Nothing And laOtraColeccion Is Nothing Then
            sonIguales = True
        End If
    End Sub

    Private Sub CompareLasColecciones()
        If NoHayNulos() AndAlso SusTiposSonIguales() AndAlso SusTamanosSonIguales() Then

            sonIguales = True
            For i As Integer = 0 To estaColeccion.Count - 1

                Dim unObjecto As Object
                Dim otroObjecto As Object

                unObjecto = estaColeccion.ElementAt(i)
                otroObjecto = laOtraColeccion.ElementAt(i)

                Dim elComparador As New ComparadorBase()
                sonIguales = sonIguales And elComparador.EsIgualQue(unObjecto, otroObjecto)
            Next
        End If
    End Sub

    Private Function NoHayNulos() As Boolean
        Dim hayNulos As Boolean
        hayNulos = estaColeccion Is Nothing Or laOtraColeccion Is Nothing
        Return Not hayNulos
    End Function

    Private Function SusTiposSonIguales() As Boolean
        Dim sonElMismoTipo As Boolean
        If NoHayNulos() Then
            Dim elTipodeEstaColeccion As Type
            elTipodeEstaColeccion = estaColeccion.GetType
            Dim elTipoDeLaOtraColeccion As Type
            elTipoDeLaOtraColeccion = laOtraColeccion.GetType
            sonElMismoTipo = Type.Equals(elTipodeEstaColeccion, elTipoDeLaOtraColeccion)
        End If
        Return sonElMismoTipo
    End Function

    Private Function SusTamanosSonIguales()
        Dim tienenElMismoTamano As Boolean
        If NoHayNulos() And SusTiposSonIguales() Then
            tienenElMismoTamano = DetermineSiTienenElMismoTamano()
        End If
        Return tienenElMismoTamano
    End Function

    Private Function DetermineSiTienenElMismoTamano() As Boolean
        Dim tienenElMismoTamano As Boolean
        If estaColeccion.Count = laOtraColeccion.Count Then
            tienenElMismoTamano = True
        Else
            tienenElMismoTamano = False
        End If
        Return tienenElMismoTamano
    End Function

End Class
