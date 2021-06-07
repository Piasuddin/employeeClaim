import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { EmployeeClaimStatus } from '../enums/enum';
import { EmployeeClaim } from '../models/employee-claim.model';
import { EmployeeClaimService } from '../services/employee-claim.service';

@Component({
  selector: 'app-employee-claim-list',
  templateUrl: './employee-claim-list.component.html',
  styleUrls: ['./employee-claim-list.component.css']
})
export class EmployeeClaimListComponent implements OnInit {
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();
  employeeClaimStatus = EmployeeClaimStatus;
  displayedColumns = ["employeeName", "mobile", "email", "status", "action"];
  constructor(private employeeClaimService: EmployeeClaimService, private matSnackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.employeeClaimService.get().subscribe(e => {
      if (e) {
        this.dataSource.data = <any>e;
      }
    })
  }
  getStatus(num){
    if(num)
      return EmployeeClaimStatus[num];
  }
  onAction(action: number, id: number){
    let claim = new EmployeeClaim();
    claim.id = id;
    claim.status = action;
    this.employeeClaimService.update(claim).subscribe(res=>{
      if(res){
        console.log(this.dataSource);
        let item = this.dataSource.data.find(e => e.id == id);
        item.status = action;
        this.matSnackBar.open("Claim " + this.employeeClaimStatus[action] + " Successfull", "OK", {duration: 5000})
      }
    })
  }
}
