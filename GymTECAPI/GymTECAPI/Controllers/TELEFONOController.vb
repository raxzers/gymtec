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
    Public Class TELEFONOController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/TELEFONO
        Function GetTELEFONO() As IQueryable(Of TELEFONO)
            Return db.TELEFONO
        End Function

        ' GET: api/TELEFONO/5
        <ResponseType(GetType(TELEFONO))>
        Function GetTELEFONO(ByVal id As String) As IHttpActionResult
            Dim tELEFONO As TELEFONO = db.TELEFONO.Find(id)
            If IsNothing(tELEFONO) Then
                Return NotFound()
            End If

            Return Ok(tELEFONO)
        End Function

        ' PUT: api/TELEFONO/5
        <ResponseType(GetType(Void))>
        Function PutTELEFONO(ByVal id As String, ByVal tELEFONO As TELEFONO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = tELEFONO.Snombre Then
                Return BadRequest()
            End If

            db.Entry(tELEFONO).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (TELEFONOExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/TELEFONO
        <ResponseType(GetType(TELEFONO))>
        Function PostTELEFONO(ByVal tELEFONO As TELEFONO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.TELEFONO.Add(tELEFONO)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (TELEFONOExists(tELEFONO.Snombre)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = tELEFONO.Snombre}, tELEFONO)
        End Function

        ' DELETE: api/TELEFONO/5
        <ResponseType(GetType(TELEFONO))>
        Function DeleteTELEFONO(ByVal id As String) As IHttpActionResult
            Dim tELEFONO As TELEFONO = db.TELEFONO.Find(id)
            If IsNothing(tELEFONO) Then
                Return NotFound()
            End If

            db.TELEFONO.Remove(tELEFONO)
            db.SaveChanges()

            Return Ok(tELEFONO)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function TELEFONOExists(ByVal id As String) As Boolean
            Return db.TELEFONO.Count(Function(e) e.Snombre = id) > 0
        End Function
    End Class
End Namespace