import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-show-prod',
  templateUrl: './show-prod.component.html',
  styleUrls: ['./show-prod.component.scss']
})
export class ShowProdComponent implements OnInit {

  constructor(private service:SharedService) { }

  ProductsList:any =[];
  
  ModalTitle:string | undefined;
  
  ActivateAddEditProd:boolean=false;
  prod:any;
 
  ngOnInit(): void {
    this.refreshProdList();
  }

  addClick(){
    this.prod={
      Id:0,
      Name:"ProductName",
      Price:0,
      PhotoFileName:"anonymous.png"
    }
    this.ModalTitle="Add Product";
    this.ActivateAddEditProd=true;
  }

  editClick(item: any){
    console.log(item);
    this.prod=item;
    this.ModalTitle="Edit Product";
    this.ActivateAddEditProd=true;
  }

  deleteClick(item: any){
    console.log(item.Id);
    if(confirm('Are you sure??')){
      this.service.deleteProduct(item.Id).subscribe(data=>{
        alert(data.toString());
        this.refreshProdList();
      })
    }
  }



  closeClick(){
    this.ActivateAddEditProd=false;
    this.refreshProdList();
  }

  refreshProdList(){
    this.service.getallProdList().subscribe(data=>{
      this.ProductsList=data;
    });
  }


}
