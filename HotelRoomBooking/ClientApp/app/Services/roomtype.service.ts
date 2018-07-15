import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';


@Injectable()
export class RoomTypeService {
    constructor(private http: Http) { }

    getRoomTypes() {
        return this.http.get('api/RoomTypes')
            .map(res => res.json());
    }
}