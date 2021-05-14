import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TranslationService } from '../shared/services/translation.service';
import { CommonModule } from "@angular/common";


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public searchForm: FormGroup;
  public word: string;

  public translation: string;
  public translationExist: boolean;

  public nounsTranslations: string[];
  public nounsTranslationExist: boolean;

  public adjectivesTranslations: string[];
  public adjectivesTranslationExist: boolean;

  public verbsTranslations: string[];
  public verbsTranslationExist: boolean;

  public registerForm: FormGroup;

  constructor(private _translationService: TranslationService) { }

  ngOnInit(): void {
    this.searchForm = new FormGroup({
      word: new FormControl('')
    });
  }

  public search = (searchForm) => {
    const formValues = { ...searchForm };
    this.word = `${formValues.word}`
    this.searchForm.value.word = "";
    this._translationService.getTranslation( "api/translations/translate",this.word).subscribe(
      (translationDto) => {
       this.translationExist = true;
       this.translation = translationDto.translations.toString();
       if(translationDto === null){
        this.translationExist = false;
        return;
       }
       if(translationDto.nounsTranslations != null && translationDto.nounsTranslations.length > 0){
        this.nounsTranslationExist = true;
        this.nounsTranslations = translationDto.nounsTranslations;
      }
       else{
        this.nounsTranslationExist = false;
       }
       if(translationDto.verbsTranslations != null && translationDto.verbsTranslations.length > 0){
        this.verbsTranslationExist = true;
        this.verbsTranslations = translationDto.verbsTranslations;
       }
       else{
        this.verbsTranslationExist = false;
       }
       if(translationDto.adjectivesTranslations != null && translationDto.adjectivesTranslations.length > 0){
        this.adjectivesTranslationExist = true;
        this.adjectivesTranslations = translationDto.adjectivesTranslations;
       }
       else{
        this.adjectivesTranslationExist = false;
       }
       console.log(this.nounsTranslationExist);
      console.log(this.verbsTranslationExist);
      console.log(this.adjectivesTranslationExist);
      }
      ,
      (error)=>{
        this.translationExist = false;
      }
    );
  }
}
