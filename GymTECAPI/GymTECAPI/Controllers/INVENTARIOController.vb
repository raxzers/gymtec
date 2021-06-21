Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports GymTECAPI

Namespace Controllers
    Public Class INVENTARIOController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/INVENTARIO
        Function GetINVENTARIO() As IQueryable(Of INVENTARIO)
            Return db.INVENTARIO
        End Function

        ' GET: api/INVENTARIO/5
        <ResponseType(GetType(INVENTARIO))>
        Function GetINVENTARIO(ByVal id As String) As IHttpActionResult
            Dim iNVENTARIO As INVENTARIO = db.INVENTARIO.Find(id)
            If IsNothing(iNVENTARIO) Then
                Return NotFound()
            End If

            Return Ok(iNVENTARIO)
        End Function

        ' PUT: api/INVENTARIO/5
        <ResponseType(GetType(Void))>
        Function PutINVENTARIO(ByVal id As String, ByVal iNVENTARIO As INVENTARIO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = iNVENTARIO.Numeroserie Then
                Return BadRequest()
            End If

            db.Entry(iNVENTARIO).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (INVENTARIOExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/INVENTARIO
        <ResponseType(GetType(INVENTARIO))>
        Function PostINVENTARIO(ByVal iNVENTARIO As INVENTARIO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.INVENTARIO.Add(iNVENTARIO)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (INVENTARIOExists(iNVENTARIO.Numeroserie)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = iNVENTARIO.Numeroserie}, iNVENTARIO)
        End Function

        ' DELETE: api/INVENTARIO/5
        <ResponseType(GetType(INVENTARIO))>
        Function DeleteINVENTARIO(ByVal id As String) As IHttpActionResult
            Dim iNVENTARIO As INVENTARIO = db.INVENTARIO.Find(id)
            If IsNothing(iNVENTARIO) Then
                Return NotFound()
            End If

            db.INVENTARIO.Remove(iNVENTARIO)
            db.SaveChanges()

            Return Ok(iNVENTARIO)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function INVENTARIOExists(ByVal id As String) As Boolean
            Return db.INVENTARIO.Count(Function(e) e.Numeroserie = id) > 0
        End Function
    End Class
End Namespace