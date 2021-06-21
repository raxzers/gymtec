import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'; 
import {NgForm} from '@angular/forms';
@Component({
  selector: 'app-gym-cliente-login',
  templateUrl: './gym-cliente-login.component.html',
  styleUrls: ['./gym-cliente-login.component.css']
})
export class GymClienteLoginComponent implements OnInit {

  constructor(private route:Router) { }

  ngOnInit(): void {
  }
  go(f: NgForm){
    console.log(f.value);
    
    var  ts=false;
    if (ts){this.route.navigate(['/dashboard']);}
		 else{alert("usuario y/o contraseña equivocado, Por favor intentar de nuevo")}
	}
}
