using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace test {
        class LifeGame {
            public bool[,] Environment { get; set; }
            public int Generations { get; set; }

            public LifeGame(bool[,] startingEnvironment) {
                this.Environment = startingEnvironment;
                Generations = 0;
            }

            public LifeGame(int rows,
                int cols) {
                Environment = new bool[rows, cols];
                Generations = 0;
            }

            public int FindNeighborCount(LifeGame generation,
                int row,
                int col) {
                int neighbours = 0;


                // Above
                if (generation.Environment[row - 1, col]) {
                    neighbours++;
                }

                // Below
                if (generation.Environment[row + 1, col]) {
                    neighbours++;
                }

                // Left
                if (generation.Environment[row, col - 1]) {
                    neighbours++;
                }


                // Right
                if (generation.Environment[row, col + 1]) {
                    neighbours++;
                }

                // Diagonal Above and Left
                if (generation.Environment[row - 1, col - 1]) {
                    neighbours++;
                }

                // Diagonal Below and Right
                if (generation.Environment[row + 1, col - 1]) {
                    neighbours++;
                }

                // Diagonal Above and Right
                if (generation.Environment[row - 1, col + 1]) {
                    neighbours++;
                }

                // Diagonal Below and Left
                if (generation.Environment[row + 1, col + 1]) {
                    neighbours++;
                }

                return neighbours;
            }

            public bool[,] FindNextGeneration(LifeGame generation) {
                bool[,] nextGen = new bool[generation.Environment.GetLength(0), generation.Environment.GetLength(1)];
                for (int row = 0; row < nextGen.GetLength(0); row++) {
                    for (int col = 0; col < nextGen.GetLength(1); col++) {
                        int neighbours = generation.FindNeighborCount(generation, row, col);

                        if (generation.Environment[row, col] == true) {
                            if (neighbours < 2 || neighbours > 3) {
                                nextGen[row, col] = false;
                            }
                            else if (neighbours == 2 || neighbours == 3) {
                                nextGen[row, col] = true;
                            }
                        }
                        else {
                            if (neighbours == 3) {
                                nextGen[row, col] = true;
                            }
                        }
                    }
                }

                return nextGen;
            }

            public static void Print2DArray(bool[,] matrix) {
                for (int i = 0; i < matrix.GetLength(0); i++) {
                    for (int j = 0; j < matrix.GetLength(1); j++) {
                        Console.Write(matrix[i, j] ? "#" : ".");
                    }

                    Console.WriteLine();
                }

                Console.SetCursorPosition(0, Console.WindowTop);
            }

            public static bool[,] CreateRandom2dArray(Random rng,
                int minValue,
                int maxValue) {
                //int row = rng.Next(3, 40);
                //int col = rng.Next(3, 40);
                int row = 40;
                int col = 90;
                bool[,] start = new bool[row, col];
                for (int i = 0; i < row; i++) {
                    for (int j = 0; j < col; j++) {
                        start[i, j] = ((rng.Next(2) == 0) ? false : true);
                    }
                }

                return start;
            }

            static void Main(string[] args) {

                Random rng = new Random();
                bool[,] startingEnv = CreateRandom2dArray(rng, 0, 2);
                LifeGame life = new LifeGame(startingEnv);
                int gen = rng.Next(1, int.MaxValue);
                Console.WriteLine("Number of generations: " + gen);

                for (int i = 0; i < gen; i++) {
                    //System.Threading.Thread.Sleep(500);
                    Console.WriteLine("Generation Number: " + i);
                    bool[,] generation = life.FindNextGeneration(life);
                    Print2DArray(generation);
                    life.Environment = generation;
                    life.Generations = life.Generations++;
                    Console.WriteLine("\n");
                }
            }
        }
    }