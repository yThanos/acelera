import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { Produto } from './produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {
  private readonly url = 'https://localhost:7087/produtos'

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

  getProdutos(): Observable<Produto[]>{
    return this.http.get<Produto[]>(this.url).pipe(retry(2), catchError(this.handleError))
  }
  postProduto(produto: Produto): Observable<Produto>{
    return this.http.post<Produto>(this.url, produto, this.HttpOptions).pipe(retry(2), catchError(this.handleError))
  }
  putProduto(produto: Produto): Observable<Produto>{
    return this.http.put<Produto>(this.url+"/"+produto.id, produto, this.HttpOptions).pipe(retry(2), catchError(this.handleError))
  }
  deleteProduto(produto: Produto): Observable<Produto>{
    return this.http.delete<Produto>(this.url+"/"+produto.id).pipe(retry(2), catchError(this.handleError))
  }
  buscar(id: number): Observable<Produto>{
    return this.http.get<Produto>(this.url+"/"+id).pipe(retry(2), catchError(this.handleError))
  }
}
