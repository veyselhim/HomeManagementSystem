import { UserDetailComponent } from './components/user/user-detail/user-detail.component';
import { UserAddComponent } from './components/user/user-add/user-add.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { ApartmentAddComponent } from './components/apartment/apartment-add/apartment-add.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http'
import{BrowserAnimationsModule} from '@angular/platform-browser/animations';
import{FormsModule,ReactiveFormsModule} from '@angular/forms';

/*Tools*/
import{ToastrModule} from 'ngx-toastr';
import { NgSelectModule } from '@ng-select/ng-select';


/*Pipes*/
import { StatusToYesNoPipe } from './pipes/status-to-yes-no.pipe';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

/*Components*/
import { ApartmentComponent } from './components/apartment/apartment/apartment.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';
import { ErrorComponent } from './components/error/error.component';
import { DuesAddComponent } from './components/dues/dues-add/dues-add/dues-add.component';
import { BillAddComponent } from './components/bill/bill-add/bill-add.component';
import { ApartmentDetailComponent } from './components/apartment/apartment-detail/apartment-detail.component';
import { ApartmentUpdateComponent } from './components/apartment/apartment-update/apartment-update.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { UserNavComponent } from './components/user-dashboard/user-nav/user-nav.component';
import { UserComponent } from './components/user/user/user.component';
import { UserUpdateComponent } from './components/user/user-update/user-update.component';
import { DuesPaymentAddComponent } from './components/dues-payment/dues-payment-add/dues-payment-add.component';
import { BillPaymentAddComponent } from './components/bill-payment/bill-payment-add/bill-payment-add.component';
import { DuesDetailComponent } from './components/user-dashboard/dues-detail/dues-detail.component';
import { BillDetailComponent } from './components/user-dashboard/bill-detail/bill-detail.component';
import { MessageAddComponent } from './components/message/message-add/message-add.component';
import { CardDocumentComponent } from './components/user-dashboard/card/card-document/card-document.component';

@NgModule({
  declarations: [
    AppComponent,
    ApartmentComponent,
    AuthLayoutComponent,
    LoginComponent,
    RegisterComponent,
    AdminLayoutComponent,
    DashboardComponent,
    MainLayoutComponent,
    ApartmentAddComponent,
    ErrorComponent,
    UserAddComponent,
    DuesAddComponent,
    BillAddComponent,
    UserComponent,
    UserDetailComponent,
    UserUpdateComponent,
    ApartmentDetailComponent,
    ApartmentUpdateComponent,
    StatusToYesNoPipe,
    HomePageComponent,
    UserDashboardComponent,
    UserNavComponent,
    DuesPaymentAddComponent,
    BillPaymentAddComponent,
    DuesDetailComponent,
    BillDetailComponent,
    MessageAddComponent,
    CardDocumentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgSelectModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass:"toast-bottom-right"
    })
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS,useClass:AuthInterceptor,multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
