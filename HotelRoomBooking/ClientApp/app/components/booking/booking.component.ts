import { Component, OnInit } from '@angular/core';
import { BookingService } from "../../Services/booking.service";

@Component({
    selector: 'booking',
    templateUrl: './booking.component.html'
})
    
export class BookingComponent implements OnInit {
    bookings;
    constructor(private BookingService: BookingService) { }

    ngOnInit() {
        this.BookingService.getBookings().subscribe(bookings => {
            this.bookings = bookings;
            console.log("Bookings", this.bookings);
        });
        }
        
}