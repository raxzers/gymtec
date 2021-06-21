Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("LISTAEMPLEADO")>
Partial Public Class LISTAEMPLEADO
    <Key>
    <StringLength(15)>
    Public Property Planillaid As String

    <Column("Listaempleado")>
    <StringLength(16)>
    Public Property Listaempleado1 As String

    Public Property Empnumerocedula As Integer?

    Public Overridable Property EMPLEADO As EMPLEADO

    Public Overridable Property PLANILLA As PLANILLA
End Class
