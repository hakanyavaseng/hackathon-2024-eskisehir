import { Component, OnInit } from '@angular/core';
import { HttpClientService } from '../../services/common/http-client.service';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Production } from '../../contracts/production';
import { Product } from '../../contracts/product';
import { ProductionAdd } from '../../contracts/productionAdd';

@Component({
  selector: 'app-production',
  templateUrl: './production.component.html',
  styleUrls: ['./production.component.css']
})
export class ProductionComponent implements OnInit {
  productions: Production[];
  productionAddForm: FormGroup;
  products: Product[];

  constructor(
    private httpClientService: HttpClientService,
    private modalService: NgbModal,
    private formBuilder: FormBuilder
  ) {
    this.productionAddForm = this.formBuilder.group({
      productId : [''],
      quantity : [''],
    });
  }

  ngOnInit() {
    this.getProduction();
  }

  getProduction() {
    this.httpClientService.get<Production[]>({
      controller: "Productions"
    }).subscribe(data => {
      this.productions = data;
    });
  }

  async getProducts(modal) {
    this.httpClientService.get<Product[]>({
      controller: "Products"
    }).subscribe(data => {
      this.products = data;
      this.modalService.open(modal);

    });
    console.log(this.products);
  }

  openModal(modal) { 
    this.getProducts(modal);
  
  }

  onSubmit(productionAddForm) {
    this.createProduction(this.productionAddForm.value);
  }

  createProduction(productionDto: ProductionAdd) {
    this.httpClientService.post<ProductionAdd>({
      controller: "Productions",
    },productionDto).subscribe(() => {
      this.getProduction();
      this.modalService.dismissAll();
    });
  }

}