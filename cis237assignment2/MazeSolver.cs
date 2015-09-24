﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        char[,] maze;
        int xStart;
        int yStart;
        public MazeSolver()
        {
        }


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;
            displayMaze();
            mazeTraversal(yStart, xStart, 'd');
            Console.WriteLine("Done! Press any key to continue ");
            Console.ReadKey();

            //Do work needed to use mazeTraversal recursive call and solve the maze.
        }


        private void displayMaze()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int k = 0; k < maze.GetLength(1); k++)
                {
                    Console.Write(maze[i,k]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private int mazeTraversal(int y, int x, char lastMove)
        {
            int branchHolderInt;
            if (maze[y, x] == '#')
            {
                return -1;
            }
            maze[y, x] = 'x';
            displayMaze();
            if (x == 0 || x == maze.GetLength(1) - 1 || y == 0 || y == maze.GetLength(0) - 1)
            {
                return 1;
            }
            switch(lastMove)
            {
                case 's':
                    branchHolderInt = mazeTraversal(y, x + 1, 'e');
                    if(branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if(branchHolderInt == 0)
                    {
                        maze[y, x + 1] = '0';
                        displayMaze();
                    }
                    branchHolderInt = mazeTraversal(y - 1, x, 's');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y - 1, x] = '0';
                        displayMaze();
                    }
                    branchHolderInt = mazeTraversal(y, x - 1, 'w');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y, x - 1] = '0';
                        displayMaze();
                    }
                    return 0;
                case 'w':
                    branchHolderInt = mazeTraversal(y + 1, x, 'n');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y + 1, x] = '0';
                        displayMaze();
                    }
                    branchHolderInt = mazeTraversal(y - 1, x, 's');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y - 1, x] = '0';
                        displayMaze();
                    }
                    branchHolderInt = mazeTraversal(y, x - 1, 'w');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y, x - 1] = '0';
                        displayMaze();
                    }
                    return 0;
                case 'n':
                    branchHolderInt = mazeTraversal(y + 1, x, 'n');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y + 1, x] = '0';
                        displayMaze();
                    }
                    branchHolderInt = mazeTraversal(y, x + 1, 'e');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y, x + 1] = '0';
                        displayMaze();
                    }
                    branchHolderInt = mazeTraversal(y, x - 1, 'w');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y, x - 1] = '0';
                        displayMaze();
                    }
                    return 0;
                case 'e':
                    branchHolderInt = mazeTraversal(y + 1, x, 'n');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y + 1, x] = '0';
                        displayMaze();
                    }
                    branchHolderInt = mazeTraversal(y, x + 1, 'e');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y, x + 1] = '0';
                        displayMaze();
                    }
                    branchHolderInt = mazeTraversal(y - 1, x, 's');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y - 1, x] = '0';
                        displayMaze();
                    }
                    return 0;
                default:
                    branchHolderInt = mazeTraversal(y + 1, x, 'n');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y + 1, x] = '0';
                        displayMaze();
                    }
                    branchHolderInt = mazeTraversal(y, x + 1, 'e');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y, x + 1] = '0';
                        displayMaze();
                    }
                    branchHolderInt = mazeTraversal(y - 1, x, 's');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y - 1, x] = '0';
                        displayMaze();
                    }
                    branchHolderInt = mazeTraversal(y, x - 1, 'w');
                    if (branchHolderInt == 1)
                    {
                        return 1;
                    }
                    if (branchHolderInt == 0)
                    {
                        maze[y, x - 1] = '0';
                        displayMaze();
                    }
                    return 0;
            }
        }
    }
}
