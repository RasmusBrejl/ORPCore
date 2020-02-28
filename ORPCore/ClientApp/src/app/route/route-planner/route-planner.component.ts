import { Component } from '@angular/core';
//import { RouteService } from '../Route.Service';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../../user/User.Service';
import { Parcel } from './parcel';

@Component({
  selector: 'route-planner-component',
  templateUrl: 'route-planner.component.html',
  styleUrls: ['route-planner.component.css']
})
export class RoutePlannerComponent {

  public constructor (private userService: UserService) {

  }
  public parcel: Parcel
  public destinations: Array<string>;
  public destination: string;
  public endDestination: string;
  public weight: string;
  public height: string;
  public depth: string;
  public width: string;

  public types: { id: number, name: string, checked: boolean }[] = [
    { "id": 0, "name": "Weapon", checked: false },
    { "id": 1, "name": "Fragile", checked: false },
    { "id": 2, "name": "Cold", checked: false}
];
  public negativeWeight: boolean;

  public ngOnInit() {

    this.parcel = new Parcel();

    this.parcel.weight = "";
    this.parcel.height = "";
    this.parcel.depth = "";
    this.parcel.width = "";

    this.weight = "";
    this.height = "";
    this.width = "";
    this.depth = "";
    
    this.destinations = new Array<string>();
    this.destinations.push("Whale City", "Congo", "Africa");

    this.destination = this.destinations[0];
    this.endDestination = this.destinations[0];

  }

  public onChangeStart(event) {
    this.destination = event;
    }
    
    public onChangeEnd(event) {
    this.endDestination = event;
    }

    public calculate() {
        var route = this.userService.calculate(this.parcel,this.destination,this.endDestination).then(res => console.log(res));
    }

    public isChangeLimitAccessToggle(type) {
        type.checked = !type.checked;
        console.log(this.types);
    }

}
