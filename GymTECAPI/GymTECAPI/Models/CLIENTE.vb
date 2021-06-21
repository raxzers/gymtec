Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("CLIENTE")>
Partial Public Class CLIENTE
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property Numerocedula As Integer

    <Required>
    <StringLength(20)>
    Public Property Snombre As String

    Public Overridable Property GIMNASIO As GIMNASIO
End Class
