using System;

namespace Life
{
    /// <summary>
    /// Contains methods used to run Conway's Game of Life
    /// </summary>
    /// <author>
    /// STUDENT ID : N10370943
    /// </author>
    class Conway {
            
            //getter and setter for latest cell generation array
            private bool[,] Grid { get; set; }


            private Conway(bool[,] firstGen) {
                this.Grid = firstGen;
            }


            /// <summary>
            /// Returns the number of living neighbours adjacent to a given cell position
            /// </summary>
            /// <param name="row">The cell's row</param>
            /// <param name="col">The cell's column</param>
            /// <returns>The number of adjacent living neighbours</returns>
            private int CountNeighbours(int row,
                int col) {

                int neighbors = 0;
                int maxRow = Grid.GetLength(0);
                int maxCol = Grid.GetLength(1);

                //row for loop
                for (int r = row - 1; r <= row + 1; r++) {
                    //column for loop
                    for (int c = col - 1; c <= col + 1; c++) {
                        if (r == row && c == col) {
                            continue;
                        }
                        else if (r < 0 || r == maxRow) {
                            continue;
                        }
                        else if (c < 0 || c == maxCol) {
                            continue;
                        }
                        else if (this.Grid[r,c] == true){
                            neighbors++;
                        }
                    }
                }
                //return number of live cells surrounding the specified cell
                return neighbors;
            }


            /// <summary>
            /// Returns an updated grid after progressing the rules of the Game of Life
            /// </summary>
            /// <returns>A new grid which has been updated by one time-step</returns>
            private bool[,] UpdateGrid() {

                bool[,] nextGen = new bool[Grid.GetLength(0), Grid.GetLength(1)];
                //row for loop
                for (int row = 0; row < nextGen.GetLength(0); row++) {
                    //column for loop
                    for (int col = 0; col < nextGen.GetLength(1); col++) {
                        int neighbors = CountNeighbours(row, col);
                        //live cell with fewer than two live neighbors dies, as if by underpopulation.
                        if (Grid[row, col] == true && neighbors < 2) {
                            nextGen[row, col] = false;
                        }
                        //live cell with two or three live neighbors lives on to the next generation.
                        else if (Grid[row, col] == true && (neighbors == 2 || neighbors == 3)) {
                            nextGen[row, col] = true;
                        }
                        //live cell with more than three live neighbors dies, as if by overpopulation.
                        else if (Grid[row, col] == true && neighbors > 3) {
                            nextGen[row, col] = false;
                        }
                        //dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
                        else if (Grid[row, col] == false && neighbors == 3) {
                            nextGen[row, col] = true;
                        }
                        else
                        {
                            // anything else is copied across
                            nextGen[row, col] = Grid[row, col];
                        }
                    }
                }
                //returning next generation array
                return nextGen;
            }


            /// <summary>
            /// Writes the given name grid to standard output
            /// </summary>
            /// <param name="grid">The grid to draw to standard output</param>
            private static void DrawGrid(bool[,] grid) {

                //row for loop
                for (int i = 0; i < grid.GetLength(0); i++) {
                    //column for loop
                    for (int j = 0; j < grid.GetLength(1); j++) {
                        //print "#" if value is true, "." if false
                        Console.Write(grid[i, j] ? "#" : ".");
                    }
                    Console.WriteLine();
                }
            }


            /// <summary>
            /// Returns a new grid for Conway's Game of life using the given dimensions
            /// </summary>
            /// <param name="rows">number of rows for the game of life array</param>
            /// <param name="cols">number of columns for the game of life array</param>
            /// <returns></returns>
            private static bool[,] MakeGrid(int rows,
                    int cols) {
                    
                    //rng Random class
                    Random rng = new Random();
                    //random seed array
                    bool[,] firstGen = new bool[rows, cols];
                    //row for loop
                    for (int i = 0; i < firstGen.GetLength(0); i++) {
                        //column for loop
                        for (int j = 0; j < firstGen.GetLength(1); j++) {
                            //assign true or false to array pos
                            firstGen[i, j] = rng.Next(0, 2) > 0;
                        }
                    }
                    //return boolean array with random values
                    return firstGen;
                }

            /// <summary>
            /// Runs the game of life according to its rules and continuously refreshes the result
            /// </summary>
            public static void Main() {
                
                //number of rows in the array
                int rows = 50;
                //number of columns in the array
                int cols = 100;
                //number of generations to simulate
                int gen = 100;
                //time waiting until next generation in milliseconds
                const int UPDATE_TIME = 200;

                //create first generation of cells
                bool[,] firstGen = MakeGrid(rows, cols);
                Conway life = new Conway(firstGen);

                Console.WriteLine("Number of total generations: {0}\n", gen);
                //display first generation
                DrawGrid(firstGen);

                //loop the simulation for "gen" number of times
                for (int i = 1; i <= gen; i++) {

                    //set cursor position correctly so it doesn't overwrite the first message
                    Console.SetCursorPosition(0, 1);
                    
                    //increment generation number
                    Console.WriteLine("Generation Number: " + i);
                    
                    //update grid
                    bool[,] generation = life.UpdateGrid();
                    
                    //display grid
                    DrawGrid(generation);
                    
                    //store grid so next generation can be processed
                    life.Grid = generation;

                    //wait for specified time until next generation
                    System.Threading.Thread.Sleep(UPDATE_TIME);

                }
            }
        }
    }