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
    Public Class SUCURSALController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/SUCURSAL
        Function GetSUCURSAL() As IQueryable(Of SUCURSAL)
            Return db.SUCURSAL
        End Function

        ' GET: api/SUCURSAL/5
        <ResponseType(GetType(SUCURSAL))>
        Function GetSUCURSAL(ByVal id As String) As IHttpActionResult
            Dim sUCURSAL As SUCURSAL = db.SUCURSAL.Find(id)
            If IsNothing(sUCURSAL) Then
                Return NotFound()
            End If

            Return Ok(sUCURSAL)
        End Function

        ' PUT: api/SUCURSAL/5
        <ResponseType(GetType(Void))>
        Function PutSUCURSAL(ByVal id As String, ByVal sUCURSAL As SUCURSAL) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = sUCURSAL.Nombre Then
                Return BadRequest()
            End If

            db.Entry(sUCURSAL).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (SUCURSALExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/SUCURSAL
        <ResponseType(GetType(SUCURSAL))>
        Function PostSUCURSAL(ByVal sUCURSAL As SUCURSAL) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.SUCURSAL.Add(sUCURSAL)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (SUCURSALExists(sUCURSAL.Nombre)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = sUCURSAL.Nombre}, sUCURSAL)
        End Function

        ' DELETE: api/SUCURSAL/5
        <ResponseType(GetType(SUCURSAL))>
        Function DeleteSUCURSAL(ByVal id As String) As IHttpActionResult
            Dim sUCURSAL As SUCURSAL = db.SUCURSAL.Find(id)
            If IsNothing(sUCURSAL) Then
                Return NotFound()
            End If

            db.SUCURSAL.Remove(sUCURSAL)
            db.SaveChanges()

            Return Ok(sUCURSAL)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function SUCURSALExists(ByVal id As String) As Boolean
            Return db.SUCURSAL.Count(Function(e) e.Nombre = id) > 0
        End Function
    End Class
End Namespace