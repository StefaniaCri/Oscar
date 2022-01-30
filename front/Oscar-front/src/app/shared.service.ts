import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class SharedService {

  readonly APIUrl = environment.baseUrl + '/api';

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
      return this.http.delete(this.APIUrl+'/Product/Delete',val);
    }
 
    UploadPhoto(val:any)
    {
      return this.http.post(this.APIUrl+'/Product/SaveFile',val);
    }
}
