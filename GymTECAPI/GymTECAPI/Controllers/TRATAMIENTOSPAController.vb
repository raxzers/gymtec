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
    Public Class TRATAMIENTOSPAController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/TRATAMIENTOSPA
        Function GetTRATAMIENTOSPA() As IQueryable(Of TRATAMIENTOSPA)
            Return db.TRATAMIENTOSPA
        End Function

        ' GET: api/TRATAMIENTOSPA/5
        <ResponseType(GetType(TRATAMIENTOSPA))>
        Function GetTRATAMIENTOSPA(ByVal id As String) As IHttpActionResult
            Dim tRATAMIENTOSPA As TRATAMIENTOSPA = db.TRATAMIENTOSPA.Find(id)
            If IsNothing(tRATAMIENTOSPA) Then
                Return NotFound()
            End If

            Return Ok(tRATAMIENTOSPA)
        End Function

        ' PUT: api/TRATAMIENTOSPA/5
        <ResponseType(GetType(Void))>
        Function PutTRATAMIENTOSPA(ByVal id As String, ByVal tRATAMIENTOSPA As TRATAMIENTOSPA) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = tRATAMIENTOSPA.Idtratamiento Then
                Return BadRequest()
            End If

            db.Entry(tRATAMIENTOSPA).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (TRATAMIENTOSPAExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/TRATAMIENTOSPA
        <ResponseType(GetType(TRATAMIENTOSPA))>
        Function PostTRATAMIENTOSPA(ByVal tRATAMIENTOSPA As TRATAMIENTOSPA) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.TRATAMIENTOSPA.Add(tRATAMIENTOSPA)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (TRATAMIENTOSPAExists(tRATAMIENTOSPA.Idtratamiento)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = tRATAMIENTOSPA.Idtratamiento}, tRATAMIENTOSPA)
        End Function

        ' DELETE: api/TRATAMIENTOSPA/5
        <ResponseType(GetType(TRATAMIENTOSPA))>
        Function DeleteTRATAMIENTOSPA(ByVal id As String) As IHttpActionResult
            Dim tRATAMIENTOSPA As TRATAMIENTOSPA = db.TRATAMIENTOSPA.Find(id)
            If IsNothing(tRATAMIENTOSPA) Then
                Return NotFound()
            End If

            db.TRATAMIENTOSPA.Remove(tRATAMIENTOSPA)
            db.SaveChanges()

            Return Ok(tRATAMIENTOSPA)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function TRATAMIENTOSPAExists(ByVal id As String) As Boolean
            Return db.TRATAMIENTOSPA.Count(Function(e) e.Idtratamiento = id) > 0
        End Function
    End Class
End Namespace