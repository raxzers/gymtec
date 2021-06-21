Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("SUCURSAL")>
Partial Public Class SUCURSAL
    Public Sub New()
        GIMNASIO = New HashSet(Of GIMNASIO)()
    End Sub

    <Key>
    <StringLength(20)>
    Public Property Nombre As String

    Public Property Capacidadmaxima As Integer?

    <StringLength(16)>
    Public Property Administrador As String

    <Column(TypeName:="date")>
    Public Property Fechadeapertura As Date?

    Public Property Horario As TimeSpan?

    <StringLength(15)>
    Public Property Canton As String

    <StringLength(15)>
    Public Property Provincia As String

    <StringLength(15)>
    Public Property Distrito As String

    Public Overridable Property GIMNASIO As ICollection(Of GIMNASIO)

    Public Overridable Property TELEFONO As TELEFONO
End Class
