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
    Public Class LISTATRATAMIENTOSController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/LISTATRATAMIENTOS
        Function GetLISTATRATAMIENTOS() As IQueryable(Of LISTATRATAMIENTOS)
            Return db.LISTATRATAMIENTOS
        End Function

        ' GET: api/LISTATRATAMIENTOS/5
        <ResponseType(GetType(LISTATRATAMIENTOS))>
        Function GetLISTATRATAMIENTOS(ByVal id As String) As IHttpActionResult
            Dim lISTATRATAMIENTOS As LISTATRATAMIENTOS = db.LISTATRATAMIENTOS.Find(id)
            If IsNothing(lISTATRATAMIENTOS) Then
                Return NotFound()
            End If

            Return Ok(lISTATRATAMIENTOS)
        End Function

        ' PUT: api/LISTATRATAMIENTOS/5
        <ResponseType(GetType(Void))>
        Function PutLISTATRATAMIENTOS(ByVal id As String, ByVal lISTATRATAMIENTOS As LISTATRATAMIENTOS) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = lISTATRATAMIENTOS.Gymsnombre Then
                Return BadRequest()
            End If

            db.Entry(lISTATRATAMIENTOS).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (LISTATRATAMIENTOSExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/LISTATRATAMIENTOS
        <ResponseType(GetType(LISTATRATAMIENTOS))>
        Function PostLISTATRATAMIENTOS(ByVal lISTATRATAMIENTOS As LISTATRATAMIENTOS) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.LISTATRATAMIENTOS.Add(lISTATRATAMIENTOS)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (LISTATRATAMIENTOSExists(lISTATRATAMIENTOS.Gymsnombre)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = lISTATRATAMIENTOS.Gymsnombre}, lISTATRATAMIENTOS)
        End Function

        ' DELETE: api/LISTATRATAMIENTOS/5
        <ResponseType(GetType(LISTATRATAMIENTOS))>
        Function DeleteLISTATRATAMIENTOS(ByVal id As String) As IHttpActionResult
            Dim lISTATRATAMIENTOS As LISTATRATAMIENTOS = db.LISTATRATAMIENTOS.Find(id)
            If IsNothing(lISTATRATAMIENTOS) Then
                Return NotFound()
            End If

            db.LISTATRATAMIENTOS.Remove(lISTATRATAMIENTOS)
            db.SaveChanges()

            Return Ok(lISTATRATAMIENTOS)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function LISTATRATAMIENTOSExists(ByVal id As String) As Boolean
            Return db.LISTATRATAMIENTOS.Count(Function(e) e.Gymsnombre = id) > 0
        End Function
    End Class
End Namespace