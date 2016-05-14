Namespace Comparaciones
    Public Class ComparadorBase
        Public Function EsIgualQue(unObjeto As Object, otroObjeto As Object) As Boolean
            If AmbosSonNulos(unObjeto, otroObjeto) Then
                Return True
            Else
                Return DetermineSiSonIgualesPorTipoYPropiedad(unObjeto, otroObjeto)
            End If
        End Function

        Private Function DetermineSiSonIgualesPorTipoYPropiedad(unObjeto As Object, otroObjeto As Object) As Boolean
            If NoHayNulos(unObjeto, otroObjeto) Then
                Return DetermineSiSonIgualesPorTipo(unObjeto, otroObjeto)
            Else
                Return False
            End If
        End Function

        Private Function DetermineSiSonIgualesPorTipo(unObjeto As Object, otroObjeto As Object) As Boolean
            If TienenElMismoTipo(unObjeto, otroObjeto) Then
                Return DetermineSiSusPropiedadesSonIguales(unObjeto, otroObjeto)
            Else
                Return False
            End If
        End Function

        Private Shared Function AmbosSonNulos(unObjeto As Object, otroObjeto As Object) As Boolean
            Return unObjeto Is Nothing And otroObjeto Is Nothing
        End Function

        Private Function TienenElMismoTipo(unObjeto As Object, otroObjeto As Object) As Boolean
            Dim unTipo As Type = ObtengaElTipo(unObjeto)
            Dim otroTipo As Type = ObtengaElTipo(otroObjeto)

            Return SusTiposSonElMismo(unTipo, otroTipo)
        End Function

        Private Shared Function SusTiposSonElMismo(unTipo As Type, otroTipo As Type) As Boolean
            Return Type.Equals(unTipo, otroTipo)
        End Function

        Private Shared Function ObtengaElTipo(unObjeto As Object) As Type
            Return unObjeto.GetType
        End Function

        Private Function NoHayNulos(unObjeto As Object, otroObjeto As Object) As Boolean
            Return Not (unObjeto Is Nothing Or otroObjeto Is Nothing)
        End Function

        Private Function DetermineSiSusPropiedadesSonIguales(unObjeto As Object, otroObjeto As Object) As Boolean
            Return New ComparadorDePropiedades(unObjeto).DetermineSiEsIgualQue(otroObjeto)
        End Function
    End Class
End Namespace