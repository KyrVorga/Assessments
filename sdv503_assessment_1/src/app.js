/* ANCHOR File Information
Title: Calendar App
Author: Rhylei Tremlett
Version: 3.1
Date: 30/04/2022
----------------------------------------------------------------- */
//ANCHOR Code
class MyDate {
  constructor(date) {
    this.date = new Date(date);
    /* i decided to throw an error here so that it stops
    execution and doesnt run the other method calls, it
    also removes the need for error checking in each method */
    if (this.date == "Invalid Date") {
      throw new Error("Error, invalid input.");
    }
    this.splitDate();
  }

  /* creates the day, month and year 
  properties, as well as updates them*/
  splitDate() {
    this.day = this.date.getDate();
    this.month = this.date.getMonth();
    this.year = this.date.getFullYear();
  }

  /* checks if the date is invalid, then 
  returns the date in three formats 
  (the Date.getMonth() returns month with a base 0 index)*/
  printDates() {
    const months = [
      "January",
      "Febuary",
      "March",
      "April",
      "May",
      "June",
      "July",
      "August",
      "September",
      "October",
      "November",
      "December",
    ];
    
    return `${this.month + 1}/${this.day}/${this.year}\n${months[this.month]} ${
      this.day
    }, ${this.year}\n${this.day} ${months[this.month]} ${this.year}`;
  }

  /* increments the this.date property 
  and then calls splitDate() to update
  the day, month and year properties*/
  increment() {
    this.date.setDate(++this.day);
    this.splitDate();
  }

  /* decrements the this.date property 
  and then calls splitDate() to update 
  the day, month and year properties*/
  decrement() {
    this.date.setDate(--this.day);
    this.splitDate();
  }

  /* checks if the new date is invalid, then 
  returns the absolute difference of the two dates 
  (rounded because.. well Javascript..)*/
  subtract(newDate) {
    if (new Date(newDate) == "Invalid Date") {
      return "Error, second date is invalid.";
    } else {
      return Math.round(
        Math.abs((this.date - new Date(newDate)) / (1000 * 60 * 60 * 24))
      );
    }
  }
}

// ANCHOR Valid inputs

console.log("\n");

// start of year test
console.log("Start of year decrement test");
const date = new MyDate("12/1/2023");
console.log(date.printDates(), "\n");
date.decrement();
console.log("After decrement method:");
console.log(date.printDates(), "\n");
console.log("Result of subtraction method: ", date.subtract("4/25/22"), "\n\n");

// end of year
console.log("End of year increment test");
const date2 = new MyDate("12/31/22");
console.log(date2.printDates(), "\n");
date2.increment();
console.log(date2.printDates(), "\n");
console.log(
  "Result of subtraction method: ",
  date2.subtract("4/25/22"),
  "\n\n"
);

// random date
console.log("Any non edge values test");
const date3 = new MyDate("2/18/23");
console.log(date3.printDates(), "\n");
date3.increment();
console.log(date3.printDates(), "\n");
console.log(
  "Result of subtraction method: ",
  date3.subtract("4/25/22"),
  "\n\n"
);

// month as text
console.log("Month provided as text test");
const date4 = new MyDate("1 may 2024");
console.log(date4.printDates(), "\n");
date4.increment();
console.log(date4.printDates(), "\n");
console.log(
  "Result of subtraction method: ",
  date4.subtract("4/25/22"),
  "\n\n"
);

// ANCHOR Invalid inputs

// // day first
// const date5 = new MyDate("31 1 2023");
// console.log(date5.printDates());

// // adding text
// const date6 = new MyDate("1st of the 4th 2023");
// console.log(date6.printDates());

// // day to large
// const date7 = new MyDate("32 may 2023");
// console.log(date7.printDates());

// // spelling errors
// const date8 = new MyDate("1 mae 2023");
// console.log(date8.printDates());

// // values too high
// const date9 = new MyDate("18/18/23");
// console.log(date9.printDates());

// // values too low
// const date10 = new MyDate("0/0/23");
// console.log(date10.printDates());
