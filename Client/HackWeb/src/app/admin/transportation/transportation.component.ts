import { Component, OnInit } from '@angular/core';
import { HttpClientService } from '../../services/common/http-client.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Transportation } from '../../contracts/transportation';
import { Vehicle } from '../../contracts/vehicle';

@Component({
  selector: 'app-transportation',
  templateUrl: './transportation.component.html',
  styleUrls: ['./transportation.component.css']
})
export class TransportationComponent implements OnInit {
  transportationAddForm: FormGroup;
  transportationEditForm: FormGroup;
  transportations: Transportation[];
  vehicles: Vehicle[];

  constructor(
    private httpClientService: HttpClientService, 
    private modalService: NgbModal, 
    private formBuilder: FormBuilder
  ) { 
    this.transportationAddForm = this.formBuilder.group({
      transportationDateTime: '',
      distance: '',
      vehicleId: '',
      totalCarbonFootprint: ''
    });

    this.transportationEditForm = this.formBuilder.group({
      id: '',
      transportationDateTime: '',
      distance: '',
      vehicleId: '',
      totalCarbonFootprint: ''
    });
  }

  ngOnInit() {
    this.getTransportations();
  }

  getTransportations() {
    this.httpClientService.get<Transportation[]>({
      controller: "Transportations"
    }).subscribe(data => {
      console.log(data);
      this.transportations = data;
    });
  }

  getVehicles() {
    this.httpClientService.get<Vehicle[]>({
      controller: "Vehicles"
    }).subscribe(data => {
      console.log(data);
      this.vehicles = data;
    });
  }

  createTransportation(transportation: any) {
    debugger;
    this.httpClientService.post<Transportation>({
      controller: "Transportations"
    }, transportation).subscribe(data => {
      this.getTransportations();
    });
  }

  editTransportation(transportation: Transportation) {
    this.httpClientService.put<Transportation>({
      controller: "Transportations",
    }, transportation).subscribe(data => {
      this.getTransportations();
    });
  }

  deleteTransportation(transportation: Transportation) {
    this.httpClientService.delete({
      controller: "Transportations"
    }, transportation.id).subscribe(data => {
      this.getTransportations();
    });
  }



  openModal(modal: any) {
    this.getVehicles();
    this.modalService.open(modal);
  }

  openEditModal(modal: any, transportation: Transportation) {
    this.getVehicles();
    this.transportationEditForm.patchValue(transportation);
    this.modalService.open(modal);
  }

  calculateTotalCarbonFootprintAddition() {
    const distance = this.transportationAddForm.get('distance').value;
    const vehicleId = this.transportationAddForm.get('vehicleId').value;
    const vehicle = this.vehicles.find(v => v.id === vehicleId);

    if (vehicle && distance) {
      const totalCarbonFootprint = distance * vehicle.unitCarbonFootprint;
      this.transportationAddForm.get('totalCarbonFootprint').setValue(totalCarbonFootprint);
    } else {
      this.transportationAddForm.get('totalCarbonFootprint').setValue('');
    }
  }

  calculateTotalCarbonFootprintEdit() {
    const distance = this.transportationEditForm.get('distance').value;
    const vehicleId = this.transportationEditForm.get('vehicleId').value;
    const vehicle = this.vehicles.find(v => v.id === vehicleId);

    if (vehicle && distance) {
      const totalCarbonFootprint = distance * vehicle.unitCarbonFootprint;
      this.transportationEditForm.get('totalCarbonFootprint').setValue(totalCarbonFootprint);
    } else {
      this.transportationEditForm.get('totalCarbonFootprint').setValue('');
    }
  }

  onSubmit() {
    const formValues = this.transportationAddForm.value;
    this.createTransportation(formValues);
    this.modalService.dismissAll();
  }

  onEditSubmit() {
    const formValues = this.transportationEditForm.value;
    this.editTransportation(formValues);
    this.modalService.dismissAll();
  }

  getVehicleName(vehicleId: string): string {
    const vehicle = this.vehicles.find(v => v.id === vehicleId);
    return vehicle ? vehicle.vehicleName : 'Unknown';
  }
}