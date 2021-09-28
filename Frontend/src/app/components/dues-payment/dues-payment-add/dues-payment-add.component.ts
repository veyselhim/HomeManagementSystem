import { AuthService } from './../../../services/auth/auth.service';
import { CardDocument } from './../../../models/cardDocument/cardDocument';
import { CardDocumentService } from './../../../services/cardDocument/card-document.service';
import { ActivatedRoute } from '@angular/router';
import { Dues } from 'src/app/models/dues/dues';
import { DuesService } from './../../../services/dues/dues.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DuesPayment } from './../../../models/duesPayment/duesPayment';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { DuesPaymentService } from './../../../services/duesPayment/dues-payment.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dues-payment-add',
  templateUrl: './dues-payment-add.component.html',
  styleUrls: ['./dues-payment-add.component.css'],
})
export class DuesPaymentAddComponent implements OnInit {
  duesPayment!: DuesPayment;
  duesPaymentAddForm!: FormGroup;

  date = new Date().toJSON("yyyy/MM/dd HH:mm");
  id! : number;
  cardDocuments: CardDocument[] = [];
  dueses: Dues[] = [];
  constructor(
    private duesPaymentService: DuesPaymentService,
    private toastrService: ToastrService,
    private formBuilder: FormBuilder,
    private duesService: DuesService,
    private authService:AuthService,
    private activatedRoute:ActivatedRoute,
    private cardDocumentService:CardDocumentService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["id"]){
        this.id = params["id"]
        this.getDueses();
        this.getCardDocumentsByUser(this.id);
        this.createDuesPaymentForm();
      }
    })
 
  }

  createDuesPaymentForm() {
    this.duesPaymentAddForm = this.formBuilder.group({
      duesId: [this.id],
      cardDocumentId: ['', Validators.required],
      payedDate: [this.date],
      status: [true],
    });
  }

  add() {
    if (this.duesPaymentAddForm.valid) {
      let duesPaymentModel = Object.assign({}, this.duesPaymentAddForm.value);
      this.duesPaymentService.add(duesPaymentModel).subscribe(
        (data) => {
          this.toastrService.success(data.message, 'Başarılı');
          console.log(data);
        },
        (responseError) => {
          if (responseError.error.Errors.length > 0) {
            for (let i = 0; i < responseError.error.Errors.length; i++) {
              this.toastrService.error(
                responseError.error.Errors[i].ErrorMessage,
                'Doğrulama Hatası'
              );
            }
          }
        }
      );
    } else {
      this.toastrService.error('Formunuz eksik', 'Dikkat');
    }
  }

  getDueses() {
    return this.duesService.getDueses().subscribe((response) => {
      this.dueses = response.data;
    });
  }


 
  getCardDocumentsByUser(id:number):void {
    id = this.authService.getCurrentUserId();
    this.cardDocumentService.getByUserId(id).subscribe(response=>{
      this.cardDocuments = response.data;
    })   
  }
}
