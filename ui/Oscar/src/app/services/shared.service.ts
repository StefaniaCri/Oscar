import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "https://localhost:44368/api";
  readonly PhotoUrl ="https://localhost:44368/Photos";
    
    constructor(private http:HttpClient){ }
    getallProdList():Observable<any[]>{
        return this.http.get<any>(this.APIUrl+'/Product');
    }

    addProduct(val:any){
      return this.http.post(this.APIUrl+'/Product/',val);
    }

    updateProduct(val:any)
    {
      return this.http.put(this.APIUrl+'/Product/',val);
    }
 
    deleteProduct(val:any)
    {
      return this.http.delete(this.APIUrl+'/Product/',val);
    }
 
    UploadPhoto(val:any)
    {
      return this.http.post(this.APIUrl+'/Product/SaveFile',val);
    }
}
