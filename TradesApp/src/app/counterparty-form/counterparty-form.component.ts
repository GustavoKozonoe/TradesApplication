import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ICounterparty } from '../Interfaces/counterparty.interface';

@Component({
  selector: 'app-counterparty-form',
  templateUrl: './counterparty-form.component.html',
  styleUrls: ['./counterparty-form.component.css']
})
export class CounterpartyFormComponent implements OnInit {
  private readonly CounterpartyUrl = 'https://localhost:7158/api/CounterParties';

  Counterparties: ICounterparty[] = [];

  checkoutForm = this.formBuilder.group({
    id: '',
    name: ''
  })

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private http: HttpClient, 
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
  }

  backToMenu() {
    this.router.navigate(['/trades-table']);
  }

  submitItem() {
    this.http.post(this.CounterpartyUrl, this.checkoutForm.value).subscribe(
      () => this.router.navigate(['/trades-table']), 
      error => console.log(error)      
    );
  }
}
