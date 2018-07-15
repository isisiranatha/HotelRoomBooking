import { Component, OnInit } from '@angular/core';
import { GuestService } from "../../Services/guest.service";

@Component({
    selector: 'guest',
    templateUrl: './guest.component.html'
})

export class GuestComponent implements OnInit {
    guests;
    constructor(private GuestService: GuestService) { }

    ngOnInit() {
        this.GuestService.getGuests().subscribe(guests => {
            this.guests = guests;
            console.log("Guests", this.guests);
        });
    }
}