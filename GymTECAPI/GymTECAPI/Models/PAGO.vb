Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("PAGO")>
Partial Public Class PAGO
    <Key>
    <StringLength(15)>
    Public Property Planillaid As String

    <Column("Pago")>
    Public Property Pago1 As Integer?

    Public Overridable Property PLANILLA As PLANILLA
End Class
