Imports System
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Linq

Partial Public Class GymTECModel
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=BaseGymTECModel")
    End Sub

    Public Overridable Property CALENDARIO As DbSet(Of CALENDARIO)
    Public Overridable Property CLASE As DbSet(Of CLASE)
    Public Overridable Property CLIENTE As DbSet(Of CLIENTE)
    Public Overridable Property EMPLEADO As DbSet(Of EMPLEADO)
    Public Overridable Property GIMNASIO As DbSet(Of GIMNASIO)
    Public Overridable Property INVENTARIO As DbSet(Of INVENTARIO)
    Public Overridable Property PLANILLA As DbSet(Of PLANILLA)
    Public Overridable Property PRODUCTO As DbSet(Of PRODUCTO)
    Public Overridable Property SERVICIO As DbSet(Of SERVICIO)
    Public Overridable Property SUCURSAL As DbSet(Of SUCURSAL)
    Public Overridable Property TIPOEQUIPO As DbSet(Of TIPOEQUIPO)
    Public Overridable Property TRATAMIENTOSPA As DbSet(Of TRATAMIENTOSPA)
    Public Overridable Property LISTACLASES As DbSet(Of LISTACLASES)
    Public Overridable Property LISTACLASESEMANAL As DbSet(Of LISTACLASESEMANAL)
    Public Overridable Property LISTAEMPLEADO As DbSet(Of LISTAEMPLEADO)
    Public Overridable Property LISTAINVENTARIO As DbSet(Of LISTAINVENTARIO)
    Public Overridable Property LISTAPRODUCTOS As DbSet(Of LISTAPRODUCTOS)
    Public Overridable Property LISTATRATAMIENTOS As DbSet(Of LISTATRATAMIENTOS)
    Public Overridable Property PAGO As DbSet(Of PAGO)
    Public Overridable Property TELEFONO As DbSet(Of TELEFONO)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of CALENDARIO)() _
            .Property(Function(e) e.Idclasecalendario) _
            .IsUnicode(False)

        modelBuilder.Entity(Of CALENDARIO)() _
            .HasOptional(Function(e) e.LISTACLASESEMANAL) _
            .WithRequired(Function(e) e.CALENDARIO)

        modelBuilder.Entity(Of CLASE)() _
            .Property(Function(e) e.Idclase) _
            .IsUnicode(False)

        modelBuilder.Entity(Of CLASE)() _
            .Property(Function(e) e.Instructor) _
            .IsUnicode(False)

        modelBuilder.Entity(Of CLASE)() _
            .Property(Function(e) e.Grupalpersonal) _
            .IsUnicode(False)

        modelBuilder.Entity(Of CLASE)() _
            .Property(Function(e) e.Tipo) _
            .IsUnicode(False)

        modelBuilder.Entity(Of CLASE)() _
            .HasOptional(Function(e) e.CALENDARIO) _
            .WithRequired(Function(e) e.CLASE)

        modelBuilder.Entity(Of CLIENTE)() _
            .Property(Function(e) e.Snombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of EMPLEADO)() _
            .Property(Function(e) e.Nombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of EMPLEADO)() _
            .Property(Function(e) e.Horaslaboradas) _
            .IsFixedLength()

        modelBuilder.Entity(Of EMPLEADO)() _
            .Property(Function(e) e.Tipoplantilla) _
            .IsUnicode(False)

        modelBuilder.Entity(Of EMPLEADO)() _
            .Property(Function(e) e.Correo) _
            .IsUnicode(False)

        modelBuilder.Entity(Of EMPLEADO)() _
            .Property(Function(e) e.Clasesimpartidas) _
            .IsUnicode(False)

        modelBuilder.Entity(Of EMPLEADO)() _
            .Property(Function(e) e.Passw) _
            .IsUnicode(False)

        modelBuilder.Entity(Of EMPLEADO)() _
            .Property(Function(e) e.Sucursal) _
            .IsUnicode(False)

        modelBuilder.Entity(Of EMPLEADO)() _
            .Property(Function(e) e.Puesto) _
            .IsUnicode(False)

        modelBuilder.Entity(Of EMPLEADO)() _
            .HasMany(Function(e) e.LISTAEMPLEADO) _
            .WithOptional(Function(e) e.EMPLEADO) _
            .HasForeignKey(Function(e) e.Empnumerocedula)

        modelBuilder.Entity(Of GIMNASIO)() _
            .Property(Function(e) e.Snombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of GIMNASIO)() _
            .Property(Function(e) e.Gymnombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of GIMNASIO)() _
            .HasMany(Function(e) e.CLIENTE) _
            .WithRequired(Function(e) e.GIMNASIO) _
            .HasForeignKey(Function(e) e.Snombre) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of GIMNASIO)() _
            .HasOptional(Function(e) e.LISTACLASES) _
            .WithRequired(Function(e) e.GIMNASIO)

        modelBuilder.Entity(Of GIMNASIO)() _
            .HasMany(Function(e) e.LISTAINVENTARIO) _
            .WithRequired(Function(e) e.GIMNASIO) _
            .HasForeignKey(Function(e) e.Gymsnombre) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of GIMNASIO)() _
            .HasMany(Function(e) e.LISTAPRODUCTOS) _
            .WithRequired(Function(e) e.GIMNASIO) _
            .HasForeignKey(Function(e) e.Gymsnombre) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of GIMNASIO)() _
            .HasMany(Function(e) e.LISTATRATAMIENTOS) _
            .WithRequired(Function(e) e.GIMNASIO) _
            .HasForeignKey(Function(e) e.Gymsnombre) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of GIMNASIO)() _
            .HasMany(Function(e) e.SERVICIO) _
            .WithRequired(Function(e) e.GIMNASIO) _
            .HasForeignKey(Function(e) e.Snombre) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of INVENTARIO)() _
            .Property(Function(e) e.Numeroserie) _
            .IsUnicode(False)

        modelBuilder.Entity(Of INVENTARIO)() _
            .Property(Function(e) e.Tipodeequipo) _
            .IsUnicode(False)

        modelBuilder.Entity(Of INVENTARIO)() _
            .Property(Function(e) e.Marca) _
            .IsUnicode(False)

        modelBuilder.Entity(Of INVENTARIO)() _
            .HasMany(Function(e) e.LISTAINVENTARIO) _
            .WithRequired(Function(e) e.INVENTARIO) _
            .HasForeignKey(Function(e) e.Numerodeserie) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of INVENTARIO)() _
            .HasMany(Function(e) e.TIPOEQUIPO) _
            .WithRequired(Function(e) e.INVENTARIO) _
            .HasForeignKey(Function(e) e.Numerodeserie) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of PLANILLA)() _
            .Property(Function(e) e.ID) _
            .IsUnicode(False)

        modelBuilder.Entity(Of PLANILLA)() _
            .Property(Function(e) e.Descripcion) _
            .IsUnicode(False)

        modelBuilder.Entity(Of PLANILLA)() _
            .HasOptional(Function(e) e.LISTAEMPLEADO) _
            .WithRequired(Function(e) e.PLANILLA)

        modelBuilder.Entity(Of PLANILLA)() _
            .HasOptional(Function(e) e.PAGO) _
            .WithRequired(Function(e) e.PLANILLA)

        modelBuilder.Entity(Of PRODUCTO)() _
            .Property(Function(e) e.Codigodebarras) _
            .IsUnicode(False)

        modelBuilder.Entity(Of PRODUCTO)() _
            .Property(Function(e) e.Nombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of PRODUCTO)() _
            .Property(Function(e) e.Descripción) _
            .IsUnicode(False)

        modelBuilder.Entity(Of PRODUCTO)() _
            .HasMany(Function(e) e.LISTAPRODUCTOS) _
            .WithRequired(Function(e) e.PRODUCTO) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of SERVICIO)() _
            .Property(Function(e) e.Idservicio) _
            .IsUnicode(False)

        modelBuilder.Entity(Of SERVICIO)() _
            .Property(Function(e) e.Descripción) _
            .IsUnicode(False)

        modelBuilder.Entity(Of SERVICIO)() _
            .Property(Function(e) e.Snombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of SUCURSAL)() _
            .Property(Function(e) e.Nombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of SUCURSAL)() _
            .Property(Function(e) e.Administrador) _
            .IsUnicode(False)

        modelBuilder.Entity(Of SUCURSAL)() _
            .Property(Function(e) e.Canton) _
            .IsUnicode(False)

        modelBuilder.Entity(Of SUCURSAL)() _
            .Property(Function(e) e.Provincia) _
            .IsUnicode(False)

        modelBuilder.Entity(Of SUCURSAL)() _
            .Property(Function(e) e.Distrito) _
            .IsUnicode(False)

        modelBuilder.Entity(Of SUCURSAL)() _
            .HasMany(Function(e) e.GIMNASIO) _
            .WithRequired(Function(e) e.SUCURSAL) _
            .HasForeignKey(Function(e) e.Snombre) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of SUCURSAL)() _
            .HasOptional(Function(e) e.TELEFONO) _
            .WithRequired(Function(e) e.SUCURSAL)

        modelBuilder.Entity(Of TIPOEQUIPO)() _
            .Property(Function(e) e.Idequipo) _
            .IsUnicode(False)

        modelBuilder.Entity(Of TIPOEQUIPO)() _
            .Property(Function(e) e.Descripción) _
            .IsUnicode(False)

        modelBuilder.Entity(Of TIPOEQUIPO)() _
            .Property(Function(e) e.Numerodeserie) _
            .IsUnicode(False)

        modelBuilder.Entity(Of TRATAMIENTOSPA)() _
            .Property(Function(e) e.Idtratamiento) _
            .IsUnicode(False)

        modelBuilder.Entity(Of TRATAMIENTOSPA)() _
            .Property(Function(e) e.Nombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of TRATAMIENTOSPA)() _
            .HasMany(Function(e) e.LISTATRATAMIENTOS) _
            .WithRequired(Function(e) e.TRATAMIENTOSPA) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of LISTACLASES)() _
            .Property(Function(e) e.Gymsnombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTACLASES)() _
            .Property(Function(e) e.Listaclases1) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTACLASESEMANAL)() _
            .Property(Function(e) e.Idclasecalendario) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTACLASESEMANAL)() _
            .Property(Function(e) e.Listaclasesemanal1) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTAEMPLEADO)() _
            .Property(Function(e) e.Planillaid) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTAEMPLEADO)() _
            .Property(Function(e) e.Listaempleado1) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTAINVENTARIO)() _
            .Property(Function(e) e.Gymsnombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTAINVENTARIO)() _
            .Property(Function(e) e.Listainventario1) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTAINVENTARIO)() _
            .Property(Function(e) e.Numerodeserie) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTAPRODUCTOS)() _
            .Property(Function(e) e.Gymsnombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTAPRODUCTOS)() _
            .Property(Function(e) e.Listaproductos1) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTAPRODUCTOS)() _
            .Property(Function(e) e.Codigodebarras) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTATRATAMIENTOS)() _
            .Property(Function(e) e.Gymsnombre) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTATRATAMIENTOS)() _
            .Property(Function(e) e.Listatratamientos1) _
            .IsUnicode(False)

        modelBuilder.Entity(Of LISTATRATAMIENTOS)() _
            .Property(Function(e) e.Idtratamiento) _
            .IsUnicode(False)

        modelBuilder.Entity(Of PAGO)() _
            .Property(Function(e) e.Planillaid) _
            .IsUnicode(False)

        modelBuilder.Entity(Of TELEFONO)() _
            .Property(Function(e) e.Telefono1) _
            .IsUnicode(False)

        modelBuilder.Entity(Of TELEFONO)() _
            .Property(Function(e) e.Snombre) _
            .IsUnicode(False)
    End Sub
End Class
