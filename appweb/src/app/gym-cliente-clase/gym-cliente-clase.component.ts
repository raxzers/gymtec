import { Component, OnInit } from '@angular/core';

interface Clase {
  cupos_Disponibles: Number;
  tipo_de_clase: String;
  fecha_Inicio: String;
  fecha_Fin: String;
  instructor:String;
}
interface gym{
  nombre:String;
}
@Component({
  selector: 'app-gym-cliente-clase',
  templateUrl: './gym-cliente-clase.component.html',
  styleUrls: ['./gym-cliente-clase.component.css']
})
export class GymClienteClaseComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  clases:Clase[]=[
    {cupos_Disponibles:5,
      tipo_de_clase:'zumba',
      fecha_Inicio:'16/jun/2021',
      fecha_Fin:'25/jul/2021',
      instructor:'francisco zumbado',},
      {cupos_Disponibles:10,
        tipo_de_clase:'yoga',
        fecha_Inicio:'17/jun/2021',
        fecha_Fin:'30/jul/2021',
        instructor:'julieta mendieta',},
  ]
  lista:gym[]=[
    {nombre:"cartago"},
    {nombre:"san jose"},
    {nombre:"limon"},
    {nombre:"san carlos"},

];
}//https://www.itsolutionstuff.com/post/angular-10-display-json-data-in-table-exampleexample.html
//https://getbootstrap.com/docs/4.0/components/dropdowns/
