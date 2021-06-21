Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("TELEFONO")>
Partial Public Class TELEFONO
    <Column("Telefono")>
    <StringLength(15)>
    Public Property Telefono1 As String

    <Key>
    <StringLength(20)>
    Public Property Snombre As String

    Public Overridable Property SUCURSAL As SUCURSAL
End Class
