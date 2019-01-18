import { Component, OnInit } from '@angular/core';

export class GlobalError{

  constructor(err: string) {
    this.error = err;
  }

  public error : string;

}
