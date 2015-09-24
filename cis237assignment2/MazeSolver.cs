using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
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
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;
            //display the maze before it is solved
            displayMaze();
            //start the maze solver at the starting point;
            mazeTraversal(yStart, xStart, 'd');
            Console.WriteLine("Done! Press any key to continue ");
            Console.ReadKey();

            //Do work needed to use mazeTraversal recursive call and solve the maze.
        }

        /// <summary>
        /// displays the maze in the console
        /// </summary>
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
        /// Solves a maze
        /// compass rose:
        ///     n
        ///     ↑ 
        /// w ←   → e
        ///     ↓
        ///     s
        /// n = y + 1
        /// s = y - 1
        /// e = x + 1
        /// w = x - 1
        /// return values:
        /// -1 = hit a wall
        ///  0 = dead end
        ///  1 = reached the end
        /// </summary>
        private int mazeTraversal(int y, int x, char lastMove)
        {
            int branchHolderInt;
            //if at a wall
            if (maze[y, x] == '#')
            {
                return -1;
            }
            //show that the solver has been at current cordenents
            maze[y, x] = 'x';
            displayMaze();
            //if at the end
            if (x == 0 || x == maze.GetLength(1) - 1 || y == 0 || y == maze.GetLength(0) - 1)
            {
                return 1;
            }
            //switch prevents backtracking without knowing its backtracking;
            switch(lastMove)
            {
                //South
                //each case trys a branch for each of the directions besides its oppisate direction
                case 's':
                    //trys east branch
                    branchHolderInt = mazeTraversal(y, x + 1, 'e');
                    if(branchHolderInt == 1)
                    {
                        return 1;
                    }
                    //if dead end
                    if(branchHolderInt == 0)
                    {
                        //backtrack
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
                    //none of branches worked backtrack
                    return 0;

                //West
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

                //North
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

                //East
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

                //only for the start
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
