Imports System.Reflection

Class AsignadorDePropiedades

    Private elobjetoOrigen As Object
    Private elObjetoDestino As Object

    Sub New(elobjetoOrigen As Object, elObjetoDestino As Object)
        Me.elobjetoOrigen = elobjetoOrigen
        Me.elObjetoDestino = elObjetoDestino

        ObtengaElTipoOrigen()
        ObtengaElTipoDestino()
    End Sub

    Dim elTipoDelOrigen As Type
    Private Sub ObtengaElTipoOrigen()
        elTipoDelOrigen = elobjetoOrigen.GetType()
    End Sub

    Dim elTipoDelDestino As Type
    Private Sub ObtengaElTipoDestino()
        elTipoDelDestino = elObjetoDestino.GetType()
    End Sub

    Const losAtributos = BindingFlags.Public Or BindingFlags.Instance
    Sub MapeeDelOrigenAlDestino(laPropiedadOrigen As String,
                                laPropiedadDestino As String)
        ObtengaElValorDe(laPropiedadOrigen)
        AsigneA(laPropiedadDestino)
    End Sub

    Dim elValorPorMapear As Object
    Private Sub ObtengaElValorDe(laPropiedadOrigen As String)
        Dim laPropiedadOrigenCompleta As PropertyInfo
        laPropiedadOrigenCompleta = elTipoDelOrigen.GetProperty(laPropiedadOrigen,
                                                                losAtributos)
        elValorPorMapear = laPropiedadOrigenCompleta.GetValue(elobjetoOrigen, Nothing)
    End Sub

    Private Sub AsigneA(laPropiedadDestino As String)
        Dim laPropiedadDestinoCompleta As PropertyInfo
        laPropiedadDestinoCompleta = elTipoDelDestino.GetProperty(laPropiedadDestino,
                                                                  losAtributos)
        laPropiedadDestinoCompleta.SetValue(elObjetoDestino, elValorPorMapear, Nothing)
    End Sub

End Class
