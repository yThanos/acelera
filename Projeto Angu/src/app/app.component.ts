import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {  
  title = 'projeto';

  role = 'user';
  constructor(private jwtHelper: JwtHelperService){}

  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("jwt");
  if (token && !this.jwtHelper.isTokenExpired(token)){
    const jwt = this.jwtHelper.decodeToken(token)
    
    return true;
  }
  return false;
  }
  logOut = () => {
    localStorage.removeItem("jwt");
  }

  hasVendas(){
    const token = localStorage.getItem("jwt");
    if(token){
      const jwt = this.jwtHelper.decodeToken(token)
      if(jwt.role == "Admin" || jwt.role == "Vendas"){
        return true;
      }
    }
    return false;
  }
  hasProdutos(){
    const token = localStorage.getItem("jwt");
    if(token){
      const jwt = this.jwtHelper.decodeToken(token)
      if(jwt.role == "Admin" || jwt.role == "Estoque"){
        return true;
      }
    }
    return false;
  }
  hasFuncionarios(){
    const token = localStorage.getItem("jwt");
    if(token){
      const jwt = this.jwtHelper.decodeToken(token)
      if(jwt.role == "Admin" || jwt.role == "RH"){
        return true;
      }
    }
    return false;
  }
  hasClientes(){
    return this.isUserAuthenticated();
  }
}