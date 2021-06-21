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
    Public Class EMPLEADOController
        Inherits System.Web.Http.ApiController

        Private db As New GymTECModel

        ' GET: api/EMPLEADO
        Function GetEMPLEADO() As IQueryable(Of EMPLEADO)
            Return db.EMPLEADO
        End Function

        ' GET: api/EMPLEADO/5
        <ResponseType(GetType(EMPLEADO))>
        Function GetEMPLEADO(ByVal id As Integer) As IHttpActionResult
            Dim eMPLEADO As EMPLEADO = db.EMPLEADO.Find(id)
            If IsNothing(eMPLEADO) Then
                Return NotFound()
            End If

            Return Ok(eMPLEADO)
        End Function

        ' PUT: api/EMPLEADO/5
        <ResponseType(GetType(Void))>
        Function PutEMPLEADO(ByVal id As Integer, ByVal eMPLEADO As EMPLEADO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = eMPLEADO.Numerocedula Then
                Return BadRequest()
            End If

            db.Entry(eMPLEADO).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (EMPLEADOExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/EMPLEADO
        <ResponseType(GetType(EMPLEADO))>
        Function PostEMPLEADO(ByVal eMPLEADO As EMPLEADO) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.EMPLEADO.Add(eMPLEADO)

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (EMPLEADOExists(eMPLEADO.Numerocedula)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = eMPLEADO.Numerocedula}, eMPLEADO)
        End Function

        ' DELETE: api/EMPLEADO/5
        <ResponseType(GetType(EMPLEADO))>
        Function DeleteEMPLEADO(ByVal id As Integer) As IHttpActionResult
            Dim eMPLEADO As EMPLEADO = db.EMPLEADO.Find(id)
            If IsNothing(eMPLEADO) Then
                Return NotFound()
            End If

            db.EMPLEADO.Remove(eMPLEADO)
            db.SaveChanges()

            Return Ok(eMPLEADO)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function EMPLEADOExists(ByVal id As Integer) As Boolean
            Return db.EMPLEADO.Count(Function(e) e.Numerocedula = id) > 0
        End Function
    End Class
End Namespace