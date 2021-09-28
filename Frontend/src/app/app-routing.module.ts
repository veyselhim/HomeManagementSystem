import { CardDocumentComponent } from './components/user-dashboard/card/card-document/card-document.component';
import { CardDocumentService } from './services/cardDocument/card-document.service';
import { AdminGuard } from './guards/admin.guard';
import { LoginGuard } from './guards/login.guard';
import { BillPaymentAddComponent } from './components/bill-payment/bill-payment-add/bill-payment-add.component';
import { BillDetailComponent } from './components/user-dashboard/bill-detail/bill-detail.component';
import { DuesDetailComponent } from './components/user-dashboard/dues-detail/dues-detail.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { DuesPaymentAddComponent } from './components/dues-payment/dues-payment-add/dues-payment-add.component';
import { UserDetailComponent } from './components/user/user-detail/user-detail.component';
import { UserAddComponent } from './components/user/user-add/user-add.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { ApartmentUpdateComponent } from './components/apartment/apartment-update/apartment-update.component';
import { ApartmentDetailComponent } from './components/apartment/apartment-detail/apartment-detail.component';
import { BillAddComponent } from './components/bill/bill-add/bill-add.component';
import { DuesAddComponent } from './components/dues/dues-add/dues-add/dues-add.component';
import { ApartmentAddComponent } from './components/apartment/apartment-add/apartment-add.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { ApartmentComponent } from './components/apartment/apartment/apartment.component';
import { ErrorComponent } from './components/error/error.component';
import { UserComponent } from './components/user/user/user.component';
import { UserUpdateComponent } from './components/user/user-update/user-update.component';
import { MessageAddComponent } from './components/message/message-add/message-add.component';

const routes: Routes = [
{
  path: '',
  component: HomePageComponent,
  children: []
},
{
  path: 'home',
  component: HomePageComponent,
  children: [

  ]
},


{
  path: 'userdashboard',
  component: UserDashboardComponent,canActivate:[LoginGuard],
  children: [
    {path:"duesdetail",component:DuesDetailComponent},
    {path:"billdetail",component:BillDetailComponent},
    {path:"duesdetail/payment/add/:id",component:DuesPaymentAddComponent},
    {path:"billdetail/payment/add/:id",component:BillPaymentAddComponent},
    {path:"messageadd",component:MessageAddComponent},
    {path:"card",component:CardDocumentComponent}

  ]
},
{
  path: 'admin',
  component: DashboardComponent,canActivate:[LoginGuard,AdminGuard],
  children: [

    {path:"apartments",component:ApartmentComponent },
    {path:"apartment/add",component:ApartmentAddComponent},
    {path:"apartments/detail/:id",component:ApartmentDetailComponent},
    {path:"apartments/update/:id",component:ApartmentUpdateComponent},


    { path: 'users', component: UserComponent},
    { path: 'users/add', component: UserAddComponent },   
    { path: 'users/detail', component: UserDetailComponent},
    { path: 'users/update/:id', component: UserUpdateComponent},
    { path: 'users/detail/:id', component: UserDetailComponent},

    { path: 'dues/add', component: DuesAddComponent },

    { path: 'bill/add', component: BillAddComponent}
    
  ]
},
{
  path: 'auth',
  component: AuthLayoutComponent,
  children: [
    { path: '', component: RegisterComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent }
    
  ],
},
{
  path: '**',
  component: ErrorComponent,
},



];

@NgModule({
  imports: [RouterModule.forRoot(routes,{onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
