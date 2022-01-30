import { StringMapWithRename } from '@angular/compiler/src/compiler_facade_interface';
import { Component, Input, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

import { SharedService } from '../shared.service';

@Component({
  selector: 'app-add-edit-prod',
  templateUrl: './add-edit-prod.component.html',
  styleUrls: ['./add-edit-prod.component.scss']
})

export class AddEditProdComponent implements OnInit {

  @Input()prod: any;
  Id:string | undefined;
  Name: string | undefined;
  Price:  number | undefined;
  PhotoFileName:string | undefined;
  PhotoFilePath:string | undefined;

  constructor(private service:SharedService) { }

  ngOnInit(): void {
  }

  addProduct(){
    console.log("Am ajuns aici");
    var val = {Id: this.Id,
              Name: this.Name,
              Price:this.Price,
              PhotoFileName : this.PhotoFileName};
    this.service.addProduct(val).subscribe(res =>
      {
        alert(res.toString());
      })
  

    }


    updateProduct(){
      var val = {Id: this.Id,
        Name: this.Name,
        Price:this.Price,
        PhotoFileName : this.PhotoFileName};
  
      this.service.updateProduct(val).subscribe(res=>{
      alert(res.toString());
      });
    }
  
  
    uploadPhoto(event:any){
      var file=event.target.files[0];
      const formData:FormData=new FormData();
      formData.append('uploadedFile',file,file.name);
  
      this.service.UploadPhoto(formData).subscribe((data:any)=>{
        this.PhotoFileName=data.toString();
        this.PhotoFilePath=environment.PhotoUrl+this.PhotoFileName;
      })
    }
}
