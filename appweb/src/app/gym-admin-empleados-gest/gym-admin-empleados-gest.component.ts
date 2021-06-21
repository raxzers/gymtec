import { Component, OnInit } from '@angular/core';
interface Empleado {
  puesto:String;
  tipo_de_pago: String;
  instructor:String;
  sucursal:String;
  cedula:number;
  correo:String;
  salario:Number;
  dirccion:String;
  passw:String;
}
interface gym{
  nombre:String;
}
@Component({
  selector: 'app-gym-admin-empleados-gest',
  templateUrl: './gym-admin-empleados-gest.component.html',
  styleUrls: ['./gym-admin-empleados-gest.component.css']
})
export class GymAdminEmpleadosGestComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  Empleados:Empleado[]=[
    {puesto:"Administrado",
      tipo_de_pago: "Mensual",
      instructor:"Kurt  Araya",
      sucursal:"san carlos",
      cedula:123456789,
      correo:"String@k.com",
      salario:100,
      dirccion:"String",
      passw:"String",
    },
    {puesto:"Instructor",
      tipo_de_pago: "Por clase",
      instructor:"Tatiana  Morales",
      sucursal:"Cartago",
      cedula:234567890,
      correo:"String",
      salario:100,
      dirccion:"String",
      passw:"String",
     },
    {puesto:"Dependiente de tienda",
      tipo_de_pago: "Por horas",
      instructor:"Miguel  López",
      sucursal:"Limon",
      cedula:123456789,
      correo:"String",
      salario:100,
      dirccion:"String",
      passw:"String",
    },
    {puesto:"Dependiente de SPA",
      tipo_de_pago: "Mensual",
      instructor:"Scarlett Díaz",
      sucursal:"San Jose",
      cedula:234567890,
      correo:"String",
      salario:100,
      dirccion:"String",
      passw:"String",
    },
  ]
  lista:gym[]=[
    {nombre:"cartago"},
    {nombre:"san jose"},
    {nombre:"limon"},
    {nombre:"san carlos"},

];

}
