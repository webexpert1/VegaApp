import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  items: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getWeathers();
  }

  getWeathers() {
    this.http.get("https://localhost:44336/api/weatherforecast")
              .subscribe(response => {
                this.items = response;
                console.log(response)
              }, error => {
                console.log(error);
              })
  }
}
