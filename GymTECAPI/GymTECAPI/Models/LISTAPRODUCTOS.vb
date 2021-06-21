Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class LISTAPRODUCTOS
    <Key>
    <Column(Order:=0)>
    <StringLength(20)>
    Public Property Gymsnombre As String

    <Column("Listaproductos")>
    <StringLength(16)>
    Public Property Listaproductos1 As String

    <Key>
    <Column(Order:=1)>
    <StringLength(16)>
    Public Property Codigodebarras As String

    Public Overridable Property GIMNASIO As GIMNASIO

    Public Overridable Property PRODUCTO As PRODUCTO
End Class
