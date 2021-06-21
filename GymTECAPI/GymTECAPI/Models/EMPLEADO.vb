Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("EMPLEADO")>
Partial Public Class EMPLEADO
    Public Sub New()
        LISTAEMPLEADO = New HashSet(Of LISTAEMPLEADO)()
    End Sub

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property Numerocedula As Integer

    <StringLength(16)>
    Public Property Nombre As String

    <Column(TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property Horaslaboradas As Byte()

    <StringLength(15)>
    Public Property Tipoplantilla As String

    Public Property Salario As Integer?

    <StringLength(30)>
    Public Property Correo As String

    <StringLength(40)>
    Public Property Clasesimpartidas As String

    <StringLength(15)>
    Public Property Passw As String

    <StringLength(20)>
    Public Property Sucursal As String

    <StringLength(15)>
    Public Property Puesto As String

    Public Overridable Property LISTAEMPLEADO As ICollection(Of LISTAEMPLEADO)
End Class
