import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

import { User } from './user';
import { Parcel } from '../route/route-planner/parcel';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  endpoint: string = 'https://wa-oapl.azurewebsites.net/user/getuser/';

  constructor(private http: HttpClient, ) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
  }

  private extractData(res: Response) {
    let body = res;
    return body || {};
  }

  tryLogIn(user: User): Promise<any> {
    console.log(user)

    return this.http.get(this.endpoint + '?username=' + user.name + '&password=' + user.password).toPromise()
      .catch(res => console.log(res))
  }

  getCities(): Promise<any> {
    
    return this.http.get('https://wa-oapl.azurewebsites.net/city/getallcities').toPromise()
      .catch(res => console.log(res))
  }

  calculate(parcel: Parcel, start: string, end: string): Promise<any> {
    parcel.type[0] = 1;
     return this.http.post('https://wa-oapl.azurewebsites.net/requestroute/calculateroute?city1='+start+'&city2='+end, parcel).toPromise()
      .catch(res => console.log(res))
  }

}
