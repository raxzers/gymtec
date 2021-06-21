Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("CLASE")>
Partial Public Class CLASE
    <Key>
    <StringLength(16)>
    Public Property Idclase As String

    Public Property Horaslinicio As TimeSpan?

    Public Property Horaslfinalizacion As TimeSpan?

    <Column(TypeName:="date")>
    Public Property Fecha As Date?

    <StringLength(20)>
    Public Property Instructor As String

    <StringLength(15)>
    Public Property Grupalpersonal As String

    Public Property Capacidad As Integer?

    <StringLength(15)>
    Public Property Tipo As String

    Public Overridable Property CALENDARIO As CALENDARIO
End Class
