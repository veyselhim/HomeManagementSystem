import { UserService } from '../../../services/user/user.service';
import { ToastrService } from 'ngx-toastr';
import { Component, Inject, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/user/user';

@Component({
  selector: 'app-resident',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  users:User[] = []
  constructor(private userService:UserService , private toastrService:ToastrService, private router:Router) {

   }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(){
    this.userService.getUsers().subscribe((response)=>{
      console.log(response)
      this.users = response.data;
    });
  }

 

  delete(id:number){
    if(confirm("Silmek istediğine emin misin?")){
      this.userService.delete(id).subscribe(data=>{
        this.toastrService.success(data.message,"Başarılı")
        //refreshing page
        this.router.navigateByUrl('/UserComponent', { skipLocationChange: true }).then(() => {
          this.router.navigate(['/admin/users']);
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

  
}
  


