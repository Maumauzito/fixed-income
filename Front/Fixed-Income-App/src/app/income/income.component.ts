import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { FixedIncome } from '../model/FixedIncome';

@Component({
  selector: 'app-income',
  templateUrl: './income.component.html',
  styleUrls: ['./income.component.scss']
})
export class IncomeComponent implements OnInit {

  public incomeFixed: string;
  incomeForm: FormGroup;
  income: FixedIncome;

  get fb(): any {
    return this.incomeForm.controls;
  }

  constructor(private http: HttpClient,
    private formBuilder: FormBuilder) { }



  public validation(): void {
    this.incomeForm = this.formBuilder.group({
      value: ['', Validators.required],
      months: [1, [Validators.required, Validators.min(1)]]
    });
  }

  public cdi: string = '';
  public tb: string = '';
  public initialValue: string = '';
  public finalValue: string = '';
  public numberOfMonths: string = '';
  public taxApplied: string = '';


  ngOnInit() {
    this.validation();
  }

  public postRequisition() {

    const params = new HttpParams()
      .set('value', this.incomeForm.value.value)
      .set('months', this.incomeForm.value.months);

    this.http.post('https://localhost:5001/fixed-income', null, { params })
      .toPromise().then((data) => {
        this.income = data as FixedIncome;
        this.cdi = String(this.income.cdi);
        this.tb = String(this.income.tb);
        this.initialValue = String(this.income.initialValue);
        this.finalValue = String(this.income.finalValue);
        this.numberOfMonths = String(this.income.numberOfMonths);
        this.taxApplied = String(this.income.taxApplied);
      });

  }
}
