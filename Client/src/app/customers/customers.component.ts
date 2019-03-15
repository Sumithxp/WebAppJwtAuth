import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: []
})

export class CustomersComponent implements OnInit {

  customers: any = [];

  constructor(private http: HttpClient) {
  }


  ngOnInit(): void {
    const token = localStorage.getItem('access_token');
    this.http.get('http://localhost:4350/api/customers', {
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token
      })
    }).subscribe(response => {
      this.customers = response;
    }, err => {

    });
  }
}
