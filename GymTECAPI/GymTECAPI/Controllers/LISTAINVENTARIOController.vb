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
    Public Class LISTAINVENTARIOController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/LISTAINVENTARIO
        Function GetLISTAINVENTARIO() As IQueryable(Of LISTAINVENTARIO)
            Return db.LISTAINVENTARIO
        End Function

        ' GET: api/LISTAINVENTARIO/5
        <ResponseType(GetType(LISTAINVENTARIO))>
        Function GetLISTAINVENTARIO(ByVal id As String) As IHttpActionResult
            Dim lISTAINVENTARIO As LISTAINVENTARIO = db.LISTAINVENTARIO.Find(id)
            If IsNothing(lISTAINVENTARIO) Then
                Return NotFound()
            End If

            Return Ok(lISTAINVENTARIO)
        End Function

        ' PUT: api/LISTAINVENTARIO/5
        <ResponseType(GetType(Void))>
        Function PutLISTAINVENTARIO(ByVal id As String, ByVal lISTAINVENTARIO As LISTAINVENTARIO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = lISTAINVENTARIO.Gymsnombre Then
                Return BadRequest()
            End If

            db.Entry(lISTAINVENTARIO).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (LISTAINVENTARIOExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/LISTAINVENTARIO
        <ResponseType(GetType(LISTAINVENTARIO))>
        Function PostLISTAINVENTARIO(ByVal lISTAINVENTARIO As LISTAINVENTARIO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.LISTAINVENTARIO.Add(lISTAINVENTARIO)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (LISTAINVENTARIOExists(lISTAINVENTARIO.Gymsnombre)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = lISTAINVENTARIO.Gymsnombre}, lISTAINVENTARIO)
        End Function

        ' DELETE: api/LISTAINVENTARIO/5
        <ResponseType(GetType(LISTAINVENTARIO))>
        Function DeleteLISTAINVENTARIO(ByVal id As String) As IHttpActionResult
            Dim lISTAINVENTARIO As LISTAINVENTARIO = db.LISTAINVENTARIO.Find(id)
            If IsNothing(lISTAINVENTARIO) Then
                Return NotFound()
            End If

            db.LISTAINVENTARIO.Remove(lISTAINVENTARIO)
            db.SaveChanges()

            Return Ok(lISTAINVENTARIO)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function LISTAINVENTARIOExists(ByVal id As String) As Boolean
            Return db.LISTAINVENTARIO.Count(Function(e) e.Gymsnombre = id) > 0
        End Function
    End Class
End Namespace