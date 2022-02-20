import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TradesFormComponent} from '../app/trades-form/trades-form.component'
import { CounterpartyFormComponent } from './counterparty-form/counterparty-form.component';
import { TradesTableComponent } from './trades-table/trades-table.component';

const routes: Routes = [
  { path: 'trades-table', component:  TradesTableComponent},
  { path: 'trades-form', component: TradesFormComponent },
  { path: 'counterparty-form', component: CounterpartyFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
