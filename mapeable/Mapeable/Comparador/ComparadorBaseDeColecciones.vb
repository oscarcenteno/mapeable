
Class ComparadorBaseDeColecciones

    Dim sonIguales As Boolean

    Dim noHayNulos As Boolean
    Dim losTiposSonIguales As Boolean
    Dim susTamanosSonIguales As Boolean

    Dim elTipodeEstaColeccion As Type
    Dim elTipoDeLaOtraColeccion As Type

    Dim estaColeccion As IEnumerable(Of Object)
    Dim laOtraColeccion As IEnumerable(Of Object)

    Function EsIgualQueLaColeccion(estaColeccion As IEnumerable(Of Object),
                                   laOtraColeccion As IEnumerable(Of Object)) As Boolean
        Me.estaColeccion = estaColeccion
        Me.laOtraColeccion = laOtraColeccion

        CompareEnCasoDeNulos()
        ComparePorSusTipos()
        ComparePorSusTamanos()
        ComparePorSusElementos()

        Return sonIguales
    End Function

    Private Sub CompareEnCasoDeNulos()
        If estaColeccion Is Nothing And laOtraColeccion Is Nothing Then
            sonIguales = True
            noHayNulos = False
        ElseIf estaColeccion Is Nothing Or laOtraColeccion Is Nothing Then
            sonIguales = False
            noHayNulos = False
        Else
            noHayNulos = True
        End If
    End Sub

    Private Sub ComparePorSusTipos()
        If noHayNulos Then
            elTipodeEstaColeccion = estaColeccion.GetType
            elTipoDeLaOtraColeccion = laOtraColeccion.GetType
            losTiposSonIguales = Type.Equals(elTipodeEstaColeccion, elTipoDeLaOtraColeccion)
        End If
    End Sub

    Private Sub ComparePorSusElementos()
        If noHayNulos AndAlso losTiposSonIguales AndAlso susTamanosSonIguales Then

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

    Private Sub ComparePorSusTamanos()
        If noHayNulos And losTiposSonIguales Then
            DestermineSiTienenElMismoTamano()
        End If
    End Sub

    Private Sub DestermineSiTienenElMismoTamano()
        If estaColeccion.Count = laOtraColeccion.Count Then
            susTamanosSonIguales = True
        Else
            susTamanosSonIguales = False
            sonIguales = False
        End If
    End Sub

End Class
