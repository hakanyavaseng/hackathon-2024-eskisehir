import { Component } from '@angular/core';
import { HttpClientService } from '../../services/common/http-client.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Vehicle } from '../../contracts/vehicle';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrl: './vehicle.component.css'
})
export class VehicleComponent {

  constructor(private httpClientService: HttpClientService, private modalService: NgbModal, private formBuilder: FormBuilder) { 
    this.vehicleAddForm = this.formBuilder.group({
      vehicleName: '',
      vehicleType: '',
      vehicleModel: '',
      unitCarbonFootprint: ''
    });
  }

  vehicleAddForm : FormGroup;
  vehicles : Vehicle[];

  ngOnInit() {
    this.getVehicles();    
  }

  getVehicles() {
    this.httpClientService.get<Vehicle[]>({
      controller: "Vehicles"
    }).subscribe(data => {
      this.vehicles = data;
    });
  }

  createVehicle(vehicle : any) {
    console.log(vehicle);
    this.httpClientService.post<Vehicle>({
      controller: "Vehicles"
    },vehicle).subscribe(data => {
      this.getVehicles();
    });
  }

  openModal(modal: any) {
    this.modalService.open(modal);
  }

  onSubmit(vehicleAddForm) {
    this.createVehicle(vehicleAddForm);
    this.modalService.dismissAll();
  }
  
  


}
