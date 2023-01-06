import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { Cliente } from '../cliente/cliente';
import { Produto } from '../produto/produto';
import { Venda } from './venda';

@Injectable({
  providedIn: 'root'
})
export class VendaService {
  private readonly url = 'https://localhost:7087/vendas'
  private readonly urlProd = 'https://localhost:7087/produtos'
  private readonly urlCli = 'https://localhost:7087/clientes'

  handleError(error: HttpErrorResponse){
    let errorMessage = '';
    if(error.error instanceof ErrorEvent){
      errorMessage = error.error.message;
    }else{
      errorMessage = 'Código do erro ${error.status},' + 'mensagem ${error.message}';
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }

  HttpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  constructor(private http: HttpClient) { }

  getVendas(): Observable<Venda[]>{
    return this.http.get<Venda[]>(this.url).pipe(retry(2), catchError(this.handleError))
  }
  postVendas(venda: Venda): Observable<Venda>{
    return this.http.post<Venda>(this.url, JSON.stringify(venda), this.HttpOptions).pipe(retry(2), catchError(this.handleError))
  }
  getProdutos(): Observable<Produto[]>{
    return this.http.get<Produto[]>(this.urlProd).pipe(retry(2), catchError(this.handleError))
  }
  getClientes(): Observable<Cliente[]>{
    return this.http.get<Cliente[]>(this.urlCli).pipe(retry(2), catchError(this.handleError))
  }
  getCli(id?: Number): Observable<Cliente>{
    console.log(id)
    return this.http.get<Cliente>(this.urlCli+"/"+id).pipe(retry(2), catchError(this.handleError))
  }
  getPro(id?: Number): Observable<Produto>{
    console.log(id)
    return this.http.get<Produto>(this.urlProd+"/"+id).pipe(retry(2), catchError(this.handleError))
  }
}