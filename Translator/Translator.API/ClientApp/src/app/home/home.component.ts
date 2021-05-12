import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public searchForm: FormGroup;
  public word: string;

  public registerForm: FormGroup;

  ngOnInit(): void {
    this.searchForm = new FormGroup({
      word: new FormControl('')
    });
  }

  public search = (searchForm) => {
    const formValues = { ...searchForm };
    console.log("vaule: " + formValues.word );
    this.word = `${formValues.word}`
    this.searchForm.value.word = "";
  }
}
