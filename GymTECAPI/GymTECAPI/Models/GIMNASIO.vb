Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("GIMNASIO")>
Partial Public Class GIMNASIO
    Public Sub New()
        CLIENTE = New HashSet(Of CLIENTE)()
        LISTAINVENTARIO = New HashSet(Of LISTAINVENTARIO)()
        LISTAPRODUCTOS = New HashSet(Of LISTAPRODUCTOS)()
        LISTATRATAMIENTOS = New HashSet(Of LISTATRATAMIENTOS)()
        SERVICIO = New HashSet(Of SERVICIO)()
    End Sub

    <Required>
    <StringLength(20)>
    Public Property Snombre As String

    <Key>
    <StringLength(20)>
    Public Property Gymnombre As String

    Public Overridable Property CLIENTE As ICollection(Of CLIENTE)

    Public Overridable Property SUCURSAL As SUCURSAL

    Public Overridable Property LISTACLASES As LISTACLASES

    Public Overridable Property LISTAINVENTARIO As ICollection(Of LISTAINVENTARIO)

    Public Overridable Property LISTAPRODUCTOS As ICollection(Of LISTAPRODUCTOS)

    Public Overridable Property LISTATRATAMIENTOS As ICollection(Of LISTATRATAMIENTOS)

    Public Overridable Property SERVICIO As ICollection(Of SERVICIO)
End Class
