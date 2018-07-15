import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';


@Injectable()
export class GuestService {
    constructor(private http: Http) { }

    getGuests() {
        return this.http.get('api/Guests')
            .map(res => res.json());
    }
}