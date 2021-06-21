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
    Public Class TIPOEQUIPOController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/TIPOEQUIPO
        Function GetTIPOEQUIPO() As IQueryable(Of TIPOEQUIPO)
            Return db.TIPOEQUIPO
        End Function

        ' GET: api/TIPOEQUIPO/5
        <ResponseType(GetType(TIPOEQUIPO))>
        Function GetTIPOEQUIPO(ByVal id As String) As IHttpActionResult
            Dim tIPOEQUIPO As TIPOEQUIPO = db.TIPOEQUIPO.Find(id)
            If IsNothing(tIPOEQUIPO) Then
                Return NotFound()
            End If

            Return Ok(tIPOEQUIPO)
        End Function

        ' PUT: api/TIPOEQUIPO/5
        <ResponseType(GetType(Void))>
        Function PutTIPOEQUIPO(ByVal id As String, ByVal tIPOEQUIPO As TIPOEQUIPO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = tIPOEQUIPO.Idequipo Then
                Return BadRequest()
            End If

            db.Entry(tIPOEQUIPO).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (TIPOEQUIPOExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/TIPOEQUIPO
        <ResponseType(GetType(TIPOEQUIPO))>
        Function PostTIPOEQUIPO(ByVal tIPOEQUIPO As TIPOEQUIPO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.TIPOEQUIPO.Add(tIPOEQUIPO)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (TIPOEQUIPOExists(tIPOEQUIPO.Idequipo)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = tIPOEQUIPO.Idequipo}, tIPOEQUIPO)
        End Function

        ' DELETE: api/TIPOEQUIPO/5
        <ResponseType(GetType(TIPOEQUIPO))>
        Function DeleteTIPOEQUIPO(ByVal id As String) As IHttpActionResult
            Dim tIPOEQUIPO As TIPOEQUIPO = db.TIPOEQUIPO.Find(id)
            If IsNothing(tIPOEQUIPO) Then
                Return NotFound()
            End If

            db.TIPOEQUIPO.Remove(tIPOEQUIPO)
            db.SaveChanges()

            Return Ok(tIPOEQUIPO)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function TIPOEQUIPOExists(ByVal id As String) As Boolean
            Return db.TIPOEQUIPO.Count(Function(e) e.Idequipo = id) > 0
        End Function
    End Class
End Namespace