using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Starting Coordinates.
            /// </summary>
            const int X_START = 1;
            const int Y_START = 1;

            ///<summary>
            /// The first maze that needs to be solved.
            /// </summary>
            char[,] maze1 = 
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '·', '·', '·', '#', '·', '·', '·', '·', '·', '·', '#' },
            { '#', '·', '#', '·', '#', '·', '#', '#', '#', '#', '·', '#' },
            { '#', '#', '#', '·', '#', '·', '·', '·', '·', '#', '·', '#' },
            { '#', '·', '·', '·', '·', '#', '#', '#', '·', '#', '·', '·' },
            { '#', '#', '#', '#', '·', '#', '·', '#', '·', '#', '·', '#' },
            { '#', '·', '·', '#', '·', '#', '·', '#', '·', '#', '·', '#' },
            { '#', '#', '·', '#', '·', '#', '·', '#', '·', '#', '·', '#' },
            { '#', '·', '·', '·', '·', '·', '·', '·', '·', '#', '·', '#' },
            { '#', '#', '#', '#', '#', '#', '·', '#', '#', '#', '·', '#' },
            { '#', '·', '·', '·', '·', '·', '·', '#', '·', '·', '·', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

            /// <summary>
            /// Create a new instance of a mazeSolver.
            /// </summary>
            MazeSolver mazeSolver = new MazeSolver();

            /// <summary>
            /// Tell the instance to solve the first maze with the passed maze, and start coordinates.
            /// Cloned to prevent maze 2 from being pre-solved
            /// </summary>
            mazeSolver.SolveMaze((char[,])maze1.Clone(), X_START, Y_START);

            //Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(maze1);

            //Solve the transposed maze.
            mazeSolver.SolveMaze((char[,])maze2.Clone(), X_START, Y_START);

        }

        /// <summary>
        /// transposes any char array including non square ones
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns></returns>
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            char[,] transposedMaze = new char[mazeToTranspose.GetLength(1), mazeToTranspose.GetLength(0)];
            for (int i = 0; i < mazeToTranspose.GetLength(0); i++)
            {
                for (int k = 0; k < mazeToTranspose.GetLength(1); k++)
                {
                    transposedMaze[k, i] = mazeToTranspose[i, k];
                }
            }
            return transposedMaze;
        }
    }
}
