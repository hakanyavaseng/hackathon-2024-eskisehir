import { Component } from '@angular/core';
import { HttpClientService } from '../../services/common/http-client.service';
import { FormBuilder } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Production } from '../../contracts/production';

@Component({
  selector: 'app-production',
  templateUrl: './production.component.html',
  styleUrl: './production.component.css'
})
export class ProductionComponent {
  constructor(private httpClientService: HttpClientService, private modalService: NgbModal, private formBuilder: FormBuilder) { }

  productions: Production[];
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

}
