import { Component } from '@angular/core';
import { Order } from '../order';
//import { OrderService } from '../Order.Service';


@Component({
  selector: 'order-overview-component',
  templateUrl: 'order-overview.component.html',
  styleUrls: ['order-overview.component.css']
})
export class OrderOverviewComponent {
  
  // public constructor (private orderService: OrderService) {

  // }
  public orders: Array<Order> = [
    {person : "Brian", orderId : 1, percelDetail : "abc", route : "abc", price : 500},
    {person : "Pervy", orderId : 2, percelDetail : "abc", route : "abc", price : 500},
  ];

  public ngOnInit() {
      // Populate order array
  }

  public initOverview(){
    // Populate table
  }
}
