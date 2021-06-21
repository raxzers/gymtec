Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class LISTATRATAMIENTOS
    <Key>
    <Column(Order:=0)>
    <StringLength(20)>
    Public Property Gymsnombre As String

    <Column("Listatratamientos")>
    <StringLength(16)>
    Public Property Listatratamientos1 As String

    <Key>
    <Column(Order:=1)>
    <StringLength(15)>
    Public Property Idtratamiento As String

    Public Overridable Property GIMNASIO As GIMNASIO

    Public Overridable Property TRATAMIENTOSPA As TRATAMIENTOSPA
End Class
