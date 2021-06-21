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
    Public Class LISTACLASESEMANALController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/LISTACLASESEMANAL
        Function GetLISTACLASESEMANAL() As IQueryable(Of LISTACLASESEMANAL)
            Return db.LISTACLASESEMANAL
        End Function

        ' GET: api/LISTACLASESEMANAL/5
        <ResponseType(GetType(LISTACLASESEMANAL))>
        Function GetLISTACLASESEMANAL(ByVal id As String) As IHttpActionResult
            Dim lISTACLASESEMANAL As LISTACLASESEMANAL = db.LISTACLASESEMANAL.Find(id)
            If IsNothing(lISTACLASESEMANAL) Then
                Return NotFound()
            End If

            Return Ok(lISTACLASESEMANAL)
        End Function

        ' PUT: api/LISTACLASESEMANAL/5
        <ResponseType(GetType(Void))>
        Function PutLISTACLASESEMANAL(ByVal id As String, ByVal lISTACLASESEMANAL As LISTACLASESEMANAL) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = lISTACLASESEMANAL.Idclasecalendario Then
                Return BadRequest()
            End If

            db.Entry(lISTACLASESEMANAL).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (LISTACLASESEMANALExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/LISTACLASESEMANAL
        <ResponseType(GetType(LISTACLASESEMANAL))>
        Function PostLISTACLASESEMANAL(ByVal lISTACLASESEMANAL As LISTACLASESEMANAL) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.LISTACLASESEMANAL.Add(lISTACLASESEMANAL)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (LISTACLASESEMANALExists(lISTACLASESEMANAL.Idclasecalendario)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = lISTACLASESEMANAL.Idclasecalendario}, lISTACLASESEMANAL)
        End Function

        ' DELETE: api/LISTACLASESEMANAL/5
        <ResponseType(GetType(LISTACLASESEMANAL))>
        Function DeleteLISTACLASESEMANAL(ByVal id As String) As IHttpActionResult
            Dim lISTACLASESEMANAL As LISTACLASESEMANAL = db.LISTACLASESEMANAL.Find(id)
            If IsNothing(lISTACLASESEMANAL) Then
                Return NotFound()
            End If

            db.LISTACLASESEMANAL.Remove(lISTACLASESEMANAL)
            db.SaveChanges()

            Return Ok(lISTACLASESEMANAL)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function LISTACLASESEMANALExists(ByVal id As String) As Boolean
            Return db.LISTACLASESEMANAL.Count(Function(e) e.Idclasecalendario = id) > 0
        End Function
    End Class
End Namespace