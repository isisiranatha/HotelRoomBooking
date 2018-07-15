import { Component, OnInit } from '@angular/core';
import { RoomTypeService } from "../../Services/roomtype.service";

@Component({
    selector: 'roomtype',
    templateUrl: './roomtype.component.html'
})

export class RoomTypeComponent implements OnInit {
    roomtypes;
    constructor(private RoomTypeService: RoomTypeService) { }

    ngOnInit() {
        this.RoomTypeService.getRoomTypes().subscribe(roomtypes => {
            this.roomtypes = roomtypes;
            console.log("RoomTypes", this.roomtypes);
        });
    }
}