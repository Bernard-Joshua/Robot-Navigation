# Robot-Navigation
Assignment 1 : Option B : COS30019

# Introduction

Implemented a tree-based search algorithms in software (from scratch) to search for solutions to the Robot Navigation problem. Both informed and uninformed methods were used. Also carried out some self-learning to learn several search methods (not covered in the lectures).

# Robot Navigation Problem

In the lectures you have seen the Robot Navigation problem: The environment is an NxM grid (where N \> 1 and M \> 1) with a number of walls occupying some cells (marked as grey cells). The robot is initially located in one of the empty cells (marked as a red cell) and required to find a path to visit one of the designated cells of the grid (marked as green cells). For instance, the following is one possible environment:

Assume that the cells of the grid are located by their coordinates with the leftmost top cell being considered to be at the coordinate (0, 0). A wall is a rectangle whose leftmost top corner occupies a cell (x,y) and whose width (w) and height (h) capture its size. For instance, the above environment can be expressed by the


![Robot-Navigation-Map](https://github.com/Bernard-Joshua/Robot-Navigation/blob/main/Screenshot%202023-02-11%20122507.jpg)


**following specification:**

[5,11] // The grid has 5 rows and 11 columns

(0,1) // initial state of the agent – coordinates of the red cell

(7,0) | (10,3) // goal states for the agent – coordinates of the green cells

(2,0,2,2) // the square wall has the leftmost top corner occupies cell (2,0) and is 2 cells wide and 2 cell high

(8,0,1,2)

(10,0,1,1)

(2,3,1,2)

(3,4,3,1)

(9,3,1,1)

(8,4,2,1)

# Problem's File Format

The problems are stored in simple text files with the following format:

- First line contains a pair of numbers [N,M] – the number of rows and the number of columns of the grid, enclosed in square brackets.
- Second line contains a pair of numbers (x1,y1)– the coordinates of the current location of the agent, the initial state.
- Third line contains a sequence of pairs of numbers separated by |; these are the coordinates of the goal states: (xG1,yG1) | (xG2,yG2) | ... | (xGn,yGn), where n ≥ 
- The subsequent lines represent the locations of the walls: The tuple (x,y,w,h) indicates that the leftmost top corner of the wall occupies cell (x,y) with a width of w cells and a height of h cells.
- We are only interested in search algorithms. Therefore, it can be assumed that the problem files will contain valid configurations. For instance, if N=5 and M = 11 then you don't have to worry that the agent is initially located at coordinates (15, 3).
- The following describe a number of tree based search algorithms. Note: When all else is equal, nodes should be expanded according to the following order: the agent should try to move UP before attempting LEFT, before attempting DOWN, before attempting RIGHT, in that order. DFS, BFS, GBFS and AS have been covered in the lectures and the tutorials. CUS1 and CUS2 are two algorithms that was learnt by myself.

**NOTE:** The objective is to reach one of the green cells.

# Search Algorithms

## Uninformed

- Depth-First Search Select one option, try it, go back when there are no more options DFS
- Breadth-First Search Expand all options one level at a time BFS

## Informed

- GBFS
  - Greedy Best-First Use only the cost to reach the goal from the current node to

evaluate the node.

- A\* ("A Star")
  - Use both the cost to reach the goal from the current node and

the cost to reach this node to evaluate the node.

- Custom
  - Your search strategy 1 An uninformed method to find a path to reach the goal.
  - Your search strategy 2 An informed method to find a shortest path (with least moves) to reach the goal.

# Command Line Operation

The program operates from a Windows command-line (terminal) interface.

A Windows command-line interface can be brought up in Windows 10/11 by typing cmd into the search box at the Start button. You can create a Windows .bat (batch) file if needed to make it easy to execute your code. Below are the three different arguments formats you need to support. Note the unique argument count for each.

```
C:\Assignments\> search \<filename\> \<method\>
```

where search is the exe file or a .bat (batch) file that calls the program with the parameters.

Standard output needs to be in the following format:

```
filename method number\_of\_nodes path
```

where number\_of\_nodes is the number of nodes in search tree, and path is either a message "No

solution found." (when the program cannot find a solution) or a sequence of moves in the solution that

brings you from the start-configuration to the end-configuration. Line breaks are ignored.

For instance, a valid (and incomplete) path from the current configuration in the above example could be:

```
\> right; down; right; right; right; right; ...
```
