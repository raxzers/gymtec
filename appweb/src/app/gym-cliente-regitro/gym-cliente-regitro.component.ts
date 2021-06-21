import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'; 
import {NgForm} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
@Component({
  selector: 'app-gym-cliente-regitro',
  templateUrl: './gym-cliente-regitro.component.html',
  styleUrls: ['./gym-cliente-regitro.component.css']
})
export class GymClienteRegitroComponent implements OnInit {
  t2: Object = [];
  
  constructor(private route:Router,private http:HttpClient) { }

  ngOnInit(): void {
  }

  


go(f: NgForm){
  console.log(f.value);
  var  ts=false;
  if (ts){this.route.navigate(['/dashboard']);}
       else
   {
     alert("usuario y/o contraseña equivocado, Por favor intentar de nuevo")
     
  }
  }
}
