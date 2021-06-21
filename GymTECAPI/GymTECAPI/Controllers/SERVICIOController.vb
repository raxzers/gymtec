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
    Public Class SERVICIOController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/SERVICIO
        Function GetSERVICIO() As IQueryable(Of SERVICIO)
            Return db.SERVICIO
        End Function

        ' GET: api/SERVICIO/5
        <ResponseType(GetType(SERVICIO))>
        Function GetSERVICIO(ByVal id As String) As IHttpActionResult
            Dim sERVICIO As SERVICIO = db.SERVICIO.Find(id)
            If IsNothing(sERVICIO) Then
                Return NotFound()
            End If

            Return Ok(sERVICIO)
        End Function

        ' PUT: api/SERVICIO/5
        <ResponseType(GetType(Void))>
        Function PutSERVICIO(ByVal id As String, ByVal sERVICIO As SERVICIO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = sERVICIO.Idservicio Then
                Return BadRequest()
            End If

            db.Entry(sERVICIO).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (SERVICIOExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/SERVICIO
        <ResponseType(GetType(SERVICIO))>
        Function PostSERVICIO(ByVal sERVICIO As SERVICIO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.SERVICIO.Add(sERVICIO)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (SERVICIOExists(sERVICIO.Idservicio)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = sERVICIO.Idservicio}, sERVICIO)
        End Function

        ' DELETE: api/SERVICIO/5
        <ResponseType(GetType(SERVICIO))>
        Function DeleteSERVICIO(ByVal id As String) As IHttpActionResult
            Dim sERVICIO As SERVICIO = db.SERVICIO.Find(id)
            If IsNothing(sERVICIO) Then
                Return NotFound()
            End If

            db.SERVICIO.Remove(sERVICIO)
            db.SaveChanges()

            Return Ok(sERVICIO)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function SERVICIOExists(ByVal id As String) As Boolean
            Return db.SERVICIO.Count(Function(e) e.Idservicio = id) > 0
        End Function
    End Class
End Namespace