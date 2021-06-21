Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("CALENDARIO")>
Partial Public Class CALENDARIO
    <Key>
    <StringLength(16)>
    Public Property Idclasecalendario As String

    Public Overridable Property CLASE As CLASE

    Public Overridable Property LISTACLASESEMANAL As LISTACLASESEMANAL
End Class
