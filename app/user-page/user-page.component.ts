import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { UserModel } from '../Models/User.Model';
import { Router } from '@angular/router';
import { UserService } from '../Services/User.service';
import { UpdateService } from '../Services/UpdatePageService';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit {
  myForm: FormGroup;
  userData: UserModel;
  submittedButton = false;
  showData:any;
  userPage:any;
  updateOrNot:string;
  showUpdate:any;
  showUserPage:any;
  updateForm:FormGroup;
  totalRec : number;
  page: number =1;
  skipCancelData:any;
  userId:any;

  constructor(private formBuilder: FormBuilder,private myRoutes: Router,private userService:UserService,private updateService:UpdateService) {

    
    this.userData = new UserModel();
    // this.UserButton();
    this.myForm = new FormGroup({
     
      userName: new FormControl(),
      email: new FormControl()
      

    });
    

   }



//     onPageChange = (page) => {
//     this.pageChange.emit(page)     
// }
  
   get allUserData() { return this.myForm.controls; }

   UserButton() {
    this.submittedButton = true;
    if (this.myForm.invalid) {
      console.log('Invalid Form');

      return;
    }
    if (this.myForm.valid) {

      this.userData.userName = this.myForm.value.userName;


      this.userData.email = this.myForm.value.email;

     this.showData=1;//shows the grid data
     this.skipCancelData=1;
      
     
     this.userService.InsertUser(this.userData);
     this.userService.getUserDataFromApI().subscribe((data)=>
     {
       this.userPage= data;
       console.log(this.userPage);
     })

    }
  }
  
  
 Update(getData:UserModel)
 {
  // this.updateService.editUser(this.userId).subscribe( => {
  //   this.employee = employees[0];
  //   console.log(id);
  //   console.log(employee);
  // },
  this.updateService.editUser(this.userId);
  this.myRoutes.navigate(['/updatePage',{userData:JSON.stringify(getData)}],{skipLocationChange:true});
  // this.myRoutes.navigate(['/updatePage']);
 }
 Delete()
 {
  this.myRoutes.navigate(['/userDelete']);
 }


   ResetButton() {
    this.submittedButton = false;
    this.myForm.reset();
    this.skipCancelData=1;// skips the grid
    
   }
  
    ngOnInit(){
     
      // this.showUserPage=3;
      this.myForm = this.formBuilder.group({
        userName: ['', [Validators.required, Validators.pattern('^[a-zA-Z]*$'),]],

        email: ['', [Validators.required, Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$')]],
        
      })
     
      
      
    }
	}
