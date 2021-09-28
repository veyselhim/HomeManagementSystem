import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CardDocument } from 'src/app/models/cardDocument/cardDocument';
import { CardDocumentService } from './../../../../services/cardDocument/card-document.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-card-document',
  templateUrl: './card-document.component.html',
  styleUrls: ['./card-document.component.css']
})
export class CardDocumentComponent implements OnInit {

  cardDocuments:CardDocument[]=[];
  cardDocumentAddForm!:FormGroup
  id!:number;
  constructor(private authService:AuthService ,
     private cardDocumentService:CardDocumentService,
     private toastrService:ToastrService,
     private router:Router,
     private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    this.getCardDocumentsByUser(this.id);
    this.createCardDocumentPaymentForm();
  }

  createCardDocumentPaymentForm() {
    this.id = this.authService.currentUserId;
    this.cardDocumentAddForm = this.formBuilder.group({
      userId: [this.id],
      cardHolderName: ['', Validators.required],
      cardNumber: ['', Validators.required],
      cvv: ['', Validators.required],
      expDate: ['', Validators.required]
    });
  }
 
  add() {
    if (this.cardDocumentAddForm.valid) {
      let duesPaymentModel = Object.assign({}, this.cardDocumentAddForm.value);
      this.cardDocumentService.add(duesPaymentModel).subscribe(
        (data) => {
          this.router.navigateByUrl('/CardDocumentComponent', { skipLocationChange: true }).then(() => {
            this.router.navigate(['/userdashboard/card']);
        }); 
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

  delete(id:string){
    if(confirm("Silmek istediğine emin misin?")){
      this.cardDocumentService.delete(id).subscribe(data=>{
        this.toastrService.success(data.message,"Başarılı")
        //refreshing page
        this.router.navigateByUrl('/CardDocumentComponent', { skipLocationChange: true }).then(() => {
          this.router.navigate(['/userdashboard/card']);
      }); 

    },dataError=>{
        if(dataError.error.Errors.length>0){
          console.log(dataError.error.Errors)
          for(let i = 0; i<dataError.error.Errors.length;i++){
            this.toastrService.error(dataError.error.Errors[i].ErrorMessage,"Doğrulama Hatası")
          }
        }
      })
    }
  }

  getCardDocumentsByUser(id:number):void {
    id = this.authService.getCurrentUserId();
    this.cardDocumentService.getByUserId(id).subscribe(response=>{
      this.cardDocuments = response.data;
    })   
  }


}
