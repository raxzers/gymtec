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
    Public Class LISTACLASESController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/LISTACLASES
        Function GetLISTACLASES() As IQueryable(Of LISTACLASES)
            Return db.LISTACLASES
        End Function

        ' GET: api/LISTACLASES/5
        <ResponseType(GetType(LISTACLASES))>
        Function GetLISTACLASES(ByVal id As String) As IHttpActionResult
            Dim lISTACLASES As LISTACLASES = db.LISTACLASES.Find(id)
            If IsNothing(lISTACLASES) Then
                Return NotFound()
            End If

            Return Ok(lISTACLASES)
        End Function

        ' PUT: api/LISTACLASES/5
        <ResponseType(GetType(Void))>
        Function PutLISTACLASES(ByVal id As String, ByVal lISTACLASES As LISTACLASES) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = lISTACLASES.Gymsnombre Then
                Return BadRequest()
            End If

            db.Entry(lISTACLASES).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (LISTACLASESExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/LISTACLASES
        <ResponseType(GetType(LISTACLASES))>
        Function PostLISTACLASES(ByVal lISTACLASES As LISTACLASES) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.LISTACLASES.Add(lISTACLASES)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (LISTACLASESExists(lISTACLASES.Gymsnombre)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = lISTACLASES.Gymsnombre}, lISTACLASES)
        End Function

        ' DELETE: api/LISTACLASES/5
        <ResponseType(GetType(LISTACLASES))>
        Function DeleteLISTACLASES(ByVal id As String) As IHttpActionResult
            Dim lISTACLASES As LISTACLASES = db.LISTACLASES.Find(id)
            If IsNothing(lISTACLASES) Then
                Return NotFound()
            End If

            db.LISTACLASES.Remove(lISTACLASES)
            db.SaveChanges()

            Return Ok(lISTACLASES)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function LISTACLASESExists(ByVal id As String) As Boolean
            Return db.LISTACLASES.Count(Function(e) e.Gymsnombre = id) > 0
        End Function
    End Class
End Namespace