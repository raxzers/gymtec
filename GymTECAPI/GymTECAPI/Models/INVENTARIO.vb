Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("INVENTARIO")>
Partial Public Class INVENTARIO
    Public Sub New()
        LISTAINVENTARIO = New HashSet(Of LISTAINVENTARIO)()
        TIPOEQUIPO = New HashSet(Of TIPOEQUIPO)()
    End Sub

    <Key>
    <StringLength(16)>
    Public Property Numeroserie As String

    <StringLength(16)>
    Public Property Tipodeequipo As String

    <StringLength(16)>
    Public Property Marca As String

    Public Property Costo As Integer?

    Public Overridable Property LISTAINVENTARIO As ICollection(Of LISTAINVENTARIO)

    Public Overridable Property TIPOEQUIPO As ICollection(Of TIPOEQUIPO)
End Class
