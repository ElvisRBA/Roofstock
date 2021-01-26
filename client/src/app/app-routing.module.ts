import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExternalPropertiesListComponent } from './components/external-properties-list/external-properties-list.component';
import { InternalPropertiesListComponent } from './components/internal-properties-list/internal-properties-list.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ServerErrorComponent } from './components/server-error/server-error.component';

const routes: Routes = [
  {path: '', component: ExternalPropertiesListComponent},
  {path: 'properties', component: InternalPropertiesListComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
