import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs';

import { IVideoCard } from '../interfaces/video-card';
import { MessageService } from './message.service';
import { baseApiUrl } from '../../constants';

@Injectable({
  providedIn: 'root'
})
export class VideoCardService {

  private videoCardUrl = baseApiUrl + '/VideoCards';

  httpOptions = {
    headers: new HttpHeaders({ 'Contnent-Type': 'application/json' })
  }

  constructor(
    private http: HttpClient,
    private messageService: MessageService,
  ) { }

  getVideoCards(): Observable<IVideoCard[]> {
    return this.http.get<IVideoCard[]>(this.videoCardUrl)
      .pipe(
        tap(_ => this.log('fetched video cards')),
        catchError(this.handleError<IVideoCard[]>('getVideoCards', [])));
  }

  getVideoCard(id: number): Observable<IVideoCard>  {
    const url = `${this.videoCardUrl}/${id}`;
    return this.http.get<IVideoCard>(url)
    .pipe(
      tap(_ => this.log(`fetched video card id=${id}`)),
      catchError(this.handleError<IVideoCard>(`getVideoCard id=${id}`))
    )
  }

  addVideoCard(videoCard: IVideoCard): Observable<IVideoCard>  {
    return this.http.post<IVideoCard>(this.videoCardUrl, videoCard, this.httpOptions)
      .pipe(
        tap((newVideoCard: IVideoCard) => this.log(`added video card with id=${newVideoCard.videoCardId}`)),
        catchError(this.handleError<IVideoCard>('addVideoCard'))
      )
  }

  updateVideoCard(videoCard: IVideoCard): Observable<any> {
    const url = `${this.videoCardUrl}/${videoCard.videoCardId}`;
    return this.http.put(url, videoCard, this.httpOptions)
      .pipe(
        tap(_ => this.log(`updated video card id=${videoCard.videoCardId}`)),
        catchError(this.handleError<any>('updateVideoCard'))
      );
  }

  deleteVideoCard(id: number): Observable<IVideoCard> {
    const url = `${this.videoCardUrl}/${id}`;
    return this.http.delete<IVideoCard>(url, this.httpOptions)
      .pipe(
        tap(_ => this.log(`deleted video card id=${id}`)),
        catchError(this.handleError<IVideoCard>('deleteVideoCard'))
      );
  }

  private log(message: string) {
    this.messageService.log(`VideoCardService: ${message}`);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      this.messageService.add(error.error.message);
      console.error(error);
      this.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    }
  }
}
