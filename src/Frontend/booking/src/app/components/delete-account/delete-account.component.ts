import { Component, Input, OnInit } from '@angular/core';
import { UserService } from '../../service/user.service';

@Component({
  selector: 'app-delete-account',
  templateUrl: './delete-account.component.html',
  styleUrls: ['./delete-account.component.css']
})
export class DeleteAccountComponent implements OnInit {


  constructor(private userService:UserService) { }

  ngOnInit(): void {
  }

  delete(){
    this.userService.deleteUser().subscribe(data=>{
      this.userService.logout();
    },err=>{
      alert(err.error.detail)
    }
    )
  }

}
