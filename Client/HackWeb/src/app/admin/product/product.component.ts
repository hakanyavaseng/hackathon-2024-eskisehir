import { Component, OnInit } from '@angular/core';
import { HttpClientService } from '../../services/common/http-client.service';
import { Product } from '../../contracts/product';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit {
  constructor(private httpClientService: HttpClientService, private modalService: NgbModal, private formBuilder: FormBuilder) { 
    this.productAddForm = this.formBuilder.group({
      name: '',
      description: '',
      price: '',
      unitCarbonFootprint: '',
    });
  }

  productAddForm : FormGroup;
  products : Product[];

  ngOnInit(): void {
    this.getProducts();
  }

  onSubmit(productAddForm : any) {
    this.createProduct(this.productAddForm.value);
    this.modalService.dismissAll();
  }

  openModal(modal: any) {
    this.modalService.open(modal);
  }


  getProducts() {
    this.httpClientService.get<Product[]>({
      controller: "Products",      
    }).subscribe(data => {
      this.products = data;
    });
  }

  createProduct(product : Product) {
    this.httpClientService.post<Product>({
      controller: "Products",
    }, product).subscribe(data => {
      this.getProducts();
    });
  }





}
