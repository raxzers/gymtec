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
    Public Class LISTAEMPLEADOController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/LISTAEMPLEADO
        Function GetLISTAEMPLEADO() As IQueryable(Of LISTAEMPLEADO)
            Return db.LISTAEMPLEADO
        End Function

        ' GET: api/LISTAEMPLEADO/5
        <ResponseType(GetType(LISTAEMPLEADO))>
        Function GetLISTAEMPLEADO(ByVal id As String) As IHttpActionResult
            Dim lISTAEMPLEADO As LISTAEMPLEADO = db.LISTAEMPLEADO.Find(id)
            If IsNothing(lISTAEMPLEADO) Then
                Return NotFound()
            End If

            Return Ok(lISTAEMPLEADO)
        End Function

        ' PUT: api/LISTAEMPLEADO/5
        <ResponseType(GetType(Void))>
        Function PutLISTAEMPLEADO(ByVal id As String, ByVal lISTAEMPLEADO As LISTAEMPLEADO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = lISTAEMPLEADO.Planillaid Then
                Return BadRequest()
            End If

            db.Entry(lISTAEMPLEADO).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (LISTAEMPLEADOExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/LISTAEMPLEADO
        <ResponseType(GetType(LISTAEMPLEADO))>
        Function PostLISTAEMPLEADO(ByVal lISTAEMPLEADO As LISTAEMPLEADO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.LISTAEMPLEADO.Add(lISTAEMPLEADO)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (LISTAEMPLEADOExists(lISTAEMPLEADO.Planillaid)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = lISTAEMPLEADO.Planillaid}, lISTAEMPLEADO)
        End Function

        ' DELETE: api/LISTAEMPLEADO/5
        <ResponseType(GetType(LISTAEMPLEADO))>
        Function DeleteLISTAEMPLEADO(ByVal id As String) As IHttpActionResult
            Dim lISTAEMPLEADO As LISTAEMPLEADO = db.LISTAEMPLEADO.Find(id)
            If IsNothing(lISTAEMPLEADO) Then
                Return NotFound()
            End If

            db.LISTAEMPLEADO.Remove(lISTAEMPLEADO)
            db.SaveChanges()

            Return Ok(lISTAEMPLEADO)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function LISTAEMPLEADOExists(ByVal id As String) As Boolean
            Return db.LISTAEMPLEADO.Count(Function(e) e.Planillaid = id) > 0
        End Function
    End Class
End Namespace