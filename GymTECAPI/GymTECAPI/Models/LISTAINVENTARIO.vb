Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("LISTAINVENTARIO")>
Partial Public Class LISTAINVENTARIO
    <Key>
    <Column(Order:=0)>
    <StringLength(20)>
    Public Property Gymsnombre As String

    <Column("Listainventario")>
    <StringLength(16)>
    Public Property Listainventario1 As String

    <Key>
    <Column(Order:=1)>
    <StringLength(16)>
    Public Property Numerodeserie As String

    Public Overridable Property GIMNASIO As GIMNASIO

    Public Overridable Property INVENTARIO As INVENTARIO
End Class
