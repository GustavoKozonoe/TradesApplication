import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ICounterparty } from '../Interfaces/counterparty.interface';
import { FormBuilder, Validators } from '@angular/forms';
import { ITrade } from '../Interfaces/trade.interface';

@Component({
  selector: 'app-trades-form',
  templateUrl: './trades-form.component.html',
  styleUrls: ['./trades-form.component.css']
})
export class TradesFormComponent implements OnInit {
  private readonly TradeUrl = 'https://localhost:7158/api/Trades';
  private readonly CounterpartyUrl = 'https://localhost:7158/api/CounterParties';
  

  Counterparties: ICounterparty[] = [];
  Trades: ITrade[] = [];

  checkoutForm = this.formBuilder.group({
    id: [''],
    counterPartyId: ['',Validators.required],
    quantity: ['',[Validators.required, Validators.pattern('[0-9]{1,}')]],
    price: ['',[Validators.required, Validators.pattern('[0-9]{1,}')]],
    direction: [0,Validators.required],
    product: ['',[Validators.minLength(2), Validators.maxLength(24)]], 
    date: ['', [Validators.required, Validators.pattern('([0]?[1-9]|[1][0-2])[./-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0-9]{4}|[0-9]{2})')]]
  })

  get price() {
    return this.checkoutForm.controls['price'];
  }

  get quantity() {
    return this.checkoutForm.controls['quantity'];
  }

  get counterpartyId() {
    return this.checkoutForm.controls['counterparty'];
  }

  get product() {
    return this.checkoutForm.controls['product'];
  }

  get date() {
    return this.checkoutForm.controls['date'];
  }

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private http: HttpClient, 
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.route.params.subscribe(p => {
        if(p){
          this.getTradeToEdit(p['id']).subscribe(t => {
            this.fillForm(t)
          });
        }
    });

    this.getAllCounterParties().subscribe(cp => this.Counterparties = cp)
  }

  fillForm(t: any) {
    this.checkoutForm.patchValue({
      id: t.id,
      counterPartyId: t.counterPartyId,
      price: t.price,
      quantity: t.quantity,
      direction: t.direction,
      product: t.product,
      date: new Date(t.date).toLocaleDateString(),
    })
  }

  backToMenu() {
    this.router.navigate(['/trades-table']);
  }

  submitItem() {
    if(this.checkoutForm.valid) {
      if (this.checkoutForm.value.id){
        console.log(this.checkoutForm.value.id, '😜');
        this.http.put(this.TradeUrl, this.checkoutForm.value).subscribe(
          () => this.router.navigate(['/trades-table']),
          error => console.log(error)
        );
      }
      else {
        console.log(this.checkoutForm.value.id, '😢');
        this.http.post(this.TradeUrl, this.checkoutForm.value).subscribe(
          () => this.router.navigate(['/trades-table']), 
          error => console.log(error)      
        );
      } 
    }
    else {
      console.log(this.checkoutForm.valid, this.checkoutForm);
    }
  }

  getTradeToEdit(id: number) {
    return this.http.get(`${this.TradeUrl}/getById/${id}`)
  }

  getAllTrades(AllOrNot: boolean, selectedTrades: number): Observable<ITrade[]> {
    if(!AllOrNot){ //getAllTrades  
      return this.http.get(this.TradeUrl) as Observable<ITrade[]>;
    } 
    else { //getSomeOfTheTrades           
      const bla = this.http.get(`${this.TradeUrl}/getByCounterpartyId/${selectedTrades}`) as Observable<ITrade[]>;
      return bla;      
    }
  }

  getAllCounterParties(): Observable<ICounterparty[]> {
    return this.http.get(this.CounterpartyUrl) as Observable<ICounterparty[]>;
  }
}
