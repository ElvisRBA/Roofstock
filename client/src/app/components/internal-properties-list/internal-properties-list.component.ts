import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { IRealProperty } from 'src/app/models/realProperty';
import { RoofstockService } from 'src/app/Services/roofstock.service';

@Component({
  selector: 'app-internal-properties-list',
  templateUrl: './internal-properties-list.component.html',
  styleUrls: ['./internal-properties-list.component.scss']
})
export class InternalPropertiesListComponent implements OnInit {

	realProperties: IRealProperty[];

  	constructor(private roofstockService: RoofstockService, private toastr: ToastrService) { }

	ngOnInit(): void {
		// this service is called to retrieve the properties from the database and shape the data for its presentation.
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
				this.toastr.success(error, 'Error retrieving data');
			});
	}

}
