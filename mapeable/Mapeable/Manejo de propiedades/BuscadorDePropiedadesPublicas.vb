Imports System.Reflection

Namespace ManejoDePropiedades
    Public Class BuscadorDePropiedadesPublicas
        Private elTipo As Type
        Dim losMiembrosPublicosDeInstancia() As MemberInfo
        Private lasPropiedades As IList(Of Propiedad)

        Public Sub New(elTipo As Type)
            Me.elTipo = elTipo
        End Sub

        Public Function EncuentreLasPropiedadesPublicas() As IEnumerable(Of Propiedad)
            ObtengaLosMiembrosPublicosDeInstancia()
            EncuentreLosQueSonPropiedades()

            Return lasPropiedades
        End Function

        Private Sub ObtengaLosMiembrosPublicosDeInstancia()
            Dim losFiltros = BindingFlags.Public Or BindingFlags.Instance
            losMiembrosPublicosDeInstancia = elTipo.GetMembers(losFiltros)
        End Sub

        Private Sub EncuentreLosQueSonPropiedades()
            InicialiceLaListaDePropiedades()
            For Each miembro In losMiembrosPublicosDeInstancia
                RegistreElMiembroSiEsUnaPropiedad(miembro)
            Next
        End Sub

        Private Sub InicialiceLaListaDePropiedades()
            lasPropiedades = New List(Of Propiedad)
        End Sub

        Private Sub RegistreLaPropiedad(unaPropiedad As PropertyInfo)
            Dim nuevaPropiedad As New Propiedad
            nuevaPropiedad.Nombre = unaPropiedad.Name
            nuevaPropiedad.Tipo = unaPropiedad.PropertyType
            nuevaPropiedad.SePuedeEscribir = unaPropiedad.CanWrite
            nuevaPropiedad.SePuedeLeer = unaPropiedad.CanRead
            lasPropiedades.Add(nuevaPropiedad)
        End Sub

        Private Sub RegistreElMiembroSiEsUnaPropiedad(miembro As MemberInfo)
            If ElMiembroEsUnaPropiedad(miembro) Then
                RegistreLaPropiedad(miembro)
            End If
        End Sub

        Private Function ElMiembroEsUnaPropiedad(miembro As MemberInfo) As Boolean
            Return miembro.MemberType = MemberTypes.Property
        End Function
    End Class
End Namespace