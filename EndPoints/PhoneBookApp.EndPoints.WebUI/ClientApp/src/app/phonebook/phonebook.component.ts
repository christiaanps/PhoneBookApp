import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-phonebook',
  templateUrl: './phonebook.component.html'
})
export class PhoneBookComponent {
  public phoneBookEntries: PhoneBookEntryViewModel[];
  public txtSearch: string = "";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
    let params = new HttpParams().set("searchString", this.txtSearch)
    http.get<PhoneBookEntryViewModel[]>(baseUrl + 'phonebook', { params: params }).subscribe(result => {
      this.phoneBookEntries = result;
    }, error => console.error(error));
  }

  public addEntry() {
    this.router.navigateByUrl('/phonebook-entry');
  }

  public search() {
    let params = new HttpParams().set("searchString", this.txtSearch)
    this.http.get<PhoneBookEntryViewModel[]>(this.baseUrl + 'phonebook', { params: params }).subscribe(result => {
      this.phoneBookEntries = result;
    }, error => console.error(error));
  }
}

interface PhoneBookEntryViewModel {
  phoneBookName: string;
  entryName: string;
  phoneNumber: string;
}
