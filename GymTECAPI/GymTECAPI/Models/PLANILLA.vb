Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("PLANILLA")>
Partial Public Class PLANILLA
    <StringLength(15)>
    Public Property ID As String

    <StringLength(16)>
    Public Property Descripcion As String

    Public Overridable Property LISTAEMPLEADO As LISTAEMPLEADO

    Public Overridable Property PAGO As PAGO
End Class
