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
    Public Class LISTAPRODUCTOSController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/LISTAPRODUCTOS
        Function GetLISTAPRODUCTOS() As IQueryable(Of LISTAPRODUCTOS)
            Return db.LISTAPRODUCTOS
        End Function

        ' GET: api/LISTAPRODUCTOS/5
        <ResponseType(GetType(LISTAPRODUCTOS))>
        Function GetLISTAPRODUCTOS(ByVal id As String) As IHttpActionResult
            Dim lISTAPRODUCTOS As LISTAPRODUCTOS = db.LISTAPRODUCTOS.Find(id)
            If IsNothing(lISTAPRODUCTOS) Then
                Return NotFound()
            End If

            Return Ok(lISTAPRODUCTOS)
        End Function

        ' PUT: api/LISTAPRODUCTOS/5
        <ResponseType(GetType(Void))>
        Function PutLISTAPRODUCTOS(ByVal id As String, ByVal lISTAPRODUCTOS As LISTAPRODUCTOS) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = lISTAPRODUCTOS.Gymsnombre Then
                Return BadRequest()
            End If

            db.Entry(lISTAPRODUCTOS).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (LISTAPRODUCTOSExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/LISTAPRODUCTOS
        <ResponseType(GetType(LISTAPRODUCTOS))>
        Function PostLISTAPRODUCTOS(ByVal lISTAPRODUCTOS As LISTAPRODUCTOS) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.LISTAPRODUCTOS.Add(lISTAPRODUCTOS)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (LISTAPRODUCTOSExists(lISTAPRODUCTOS.Gymsnombre)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = lISTAPRODUCTOS.Gymsnombre}, lISTAPRODUCTOS)
        End Function

        ' DELETE: api/LISTAPRODUCTOS/5
        <ResponseType(GetType(LISTAPRODUCTOS))>
        Function DeleteLISTAPRODUCTOS(ByVal id As String) As IHttpActionResult
            Dim lISTAPRODUCTOS As LISTAPRODUCTOS = db.LISTAPRODUCTOS.Find(id)
            If IsNothing(lISTAPRODUCTOS) Then
                Return NotFound()
            End If

            db.LISTAPRODUCTOS.Remove(lISTAPRODUCTOS)
            db.SaveChanges()

            Return Ok(lISTAPRODUCTOS)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function LISTAPRODUCTOSExists(ByVal id As String) As Boolean
            Return db.LISTAPRODUCTOS.Count(Function(e) e.Gymsnombre = id) > 0
        End Function
    End Class
End Namespace