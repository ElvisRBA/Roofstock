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
				this.realProperties = response
			}, error => {
			console.log(error);
			});
	}

}
