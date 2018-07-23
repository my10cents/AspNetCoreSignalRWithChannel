import { Component } from '@angular/core';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  private hubConnection: HubConnection;

  user = 'default';
  progress = 0;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

  constructor(private http: HttpClient) {

  }

  openConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44374/updater?channel=' + this.user)//
    .configureLogging(signalR.LogLevel.Information)
    .build();

    this.hubConnection.start()
      .catch(err => {
         console.error(err.toString());
      });

     this.hubConnection.on('updateProgressBar', (perc) => {
      this.progress = perc;
    });
  }

  dropConnection() {
    this.hubConnection
        .stop()
        .catch(err => {
          console.error('err drop connection: ', err.toString());
        });
  }
  startRemoteProcess() {
    const url = 'https://localhost:44374/update?channel=' + this.user;
    this.http.get(url, {}).subscribe(
      res => { console.log('res: ', res ); },
      err => { console.log('err: ', err ); }
    );
  }
}
