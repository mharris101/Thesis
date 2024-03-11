import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  message: string = "";

  log(message: string) {
    console.log(message);
  }

  add(message: string) {
    this.message = message;
  }

  clear() {
    this.message = "";
  }
}
