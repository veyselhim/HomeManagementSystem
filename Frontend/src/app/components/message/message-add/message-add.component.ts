import { AuthService } from 'src/app/services/auth/auth.service';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MessageService } from './../../../services/message/message.service';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-message-add',
  templateUrl: './message-add.component.html',
  styleUrls: ['./message-add.component.css']
})
export class MessageAddComponent implements OnInit {

  messageAddForm! : FormGroup
  currentUserId!:number;
  currentUserName!:string;
  constructor(private messageService:MessageService,private toastrService:ToastrService , private formBuilder: FormBuilder,private authService:AuthService) { }

  ngOnInit(): void {
    this.authService.setUserName();
    this.currentUserName = this.authService.currentUserName;
    this.createMessageAddForm();
  }

  createMessageAddForm(){
    this.currentUserId = this.authService.getCurrentUserId();
    this.messageAddForm = this.formBuilder.group({
      userId : [this.authService.currentUserId],
      subject: ["",Validators.required],
      content: ["",Validators.required],
      createdDate:[environment.date]
    })
  }

  add() {
    if (this.messageAddForm.valid) {
      let message = Object.assign({}, this.messageAddForm.value);
      this.messageService.add(message).subscribe(
        (data) => {
          this.toastrService.success(data.message, 'Başarılı');
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

}
