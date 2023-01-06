import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs';
import { Funcionario } from './funcionario';

@Injectable({
  providedIn: 'root'
})
export class FuncionarioService {
  private readonly url = 'https://localhost:7087/funcionarios'

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

  constructor(private httpClient: HttpClient) { }

  getFuncionario(id: Number): Observable<Funcionario>{
    return this.httpClient.get<Funcionario>(this.url+"/"+id).pipe(retry(2), catchError(this.handleError))
  }

  getFuncionarios(): Observable<Funcionario[]>{
    return this.httpClient.get<Funcionario[]>(this.url).pipe(retry(2), catchError(this.handleError))
  }

  postFuncionario(funcionario: Funcionario): Observable<Funcionario>{
    return this.httpClient.post<Funcionario>(this.url, JSON.stringify(funcionario), this.HttpOptions).pipe(retry(2), catchError(this.handleError))
  }

  putFuncionario(funcionario: Funcionario): Observable<Funcionario>{
    return this.httpClient.put<Funcionario>(this.url+"/"+funcionario.id, JSON.stringify(funcionario), this.HttpOptions).pipe(retry(2), catchError(this.handleError))
  }

  deleteFuncionario(funcionario: Funcionario): Observable<Funcionario>{
    return this.httpClient.delete<Funcionario>(this.url+"/"+funcionario.id).pipe(retry(2), catchError(this.handleError))
  }
  buscar(id: number): Observable<Funcionario>{
    return this.httpClient.get<Funcionario>(this.url+"/"+id).pipe(retry(2), catchError(this.handleError))
  }
}
