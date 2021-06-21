Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class LISTACLASES
    <Key>
    <StringLength(20)>
    Public Property Gymsnombre As String

    <Column("Listaclases")>
    <StringLength(16)>
    Public Property Listaclases1 As String

    Public Overridable Property GIMNASIO As GIMNASIO
End Class
