Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("TIPOEQUIPO")>
Partial Public Class TIPOEQUIPO
    <Key>
    <StringLength(20)>
    Public Property Idequipo As String

    <StringLength(16)>
    Public Property Descripción As String

    <Required>
    <StringLength(16)>
    Public Property Numerodeserie As String

    Public Overridable Property INVENTARIO As INVENTARIO
End Class
