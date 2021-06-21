Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("LISTACLASESEMANAL")>
Partial Public Class LISTACLASESEMANAL
    <Key>
    <StringLength(16)>
    Public Property Idclasecalendario As String

    <Column("Listaclasesemanal")>
    <StringLength(20)>
    Public Property Listaclasesemanal1 As String

    Public Overridable Property CALENDARIO As CALENDARIO
End Class
