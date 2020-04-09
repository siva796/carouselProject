import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { SoftDeleteService } from '../Services/SoftDeleteService';

@Component({
  selector: 'app-soft-delete',
  templateUrl: './soft-delete.component.html',
  styleUrls: ['./soft-delete.component.css']
})
export class SoftDeleteComponent implements OnInit {
deleteForm:FormGroup;
usersId:any;
submittedButton:any;
deleteOrNot:any;
isDeleted:any;
alertMessage:any;


  constructor(private formBuilder: FormBuilder,private myRoutes: Router,private softdeleteService:SoftDeleteService) {
    this.deleteForm = new FormGroup({
      usersId:new FormControl()
    });
   }
   get DeleteData() { return this.deleteForm.controls; }
   SoftDelete() {
    this.submittedButton = true;
   if (this.deleteForm.invalid) {
     console.log('Invalid Form');

     return;
   }
   if (this.deleteForm.valid) {


     this.usersId= this.deleteForm.value.usersId;
     this.softdeleteService.SoftDelete(this.usersId,this.isDeleted);
     this.deleteOrNot="Deleted successfully";
     console.log(this.usersId);

   }
 }
 ResetButton() {
  this.submittedButton = false;
  this.deleteForm.reset();
 }
 Back(){
  this.myRoutes.navigate(['/userData']);
  
 }

 deleteFunction(){
  this.alertMessage=1;//shows what data to delete
  
 }

  ngOnInit() {
    this.deleteForm = this.formBuilder.group({
      usersId:['', [ Validators.pattern('[0-9]*'),Validators.required]]
    })
  }

}
