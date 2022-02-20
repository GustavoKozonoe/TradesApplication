import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ICounterparty } from '../Interfaces/counterparty.interface';
import { ITrade } from '../Interfaces/trade.interface';

@Component({
  selector: 'app-trades-table',
  templateUrl: './trades-table.component.html',
  styleUrls: ['./trades-table.component.css']
})
export class TradesTableComponent implements OnInit {
  private readonly tradeUrl = 'https://localhost:7158/api/Trades';
  private readonly CounterpartyUrl = 'https://localhost:7158/api/CounterParties';
  
  Trades: ITrade[] = [];
  Counterparties: ICounterparty[] = [];
  
  constructor(private router: Router, private http: HttpClient) {
  }
  
  selectedTrade = 0;

  ngOnInit(): void {
    this.getAllTrades(false, 0).subscribe(t => this.Trades = t);
    this.getAllCounterParties().subscribe(cp => this.Counterparties = cp)
  }

  getTrade() {
    if(this.selectedTrade == 0){
      this.getAllTrades(false, this.selectedTrade).subscribe(t => this.Trades = t);
    }
    else {
      this.getAllTrades(true, this.selectedTrade).subscribe(t => this.Trades = t);
    }
  }

  toTradeForm() {
    this.router.navigate(['/trades-form']);
  }

  toCounterpartyForm() {
    console.log('uia');
    this.router.navigate(['/counterparty-form']);
  }

  editItem(id: number) {
    this.router.navigate(['/trades-form', { id: id }]);
  }

  deleteTrade(id: number) {
    this.http.delete(`${this.tradeUrl}/${id}`).subscribe(
      () => {
        console.log("success")
        this.getTrade();
      }  
    );
  }

  getAllTrades(AllOrNot: boolean, selectedTrades: number): Observable<ITrade[]> {
    if(!AllOrNot){    
      return this.http.get(this.tradeUrl) as Observable<ITrade[]>;
    } 
    else {     
      return this.http.get(`${this.tradeUrl}/getByCounterpartyId/${selectedTrades}`) as Observable<ITrade[]>;   
    }
  }

  getAllCounterParties(): Observable<ICounterparty[]> {
    return this.http.get(this.CounterpartyUrl) as Observable<ICounterparty[]>;
  }
}
