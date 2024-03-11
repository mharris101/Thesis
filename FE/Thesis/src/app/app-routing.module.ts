import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { VideoCardComponent } from './video-card/video-card.component';
import { VideoCardDetailsComponent } from './video-card-details/video-card-details.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'videocards', component: VideoCardComponent },
  { path: 'videocards/:id', component: VideoCardDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
