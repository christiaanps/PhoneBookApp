import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map, tap, take } from 'rxjs/operators';

@Component({
  selector: 'app-phonebook',
  templateUrl: './phonebook-entry.component.html'
})
export class PhoneBookEntryComponent {

  public userName: Observable<string>;
  public name: string;
  public phoneNumber: string;

  constructor(private authorizeService: AuthorizeService, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
  }

  ngOnInit() {
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
  }

  public addEntry() {
    this.userName.pipe(take(1)).subscribe(event => {
      var entry = new PhoneBookEntryViewModel();
      entry.phoneBookName = event;
      entry.entryName = this.name;
      entry.phoneNumber = this.phoneNumber;

      this.http.post(this.baseUrl + 'phonebook', entry).subscribe(r => {
        alert('ok');
        this.router.navigateByUrl('/phonebook');
      }, error => {
        alert('error');
        console.error(error);
      });
    });
  }

  public close() {
    this.router.navigateByUrl('/phonebook');
  }
}

class PhoneBookEntryViewModel {
  phoneBookName: string;
  entryName: string;
  phoneNumber: string;
}
