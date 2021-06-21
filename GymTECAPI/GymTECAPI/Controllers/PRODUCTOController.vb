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
    Public Class PRODUCTOController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/PRODUCTO
        Function GetPRODUCTO() As IQueryable(Of PRODUCTO)
            Return db.PRODUCTO
        End Function

        ' GET: api/PRODUCTO/5
        <ResponseType(GetType(PRODUCTO))>
        Function GetPRODUCTO(ByVal id As String) As IHttpActionResult
            Dim pRODUCTO As PRODUCTO = db.PRODUCTO.Find(id)
            If IsNothing(pRODUCTO) Then
                Return NotFound()
            End If

            Return Ok(pRODUCTO)
        End Function

        ' PUT: api/PRODUCTO/5
        <ResponseType(GetType(Void))>
        Function PutPRODUCTO(ByVal id As String, ByVal pRODUCTO As PRODUCTO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = pRODUCTO.Codigodebarras Then
                Return BadRequest()
            End If

            db.Entry(pRODUCTO).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (PRODUCTOExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/PRODUCTO
        <ResponseType(GetType(PRODUCTO))>
        Function PostPRODUCTO(ByVal pRODUCTO As PRODUCTO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.PRODUCTO.Add(pRODUCTO)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (PRODUCTOExists(pRODUCTO.Codigodebarras)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = pRODUCTO.Codigodebarras}, pRODUCTO)
        End Function

        ' DELETE: api/PRODUCTO/5
        <ResponseType(GetType(PRODUCTO))>
        Function DeletePRODUCTO(ByVal id As String) As IHttpActionResult
            Dim pRODUCTO As PRODUCTO = db.PRODUCTO.Find(id)
            If IsNothing(pRODUCTO) Then
                Return NotFound()
            End If

            db.PRODUCTO.Remove(pRODUCTO)
            db.SaveChanges()

            Return Ok(pRODUCTO)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function PRODUCTOExists(ByVal id As String) As Boolean
            Return db.PRODUCTO.Count(Function(e) e.Codigodebarras = id) > 0
        End Function
    End Class
End Namespace