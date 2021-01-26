import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { IRealProperty } from 'src/app/models/realProperty';
import { RoofstockService } from 'src/app/Services/roofstock.service';

@Component({
  selector: 'app-external-properties-list',
  templateUrl: './external-properties-list.component.html',
  styleUrls: ['./external-properties-list.component.scss']
})
export class ExternalPropertiesListComponent implements OnInit {

  	realProperties: IRealProperty[];

  	constructor(private roofstockService: RoofstockService, private toastr: ToastrService) { }

	ngOnInit(): void {
		this.roofstockService.getExternalProperties().subscribe((response) => {
			this.realProperties = response['properties'].map(property => (
				{ 
					address: property['address']['address1'],
					yearBuilt: property['physical'] ? property['physical']['yearBuilt'] : 0,
					listPrice: property['financial'] ? parseFloat(property['financial']['listPrice']) : 0,
					monthlyRent: property['financial'] ? parseFloat(property['financial']['monthlyRent']) : 0,
					grossYield: ((property['financial'] ? parseFloat(property['financial']['monthlyRent']) : 0) * 12 / (property['financial'] ? parseFloat(property['financial']['listPrice']) : 0)) ? 
					((property['financial'] ? parseFloat(property['financial']['monthlyRent']) : 0) * 12 / (property['financial'] ? parseFloat(property['financial']['listPrice']) : 0)) : 0,
				}));
			}, error => {
			console.log(error);
			});
	}

	AddExternalToInteral(realproperty: IRealProperty) {
		this.roofstockService.addInternalProperty(realproperty).subscribe((response) => {
			this.toastr.success('New Property inserted on internal data','Property Created');
		}
		);
	}

}
