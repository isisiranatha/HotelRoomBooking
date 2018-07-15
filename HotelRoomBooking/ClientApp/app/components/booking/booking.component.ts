import { Component } from '@angular/core';

@Component({
    selector: 'booking',
    templateUrl: './booking.component.html'
})
export class BookingComponent {
    public currentCount = 0;

    public incrementCounter() {
        this.currentCount++;
    }
}