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
    Public Class GIMNASIOController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/GIMNASIO
        Function GetGIMNASIO() As IQueryable(Of GIMNASIO)
            Return db.GIMNASIO
        End Function

        ' GET: api/GIMNASIO/5
        <ResponseType(GetType(GIMNASIO))>
        Function GetGIMNASIO(ByVal id As String) As IHttpActionResult
            Dim gIMNASIO As GIMNASIO = db.GIMNASIO.Find(id)
            If IsNothing(gIMNASIO) Then
                Return NotFound()
            End If

            Return Ok(gIMNASIO)
        End Function

        ' PUT: api/GIMNASIO/5
        <ResponseType(GetType(Void))>
        Function PutGIMNASIO(ByVal id As String, ByVal gIMNASIO As GIMNASIO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = gIMNASIO.Gymnombre Then
                Return BadRequest()
            End If

            db.Entry(gIMNASIO).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (GIMNASIOExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/GIMNASIO
        <ResponseType(GetType(GIMNASIO))>
        Function PostGIMNASIO(ByVal gIMNASIO As GIMNASIO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.GIMNASIO.Add(gIMNASIO)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (GIMNASIOExists(gIMNASIO.Gymnombre)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = gIMNASIO.Gymnombre}, gIMNASIO)
        End Function

        ' DELETE: api/GIMNASIO/5
        <ResponseType(GetType(GIMNASIO))>
        Function DeleteGIMNASIO(ByVal id As String) As IHttpActionResult
            Dim gIMNASIO As GIMNASIO = db.GIMNASIO.Find(id)
            If IsNothing(gIMNASIO) Then
                Return NotFound()
            End If

            db.GIMNASIO.Remove(gIMNASIO)
            db.SaveChanges()

            Return Ok(gIMNASIO)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function GIMNASIOExists(ByVal id As String) As Boolean
            Return db.GIMNASIO.Count(Function(e) e.Gymnombre = id) > 0
        End Function
    End Class
End Namespace