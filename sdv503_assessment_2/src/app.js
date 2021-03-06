/* ANCHOR File Information
Title: Minesweeper App
Author: Rhylei Tremlett
Version: 5.3
Date: 17/05/2022
------------------------------------------------------------- */

//ANCHOR Code

/*
Adjacentcells is what does all of the heavy lifting,
this function iterates over each item, checks if it
is a mine, if it is then it will attempt to add 1 to
all of the surronding cells, it performs a check to
see if the cells its attempting to increment is 
within the bounds of the array.
*/
const adjacentCells = (grid) => {
  const coordinates = [
    [1, 0],
    [0, 1],
    [1, -1],
    [1, 1],
    [-1, 0],
    [0, -1],
    [-1, -1],
    [-1, 1],
  ];

  grid.forEach((row, i) => {
    row.forEach((col, j) => {
      if (col > 8) {
        coordinates.forEach((elem) => {
          if (
            i + elem[0] < grid.length &&
            i + elem[0] >= 0 &&
            j + elem[1] < row.length &&
            j + elem[1] >= 0
          ) {
            grid[i + elem[0]][j + elem[1]]++;
          }
        });
      }
    });
  });
};

/*
this function converts every number inside of
GRID that is greater than or equal to A into B
*/
const convert = (grid, a, b) => {
  grid.forEach((row, i) => {
    row.forEach((col, j) => {
      if (col >= a) {
        grid[i][j] = b;
      }
    });
  });
};

/*
this function generates a grid that is
n by n where n is equal to the size argument,
it has a 20% chance of any cell being a mine.
*/
const generateGrid = (size) => {
  let grid = [];
  for (let i = 0; i < size; i++) {
    grid.push([]);
    for (let j = 0; j < size; j++) {
      Math.random() < 0.2 ? grid[i].push(1) : grid[i].push(0);
    }
  }
  return grid;
};
/*
this is the main function that invokes the
other functions and provides their arguments.
*/
const minesweeper = (arr) => {
  grid = [...arr];
  convert(grid, 1, 9);
  adjacentCells(grid);
  convert(grid, 9, "x");
  return grid;
};

/* 
use this line to use the same 
grid each time you run the code.
*/
console.log(
  minesweeper([
    [0, 1, 0, 0],
    [0, 0, 1, 0],
    [0, 1, 0, 1],
    [1, 1, 0, 0],
  ])
);

/* 
use this line to have a new 
grid each time the code is run
*/
console.log(minesweeper(generateGrid(4)));
