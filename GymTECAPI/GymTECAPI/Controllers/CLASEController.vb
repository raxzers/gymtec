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
    Public Class CLASEController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/CLASE
        Function GetCLASE() As IQueryable(Of CLASE)
            Return db.CLASE
        End Function

        ' GET: api/CLASE/5
        <ResponseType(GetType(CLASE))>
        Function GetCLASE(ByVal id As String) As IHttpActionResult
            Dim cLASE As CLASE = db.CLASE.Find(id)
            If IsNothing(cLASE) Then
                Return NotFound()
            End If

            Return Ok(cLASE)
        End Function

        ' PUT: api/CLASE/5
        <ResponseType(GetType(Void))>
        Function PutCLASE(ByVal id As String, ByVal cLASE As CLASE) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = cLASE.Idclase Then
                Return BadRequest()
            End If

            db.Entry(cLASE).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (CLASEExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/CLASE
        <ResponseType(GetType(CLASE))>
        Function PostCLASE(ByVal cLASE As CLASE) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.CLASE.Add(cLASE)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (CLASEExists(cLASE.Idclase)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = cLASE.Idclase}, cLASE)
        End Function

        ' DELETE: api/CLASE/5
        <ResponseType(GetType(CLASE))>
        Function DeleteCLASE(ByVal id As String) As IHttpActionResult
            Dim cLASE As CLASE = db.CLASE.Find(id)
            If IsNothing(cLASE) Then
                Return NotFound()
            End If

            db.CLASE.Remove(cLASE)
            db.SaveChanges()

            Return Ok(cLASE)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function CLASEExists(ByVal id As String) As Boolean
            Return db.CLASE.Count(Function(e) e.Idclase = id) > 0
        End Function
    End Class
End Namespace