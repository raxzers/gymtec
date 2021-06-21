Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("PRODUCTO")>
Partial Public Class PRODUCTO
    Public Sub New()
        LISTAPRODUCTOS = New HashSet(Of LISTAPRODUCTOS)()
    End Sub

    <Key>
    <StringLength(16)>
    Public Property Codigodebarras As String

    Public Property Costo As Integer?

    <StringLength(16)>
    Public Property Nombre As String

    <StringLength(16)>
    Public Property Descripción As String

    Public Overridable Property LISTAPRODUCTOS As ICollection(Of LISTAPRODUCTOS)
End Class
