import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {
  MatFormFieldModule,
  MatButtonModule,
  MatCheckboxModule,
  MatToolbarModule,
  MatInputModule,
  MatIconModule,
  MatProgressSpinnerModule,
  MatCardModule,
  MatMenuModule,
  MatOptionModule,
  MatSelectModule
} from '@angular/material';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxMaskModule } from "ngx-mask";

import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { MaterialFileInputModule } from 'ngx-material-file-input';

import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
registerLocaleData(localePt);

import { FormBaseComponent } from './form-base.component';
import { FieldErrorDisplayComponent } from './shared/components/field-error-display/field-error-display.component';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
  
import { AboutUsComponent } from './about-us/about-us.component';
import { CareerComponent } from './career/career.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { ServicesComponent } from './services/services.component';
import { UserCasesComponent } from './user-cases/user-cases.component';
import { WatermarkComponent } from './watermark/watermark.component';


@NgModule({
  declarations: [
    AppComponent,
    FormBaseComponent,
    NavMenuComponent,
    FooterComponent,
    FieldErrorDisplayComponent,
    HomeComponent,
    AboutUsComponent,
    CareerComponent,
    ContactUsComponent,
    ServicesComponent,
    UserCasesComponent,
    WatermarkComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    NoopAnimationsModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    AngularFontAwesomeModule,
    NgSelectModule,
    ReactiveFormsModule,
    MaterialFileInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatCheckboxModule,
    MatToolbarModule,
    MatInputModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatCardModule,
    MatMenuModule,
    MatOptionModule,
    MatSelectModule,

    NgxMaskModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'about-us', component: AboutUsComponent },
      { path: 'services', component: ServicesComponent },
      { path: 'user-cases', component: UserCasesComponent },
      { path: 'career', component: CareerComponent },
      { path: 'contact-us', component: ContactUsComponent },
      { path: 'watermark-document', component: WatermarkComponent },
    ])
  ],
  providers: [
    { provide: LOCALE_ID, useValue: "pt-BR" }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
