using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Contains methods enabling the area calculator
/// </summary>
/// <author>Sun Wook Kim - n10370943</author>
namespace pst1 {
    class Program {

        /// <summary>
        /// Runs the area calculator as a menu-driven program
        /// </summary>
        static void Main(string[] args) {
            int choice = 0;

            /// <summary>
            /// 4 different options available to the user in the main menu
            /// </summary>
            const int CIRCLE_OPTION = 1;
            const int RECTANGLE_OPTION = 2;
            const int POLYGON_OPTION = 3;
            const int QUIT_OPTION= 4;

            // Display welcome message
            Console.WriteLine("Wlecome to the area calculator");
            do{
               
                // Display main menu with 4 options available to 
                Console.WriteLine("\nMain menu: \n\t1. Circle \n\t2. Rectangle \n\t3. Regular polygon \n\t4. Quit");
                
                // Get user's chosen option as "1", "2", "3" or "4"
                choice = (int)GetUserNum(
                    prompt: "Enter 1 ~ 4",
                    min: 0,
                    max: 4,
                    wholeNumber: true);
                // Display chosen menu to user and display calculated area
                switch (choice) {
                    case CIRCLE_OPTION:
                        CircleMenu();
                        break;
                    case RECTANGLE_OPTION:
                        RectangleMenu();
                        break;
                    case POLYGON_OPTION:
                        PolygonMenu();
                        break;
                    case QUIT_OPTION:
                        // Await user exit
                        Console.WriteLine("Press enter to quit the area calculator");
                        Console.ReadLine();
                        break;
                    default:
                        // Ask user to re-enter value from the available options
                        Console.WriteLine("Please enter 1,2,3 or 4");
                        break;
                }
            }
            // Terminate program if user enters 4
            while(choice!=4);
        }


        /// <summary>
        /// Gets a valid radius value from the user and displays circle's area given the radius
        /// </summary>
        public static void CircleMenu() {
            // Ask user for input for radius
            Console.WriteLine("\t-------Circle Area Calculator-------");
            double radius = GetUserNum(
                prompt: "\nPlease enter radius",
                min: 0);
            // Display circle area
            Console.WriteLine("\nCircle with {0} radius has the area: " +Math.Round(CircleCalculation(radius), 2), radius);
        }

        /// <summary>
        /// Gets a valid length and width value from the user and displays rectangle's area given the values
        /// </summary>
        public static void RectangleMenu() {
            // Ask user for input for length
            Console.WriteLine("\t-------Rectangle Area Calculator-------");
            double length = GetUserNum(
                prompt: "\nPlease enter length",
                min: 0);
            // Ask user for input for width
            double width = GetUserNum(
                prompt: "Please enter width",
                min: 0);
            // Aisplay rectangle area
            Console.WriteLine("\nRectangle with {0} length and {1} width has the area: " + Math.Round(RectangleCalculation(length, width)), length, width);
        }

        /// <summary>
        /// Gets a valid number of sides and side length value from the user and displays polygon's area given the values
        /// </summary>
        public static void PolygonMenu() {
            const int MIN_POLYGON_SIDES = 3;
            // Ask user for input for number of sides
            Console.WriteLine("\t-------Regular Polygon Area Calculator-------");
            int numSides = (int) GetUserNum(
                prompt: "\nPlease enter number of sides",
                min: MIN_POLYGON_SIDES - 1,
                wholeNumber: true);
            // Ask user for input for length
            double length = GetUserNum(
                prompt: "Please enter length",
                min: 0);
            // Display polygon area
            Console.WriteLine("\nRegular Polygon with {0} sides and {1} side length has the area: " +Math.Round(PolygonCalculation(numSides, length)), numSides, length);
        }

        /// <summary>
        /// Calculates circle's area with given radius
        /// </summary>
        /// <returns>Circle area</returns>
        public static double CircleCalculation(double radius) {
            // Formula for the area of a circle: pi*radius^2
            return (Math.PI * radius * radius);
        }

        /// <summary>
        /// Calculates rectangle's area given length and width
        /// </summary>
        /// <returns>Rectangle area</returns>
        public static double RectangleCalculation(double length,
            double width) {
            // Formula for the area of a rectangle: length*width
            return (length * width);
        }

        /// <summary>
        /// Calculates polygon's area given number of sides and side length
        /// </summary>
        /// <returns>Polygon area</returns>
        public static double PolygonCalculation(int numSides,
            double length) {
            // Formula for the area of a polygon: (number_of_sides*side_length^2)/(4*Tan(pi/number_of_sides))
            return (numSides * Math.Pow(length, 2)) / (4 * (Math.Tan(Math.PI / numSides)));
        }

        /// <summary>
        /// Validate user input
        /// </summary>
        /// <param name="prompt">Display message</param>
        /// <param name="min">Minimum value the user may input</param>
        /// <param name="max">Maximum value the user may input</param>
        /// <param name="wholeNumber">Whether or not the value must be a whole number</param>
        static double GetUserNum(string prompt = "",
                    double min = double.Epsilon,
                    double max = double.MaxValue,
                    bool wholeNumber = false,
                    bool valid = false
                    ){
            double result = 0;
            // Repeat until the user enters a valid number
            do{
                // Display instructions
                Console.WriteLine(prompt);

                // If the user enters non-numeric data
                if (!double.TryParse(Console.ReadLine(), out result)){
                    Console.WriteLine("Input must be numeric!");
                }

                // If the user enters a number lower than the minimum value
                else if(result <= min){
                    Console.WriteLine("Input must be above {0}", min);
                }

                // If the user enters a number larger than the maximum value
                else if(result>max){
                    Console.WriteLine("Input must be below {0}", max);
                }

                // If the user enters a number which is not a whole number
                else if (wholeNumber == true) {
                    if ((result % 1) > 0) {
                        Console.WriteLine("Input must be a whole number");
                    }
                    else {
                        break;
                    }
                }
                // If the user enters a valid number
                else {
                    valid = true;
                }
            } while(!valid);
            return result;
        }
    }
}