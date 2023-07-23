# Technical Report

Here i will list all of the problems i ran into, how i solved them and what i learned from them.
afterwards i will format this into a word document. (probably..)

2/05/22
I ran into no problems meeting all of the requirments, going forward im going to focus on refining the program, adding comments and reducing complexity.

6/05/22
tried to refactor code to use .flat(), found quite fast that it doesnt work very well.
same day, i scrapped the flattenedd version, and started refactoring the code that worked, i was able to completely remove a function to reduce the # of lines and the complexity.

11/05/22
I worked on my design.md and provided a retrospective top-down design of what i was thinking when i began coding.

17/05/22
Added in comments to code, file information header in app.js, added a section on my algorithim development.

18/05/22
Ran app.js through prettier then re-adjusted comments.

My algorithim.

I originaly had approached the problem differently on another repository, in there i started by iterating over the entire grid and attemptted to count every mine that surronds that cell. i started by hardcodding all of 4 corner cases and 4 side cases and a center case. it was extremley ineffcienct, as it was performing 9 checks every cell, which ends up being 144 checks for a grid of 4 x 4. my new algorithim iterates of the grid, when it finds a mine it them adds one to all of its surronding cells. this is far more efficient and is written in less code. there will be 16 checks to see if a cell is a mine, there will then be 9 checks for each mine it finds, in a grid with 6 mines there will be 70 checks total. in less than half the amount of code.

Testing

For testing purposes i create the generate grid function so that every time i ran the code to test, it would use a new grid. I also tested my code with different sized grids, it can handle x by x and x by y sized grids, but breaks when the grid has jaggered borders i.e. the subarrays of the grid are varieing sizes.
