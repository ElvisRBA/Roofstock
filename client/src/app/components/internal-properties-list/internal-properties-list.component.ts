import { Component, OnInit } from '@angular/core';
import { IRealProperty } from 'src/app/models/realProperty';
import { RoofstockService } from 'src/app/Services/roofstock.service';

@Component({
  selector: 'app-internal-properties-list',
  templateUrl: './internal-properties-list.component.html',
  styleUrls: ['./internal-properties-list.component.scss']
})
export class InternalPropertiesListComponent implements OnInit {

	realProperties: IRealProperty[];

  	constructor(private roofstockService: RoofstockService) { }

	ngOnInit(): void {
		this.roofstockService.getInternalProperties().subscribe((response) => {
				this.realProperties = response.map(property => (
					{ 
						address: property.address,
						yearBuilt: property.yearBuilt,
						listPrice: property.listPrice,
						monthlyRent: property.monthlyRent,
						grossYield: (property.monthlyRent * 12 / property.listPrice) ? (property.monthlyRent * 12 / property.listPrice) : 0,
					}));
			}, error => {
			console.log(error);
			});
	}

}
