import { Component } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  nome = '';

  constructor(private jwthelper: JwtHelperService){
    this.hello();
  }

  hello(){
    const rawjwt = localStorage.getItem("jwt");
    if(rawjwt){
      const token = this.jwthelper.decodeToken(rawjwt);
      this.nome = token.nome;
      console.log(token.nome+"--"+token.role)
    }
  }

}
