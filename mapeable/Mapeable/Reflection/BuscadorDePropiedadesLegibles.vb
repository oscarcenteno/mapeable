Imports System.Reflection

Public Class BuscadorDePropiedadesLegibles

    Private elTipo As Type

    Public Sub New(elTipo As Type)
        Me.elTipo = elTipo
    End Sub

    Private lasPropiedadesLegibles As IList(Of Propiedad)
    Public Function EncuentreLasPropiedadesLegibles() As IEnumerable(Of Propiedad)
        ObtengaLosMiembrosPublicosDeInstancia()
        ListeLosQueSonPropiedades()
        ListeLasPropiedadesLegibles()

        Return lasPropiedadesLegibles
    End Function

    Dim miembrosPublicosDeInstancia() As MemberInfo
    Private Sub ObtengaLosMiembrosPublicosDeInstancia()
        miembrosPublicosDeInstancia = elTipo.GetMembers(Reflection.BindingFlags.Public _
                                                        Or Reflection.BindingFlags.Instance)
    End Sub

    Dim lasPropiedades As IList(Of PropertyInfo)
    Private Sub ListeLosQueSonPropiedades()
        InicialiceLaListaDePropiedades()
        For Each miembro In miembrosPublicosDeInstancia
            RegistreElMiembroSiEsUnaPropiedad(miembro)
        Next
    End Sub

    Private Sub InicialiceLaListaDePropiedades()
        lasPropiedades = New List(Of PropertyInfo)
    End Sub

    Private Sub ListeLasPropiedadesLegibles()
        InicialiceLaListaDeLegibles()
        For Each unaPropiedad In lasPropiedades
            RegistreSiLaPropiedadEsLegible(unaPropiedad)
        Next
    End Sub

    Private Sub InicialiceLaListaDeLegibles()
        lasPropiedadesLegibles = New List(Of Propiedad)
    End Sub

    Private Sub RegistreSiLaPropiedadEsLegible(unaPropiedad As PropertyInfo)
        If LaPropiedadEsLegible(unaPropiedad) Then
            RegistreComoUnaPropiedadLegible(unaPropiedad)
        End If
    End Sub

    Private Function LaPropiedadEsLegible(unaPropiedad As PropertyInfo) As Boolean
        Return unaPropiedad.CanWrite
    End Function

    Private Sub RegistreComoUnaPropiedadLegible(unaPropiedad As PropertyInfo)
        Dim nuevaPropiedad As New Propiedad
        nuevaPropiedad.Nombre = unaPropiedad.Name
        nuevaPropiedad.Tipo = unaPropiedad.PropertyType.Name
        lasPropiedadesLegibles.Add(nuevaPropiedad)
    End Sub

    Private Sub RegistreElMiembroSiEsUnaPropiedad(miembro As MemberInfo)
        If ElMiembroEsUnaPropiedad(miembro) Then
            RegistreComoUnaPropiedad(miembro)
        End If
    End Sub

    Private Function ElMiembroEsUnaPropiedad(miembro As MemberInfo) As Boolean
        Return miembro.MemberType = MemberTypes.Property
    End Function

    Private Sub RegistreComoUnaPropiedad(miembro As MemberInfo)
        lasPropiedades.Add(miembro)
    End Sub

End Class
