import { Component, OnInit } from '@angular/core';
import { Product } from '../interfaces/product.interface';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styles: [
  ]
})
export class ListComponent implements OnInit {

 
  private _products: Product[] = [];

  get products(){
    return [...this._products];
  }

  constructor( private productService: ProductService ) {
      productService.getProducts().subscribe((data:Product[]) => {
        this._products = data;
      });
  }

  addProductInCar(product: Product, amount: string){
    const currentProduct: Product = product;
    currentProduct.amount = currentProduct.amount - parseInt(amount);
  }

  ngOnInit(): void {
  }



}
