import { CardDocumentService } from './../../../services/cardDocument/card-document.service';
import { AuthService } from './../../../services/auth/auth.service';
import { BillService } from 'src/app/services/bill/bill.service';
import { BillPayment } from './../../../models/billPayment/billPayment';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Bill } from 'src/app/models/bill/bill';
import { BillPaymentService } from 'src/app/services/billPayment/bill-payment.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { CardDocument } from 'src/app/models/cardDocument/cardDocument';

@Component({
  selector: 'app-bill-payment-add',
  templateUrl: './bill-payment-add.component.html',
  styleUrls: ['./bill-payment-add.component.css']
})
export class BillPaymentAddComponent implements OnInit {

  billPayment!: BillPayment;
  billPaymentAddForm!: FormGroup;

  date = new Date().toJSON("yyyy/MM/dd HH:mm");
  id! : number;
  cardDocuments: CardDocument[] = [];
  bills: Bill[] = [];
  constructor(
    private billPaymentService: BillPaymentService,
    private toastrService: ToastrService,
    private formBuilder: FormBuilder,
    private authService:AuthService,
    private cardDocumentService:CardDocumentService,
    private billService: BillService,
    private activatedRoute:ActivatedRoute
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
    this.billPaymentAddForm = this.formBuilder.group({
      billId: [this.id],
      cardDocumentId: ['', Validators.required],
      payedDate: [this.date],
      status: [true],
    });
  }

  add() {
    if (this.billPaymentAddForm.valid) {
      let duesPaymentModel = Object.assign({}, this.billPaymentAddForm.value);
      this.billPaymentService.add(duesPaymentModel).subscribe(
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
    return this.billService.getBills().subscribe((response) => {
      this.bills = response.data;
    });
  }

  

  getCardDocumentsByUser(id:number):void {
    id = this.authService.getCurrentUserId();
    this.cardDocumentService.getByUserId(id).subscribe(response=>{
      this.cardDocuments = response.data;
    })   
  }
}
