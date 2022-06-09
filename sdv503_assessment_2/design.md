# Top-Down approach

First i will describe the task, then i will list the basic requirements.

In this program I need to convert an array of arrays that contains
1's and 0's into a minesweeper board containing 1-9's and x's.

1) The program will need to be able to convert a number into an x.

2) The program will need to be able to calculate for each cell, how many mines are surrounding it.

3) The program will need to stay within the bounds of the array.

for testing purposes it may be beneficial to create a function that can generate grids to pass to the main function.

it would also be good for the program to be able to handle different sized grids and in turn be able to generate larger grids too.

My retrospective top-down approach:
the program must transform a grid of 1's and 0's into a array representation of a minesweeper board

1. It must be able to convert squares from one value to another
   1. must be ablt to change 1 into 9
   2. must be ablt to change anything larger than 9 into x
2. it must be able to iterate over all of the elements and locate mines (9's)
3. it must be able to increment all of the cells surronding a mine
   1. must not attempt to increment cells that are out of bounds (eg. -1 or array.length+1)
4. It must be not modify the original array
   1. it should be be built using pure functions
