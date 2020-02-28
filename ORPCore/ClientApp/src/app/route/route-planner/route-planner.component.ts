import { Component } from '@angular/core';
//import { RouteService } from '../Route.Service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'route-planner-component',
  templateUrl: 'route-planner.component.html',
  styleUrls: ['route-planner.component.css']
})
export class RoutePlannerComponent {

    public destinations: Array<string>;
    public destination: string;
    public weight: string;
    public height: string;
    public depth: string;
    public width: string;

    public ngOnInit() {

        this.weight ="";
        this.height ="";
        this.width ="";
        this.depth ="";
        this.destinations = new Array<string>();
        this.destinations.push("Whale City","Congo","Africa");

    }

 //private userService: UserService;

//  public constructor(private routeService: RouteService) {
    
//  }
}