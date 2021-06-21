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
    Public Class PLANILLAController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/PLANILLA
        Function GetPLANILLA() As IQueryable(Of PLANILLA)
            Return db.PLANILLA
        End Function

        ' GET: api/PLANILLA/5
        <ResponseType(GetType(PLANILLA))>
        Function GetPLANILLA(ByVal id As String) As IHttpActionResult
            Dim pLANILLA As PLANILLA = db.PLANILLA.Find(id)
            If IsNothing(pLANILLA) Then
                Return NotFound()
            End If

            Return Ok(pLANILLA)
        End Function

        ' PUT: api/PLANILLA/5
        <ResponseType(GetType(Void))>
        Function PutPLANILLA(ByVal id As String, ByVal pLANILLA As PLANILLA) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = pLANILLA.ID Then
                Return BadRequest()
            End If

            db.Entry(pLANILLA).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (PLANILLAExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/PLANILLA
        <ResponseType(GetType(PLANILLA))>
        Function PostPLANILLA(ByVal pLANILLA As PLANILLA) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.PLANILLA.Add(pLANILLA)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (PLANILLAExists(pLANILLA.ID)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = pLANILLA.ID}, pLANILLA)
        End Function

        ' DELETE: api/PLANILLA/5
        <ResponseType(GetType(PLANILLA))>
        Function DeletePLANILLA(ByVal id As String) As IHttpActionResult
            Dim pLANILLA As PLANILLA = db.PLANILLA.Find(id)
            If IsNothing(pLANILLA) Then
                Return NotFound()
            End If

            db.PLANILLA.Remove(pLANILLA)
            db.SaveChanges()

            Return Ok(pLANILLA)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function PLANILLAExists(ByVal id As String) As Boolean
            Return db.PLANILLA.Count(Function(e) e.ID = id) > 0
        End Function
    End Class
End Namespace