import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { Funcionario } from '../funcionario/funcionario';
import { Cliente } from './cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private readonly url = 'https://localhost:7087/clientes'

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

  getClientes(): Observable<Cliente[]>{
    return this.http.get<Cliente[]>(this.url).pipe(retry(2), catchError(this.handleError))
  }
  postCliente(cliente: Cliente): Observable<Cliente>{
    return this.http.post<Cliente>(this.url, cliente, this.HttpOptions).pipe(retry(2), catchError(this.handleError))
  }
  putCliente(cliente: Cliente): Observable<Cliente>{
    return this.http.put<Cliente>(this.url+"/"+cliente.id, cliente, this.HttpOptions).pipe(retry(2), catchError(this.handleError))
  }
  deleteCliente(cliente: Cliente): Observable<Cliente>{
    return this.http.delete<Cliente>(this.url+"/"+cliente.id).pipe(retry(2), catchError(this.handleError))
  }
  buscar(id: number): Observable<Cliente>{
    return this.http.get<Funcionario>(this.url+"/"+id).pipe(retry(2), catchError(this.handleError))
  }
}