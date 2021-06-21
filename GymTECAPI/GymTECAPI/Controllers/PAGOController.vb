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
    Public Class PAGOController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/PAGO
        Function GetPAGO() As IQueryable(Of PAGO)
            Return db.PAGO
        End Function

        ' GET: api/PAGO/5
        <ResponseType(GetType(PAGO))>
        Function GetPAGO(ByVal id As String) As IHttpActionResult
            Dim pAGO As PAGO = db.PAGO.Find(id)
            If IsNothing(pAGO) Then
                Return NotFound()
            End If

            Return Ok(pAGO)
        End Function

        ' PUT: api/PAGO/5
        <ResponseType(GetType(Void))>
        Function PutPAGO(ByVal id As String, ByVal pAGO As PAGO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = pAGO.Planillaid Then
                Return BadRequest()
            End If

            db.Entry(pAGO).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (PAGOExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/PAGO
        <ResponseType(GetType(PAGO))>
        Function PostPAGO(ByVal pAGO As PAGO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.PAGO.Add(pAGO)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (PAGOExists(pAGO.Planillaid)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = pAGO.Planillaid}, pAGO)
        End Function

        ' DELETE: api/PAGO/5
        <ResponseType(GetType(PAGO))>
        Function DeletePAGO(ByVal id As String) As IHttpActionResult
            Dim pAGO As PAGO = db.PAGO.Find(id)
            If IsNothing(pAGO) Then
                Return NotFound()
            End If

            db.PAGO.Remove(pAGO)
            db.SaveChanges()

            Return Ok(pAGO)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function PAGOExists(ByVal id As String) As Boolean
            Return db.PAGO.Count(Function(e) e.Planillaid = id) > 0
        End Function
    End Class
End Namespace