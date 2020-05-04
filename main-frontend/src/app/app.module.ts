import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ScrollSpyModule } from 'ngx-scrollspy';
import { ScrollToModule } from '@nicky-lenaers/ngx-scroll-to';
import { NgxYoutubePlayerModule } from 'ngx-youtube-player';
import { ParticlesModule } from 'angular-particle';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './layout/app.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { HomeComponent } from './pages/home/home.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { PasswordForgetComponent } from './pages/password-forget/password-forget.component';
import { ImpressumComponent } from './pages/impressum/impressum.component';
import { DatenschutzComponent } from './pages/datenschutz/datenschutz.component';
import { VehicleOverviewComponent } from './pages/technisches/vehicle-overview/vehicle-overview.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpErrorInterceptor } from './core/interceptor/HttpErrorInterceptor';
import { SeniorenComponent } from './pages/about/senioren/senioren.component';
import { JugendComponent } from './pages/about/jugend/jugend.component';
import { TechnischesComponent } from './pages/technisches/technisches.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MannschaftComponent } from './pages/about/mannschaft/mannschaft.component';
import { KommandoComponent } from './pages/about/kommando/kommando.component';
import { AdacCardComponent } from './pages/buergerinfo/adac-card/adac-card.component';
import { RauchmelderComponent } from './pages/buergerinfo/rauchmelder/rauchmelder.component';
import { WasTunImNotfallComponent } from './pages/buergerinfo/was-tun-im-notfall/was-tun-im-notfall.component';
import { BannerComponent } from './pages/home/banner/banner.component';
import { WerbungFoerdervereinComponent } from './pages/home/werbung-foerderverein/werbung-foerderverein.component';
import { LetzterEinsatzComponent } from './pages/home/letzter-einsatz/letzter-einsatz.component';
import { FoerdervereinComponent } from './pages/foerderverein/foerderverein.component';
import { NeubauComponent } from './pages/news/neubau/neubau.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    PasswordForgetComponent,
    ImpressumComponent,
    DatenschutzComponent,
    VehicleOverviewComponent,
    SeniorenComponent,
    JugendComponent,
    TechnischesComponent,
    MannschaftComponent,
    KommandoComponent,
    AdacCardComponent,
    RauchmelderComponent,
    WasTunImNotfallComponent,
    BannerComponent,
    WerbungFoerdervereinComponent,
    LetzterEinsatzComponent,
    FoerdervereinComponent,
    NeubauComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,  // Add this only in the root module
    ScrollSpyModule.forRoot(),
    ScrollToModule.forRoot(),
    CommonModule,
    NgxYoutubePlayerModule.forRoot(),
    ParticlesModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
