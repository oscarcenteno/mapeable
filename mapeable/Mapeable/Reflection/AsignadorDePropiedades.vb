Imports System.Reflection

Class AsignadorDePropiedades

    Private elObjetoOrigen As Object
    Private elObjetoDestino As Object
    Private elValorPorMapear As Object

    Const losFiltros = BindingFlags.Public Or BindingFlags.Instance

    Sub New(elobjetoOrigen As Object, elObjetoDestino As Object)
        Me.elObjetoOrigen = elobjetoOrigen
        Me.elObjetoDestino = elObjetoDestino
    End Sub

    Sub MapeeDelOrigenAlDestino(laPropiedadOrigen As String, laPropiedadDestino As String)
        ObtengaElValorDe(laPropiedadOrigen)
        AsigneA(laPropiedadDestino)
    End Sub

    Private Sub ObtengaElValorDe(laPropiedadOrigen As String)
        Dim laPropiedadOrigenCompleta As PropertyInfo

        Dim elTipoDelOrigen As Type
        elTipoDelOrigen = elObjetoOrigen.GetType()
        laPropiedadOrigenCompleta = elTipoDelOrigen.GetProperty(laPropiedadOrigen,
                                                                losFiltros)
        elValorPorMapear = laPropiedadOrigenCompleta.GetValue(elObjetoOrigen, Nothing)
    End Sub

    Private Sub AsigneA(laPropiedadDestino As String)
        Dim elTipoDelDestino As Type
        elTipoDelDestino = elObjetoDestino.GetType()

        Dim laPropiedadDestinoCompleta As PropertyInfo
        laPropiedadDestinoCompleta = elTipoDelDestino.GetProperty(laPropiedadDestino,
                                                                  losFiltros)
        laPropiedadDestinoCompleta.SetValue(elObjetoDestino, elValorPorMapear, Nothing)
    End Sub

End Class
