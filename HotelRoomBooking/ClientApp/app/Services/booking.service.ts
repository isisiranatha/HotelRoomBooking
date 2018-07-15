import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';


@Injectable()
export class BookingService {
    constructor(private http: Http) { }

    getBookings() {
        return this.http.get('api/Bookings')
            .map(res => res.json());
    }
}