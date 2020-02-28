import { Component } from '@angular/core';
//import { RouteService } from '../Route.Service';
import { HttpClient } from '@angular/common/http';
import { UserService } from 'src/app/user/User.Service';
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
  public weight: string;
  public height: string;
  public depth: string;
  public width: string;

  public ngOnInit() {
    this.parcel = new Parcel
    this.weight = "";
    this.height = "";
    this.width = "";
    this.depth = "";
    this.destinations = new Array<string>();
    this.destinations.push("Whale City", "Congo", "Africa");

  }
}
