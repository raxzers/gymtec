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
    Public Class CALENDARIOController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/CALENDARIO
        Function GetCALENDARIO() As IQueryable(Of CALENDARIO)
            Return db.CALENDARIO
        End Function

        ' GET: api/CALENDARIO/5
        <ResponseType(GetType(CALENDARIO))>
        Function GetCALENDARIO(ByVal id As String) As IHttpActionResult
            Dim cALENDARIO As CALENDARIO = db.CALENDARIO.Find(id)
            If IsNothing(cALENDARIO) Then
                Return NotFound()
            End If

            Return Ok(cALENDARIO)
        End Function

        ' PUT: api/CALENDARIO/5
        <ResponseType(GetType(Void))>
        Function PutCALENDARIO(ByVal id As String, ByVal cALENDARIO As CALENDARIO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = cALENDARIO.Idclasecalendario Then
                Return BadRequest()
            End If

            db.Entry(cALENDARIO).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (CALENDARIOExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/CALENDARIO
        <ResponseType(GetType(CALENDARIO))>
        Function PostCALENDARIO(ByVal cALENDARIO As CALENDARIO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.CALENDARIO.Add(cALENDARIO)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (CALENDARIOExists(cALENDARIO.Idclasecalendario)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = cALENDARIO.Idclasecalendario}, cALENDARIO)
        End Function

        ' DELETE: api/CALENDARIO/5
        <ResponseType(GetType(CALENDARIO))>
        Function DeleteCALENDARIO(ByVal id As String) As IHttpActionResult
            Dim cALENDARIO As CALENDARIO = db.CALENDARIO.Find(id)
            If IsNothing(cALENDARIO) Then
                Return NotFound()
            End If

            db.CALENDARIO.Remove(cALENDARIO)
            db.SaveChanges()

            Return Ok(cALENDARIO)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function CALENDARIOExists(ByVal id As String) As Boolean
            Return db.CALENDARIO.Count(Function(e) e.Idclasecalendario = id) > 0
        End Function
    End Class
End Namespace