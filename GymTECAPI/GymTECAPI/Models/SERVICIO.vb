Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("SERVICIO")>
Partial Public Class SERVICIO
    <Key>
    <StringLength(20)>
    Public Property Idservicio As String

    <StringLength(16)>
    Public Property Descripción As String

    <Required>
    <StringLength(20)>
    Public Property Snombre As String

    Public Overridable Property GIMNASIO As GIMNASIO
End Class
