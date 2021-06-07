import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEmployeeClaimComponent } from './add-employee-claim/add-employee-claim.component';
import { EmployeeClaimListComponent } from './employee-claim-list/employee-claim-list.component';

const routes: Routes = [
  {path: "", component: EmployeeClaimListComponent},
  {path: "add", component: AddEmployeeClaimComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
