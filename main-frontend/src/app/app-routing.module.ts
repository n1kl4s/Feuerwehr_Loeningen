import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { PasswordForgetComponent } from './pages/password-forget/password-forget.component';
import { HomeComponent } from './pages/home/home.component';
import { ImpressumComponent } from './pages/impressum/impressum.component';
import { DatenschutzComponent } from './pages/datenschutz/datenschutz.component';
import { TechnischesComponent } from './pages/technisches/technisches.component';
import { SeniorenComponent } from './pages/about/senioren/senioren.component';
import { JugendComponent } from './pages/about/jugend/jugend.component';
import { MannschaftComponent } from './pages/about/mannschaft/mannschaft.component';
import { KommandoComponent } from './pages/about/kommando/kommando.component';
import { AdacCardComponent } from './pages/buergerinfo/adac-card/adac-card.component';
import { RauchmelderComponent } from './pages/buergerinfo/rauchmelder/rauchmelder.component';
import { WasTunImNotfallComponent } from './pages/buergerinfo/was-tun-im-notfall/was-tun-im-notfall.component';
import { FoerdervereinComponent } from './pages/foerderverein/foerderverein.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'impressum', component: ImpressumComponent  },
  { path: 'datenschutz', component: DatenschutzComponent  },
  { path: 'login', component: LoginComponent  },
  { path: 'register', component: RegisterComponent  },
  {
    path: 'technik',
    children: [
      {path: '', component: TechnischesComponent},
      {path: 'fahrzeuge', component: TechnischesComponent}
    ]
  },
  {
    path: 'about',
    children: [
      {path: 'jugend', component: JugendComponent},
      {path: 'senioren', component: SeniorenComponent},
      {path: 'mannschaft', component: MannschaftComponent},
      {path: 'kommando', component: KommandoComponent}
    ]
  },
  {
    path: 'info',
    children: [
      {
        path: 'buerger',
        children: [
          {path: 'rettungskarte', component: AdacCardComponent},
          {path: 'rauchmelder', component: RauchmelderComponent},
          {path: 'notfall', component: WasTunImNotfallComponent}
        ]
      }
    ]
  },
  { path: 'foerderverein', component: FoerdervereinComponent},
  { path: 'password-forget', component: PasswordForgetComponent  },
  { path: 'notfall', redirectTo: 'info/buerger/notfall'},
  { path: '**', component: HomeComponent  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
