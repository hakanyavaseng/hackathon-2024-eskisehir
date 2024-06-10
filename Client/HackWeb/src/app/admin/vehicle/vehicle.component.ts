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

    this.vehicleEditForm = this.formBuilder.group({
      id: '',
      vehicleName: '',
      vehicleType: '',
      vehicleModel: '',
      unitCarbonFootprint: ''
    });
  }

  vehicleAddForm : FormGroup;
  vehicleEditForm : FormGroup;
  vehicles : Vehicle[];

  ngOnInit() {
    this.getVehicles();    
  }

  getVehicles() {
    this.httpClientService.get<Vehicle[]>({
      controller: "Vehicles"
    }).subscribe(data => {
      console.log(data);
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

  openEditModal(modal: any, vehicle: Vehicle) {
    this.vehicleEditForm.patchValue(vehicle);
    this.modalService.open(modal);
  }

  onSubmit(vehicleAddForm) {
    this.createVehicle(vehicleAddForm);
    this.modalService.dismissAll();
  }

  onSubmitEdit(vehicleEditForm) {
    console.log(vehicleEditForm);
    this.updateVehicle(vehicleEditForm);
    this.modalService.dismissAll();
  }

  deleteVehicle(vehicleId : string) {
    this.httpClientService.delete({
      controller: "Vehicles"
    }, vehicleId).subscribe(data => {
      this.getVehicles();
    });
  }

  updateVehicle(vehicle : any) {
    console.log(vehicle);
    this.httpClientService.put<Vehicle>({
      controller: "Vehicles"
    },vehicle).subscribe(data => {
      this.getVehicles();
    });
  }
  
  


}
