Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("TRATAMIENTOSPA")>
Partial Public Class TRATAMIENTOSPA
    Public Sub New()
        LISTATRATAMIENTOS = New HashSet(Of LISTATRATAMIENTOS)()
    End Sub

    <Key>
    <StringLength(15)>
    Public Property Idtratamiento As String

    <StringLength(16)>
    Public Property Nombre As String

    Public Overridable Property LISTATRATAMIENTOS As ICollection(Of LISTATRATAMIENTOS)
End Class
