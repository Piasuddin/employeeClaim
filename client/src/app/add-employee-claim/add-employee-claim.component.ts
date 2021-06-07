import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { EmployeeClaimService } from '../services/employee-claim.service';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-add-employee-claim',
  templateUrl: './add-employee-claim.component.html',
  styleUrls: ['./add-employee-claim.component.css']
})
export class AddEmployeeClaimComponent implements OnInit {
  employeeClaimForm: FormGroup;
  employees: any = [];
  constructor(private employeeClaimService: EmployeeClaimService, private matSnackBar: MatSnackBar,
    private employeeService: EmployeeService, private _formBuilder: FormBuilder, private router: Router) {
    this.employeeClaimForm = this._formBuilder.group({
      id: [0],
      employeeId: ['', Validators.required],
      subscriptionId: ['', Validators.required],
      file: [''],
      comment: ['']
    })
  }

  ngOnInit(): void {
    this.employeeService.get().subscribe(e => {
      console.log(e);
      if (e)
        this.employees = e;
    })
  }
  onSubmit() {
    if (this.employeeClaimForm.valid) {
      let data = this.employeeClaimForm.value;
      data['fileName'] = this.fileName;
      data['employeeId'] = Number(data['employeeId']);
      console.log(data)
      this.employeeClaimService.save(this.employeeClaimForm.value).subscribe(e => {
        console.log(e);
        if (e) {
          this.matSnackBar.open("Claim submitted successfull", "OK", {duration: 5000});
          this.router.navigateByUrl("/");
        }
      })
    }
  }
  fileName;
  file;
  onFileSelected(event) {
    let fileReader = new FileReader();
    let file = event.target.files[0];
    fileReader.readAsDataURL(file);
    fileReader.onload = (e: any) => {
      this.fileName = file.name;
      this.file = e.target.result;
      this.employeeClaimForm.get('file').setValue(this.file);

    }
  }
  onFileClick() {
    document.getElementById("file").click();
  }
}

