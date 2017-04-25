using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waist_to_Height_Ratio {
    /// <summary>
    /// 
    /// Menu driven program which calculates a person's waist to height ratio and 
    /// their risk level of developing obesity repeatedly. Calculations are conducted 
    /// on the basis of on a person's waist, height and gender.
    /// 
    /// Author: Quintus Cardozo
    /// Student Number: n9703578
    /// March 2017
    /// 
    /// </summary>
    class Program {
        const double FEMALE_RATIO = 0.492;
        const double MALE_RATIO = 0.536;
        const double WAIST_LOWER_LIMIT = 60;
        const double HEIGHT_LOWER_LIMIT = 120;
        static void Main(string[] args) {
            Welcome();
            RunProgram();
        }

        static void Welcome() {
            Console.WriteLine("Welcome to Waist to Height Ration Calculator");
        }

        /// <summary>
        /// Calls all the methods and runs the program.
        /// 
        /// </summary>
        static void RunProgram() {
            double waist = WaistMeasurement();
            double height = HeightMeasurement();
            double waist_height_ratio = WaistHeightRatio(waist, height);
            int gender = GenderSelection();
            ObesityCheck(gender, waist_height_ratio);
            ExitOrRunAgain();
        }

        /// <summary>
        /// Reads user's waist input and checks if it is a number.
        /// 
        /// </summary>
        /// <returns>User's waist in cm</returns>
        static double WaistMeasurement() {
            bool number_check = false;
            string user_input = "";
            double waist_measurement = 0;

            while (number_check == false) {
                Console.Write("Enter waist measurement in cm: ");
                user_input = Console.ReadLine();

                if (double.TryParse(user_input, out waist_measurement)) {
                    if (waist_measurement >= WAIST_LOWER_LIMIT) {
                        number_check = true;
                    } else {
                        Console.WriteLine("Measurement must be at least 60cm \n");
                    }
                } else {
                    Console.WriteLine("Measurement must be at least 60cm \n");
                }
            }
            return waist_measurement;
        }

        /// <summary>
        /// Reads user's height input and checks if it is a number.
        /// 
        /// </summary>
        /// <returns>User's height in cm</returns>
        static double HeightMeasurement() {
            bool number_check = false;
            string user_input = "";
            double height_measurement = 0;

            while (number_check == false) {
                Console.Write("Enter height measurement in cm: ");
                user_input = Console.ReadLine();

                if (double.TryParse(user_input, out height_measurement)) {
                    if (height_measurement >= HEIGHT_LOWER_LIMIT) {
                        number_check = true;
                    } else {
                        Console.WriteLine("Measurement must be at least 120cm \n");
                    }
                } else {
                    Console.WriteLine("Measurement must be at least 120cm \n");
                }
            }
            return height_measurement;
        }

        /// <summary>
        /// Calculates user's waist to height ratio.
        /// 
        /// </summary>
        /// <param name="waist">User's waist in cm</param>
        /// <param name="height">Uers's height in cm</param>
        /// <returns>User's waist to height ratio</returns>
        static double WaistHeightRatio(double waist, double height) {
            double waist_height_ratio = waist / height; ;
            return Math.Round(waist_height_ratio, 3);
        }

        /// <summary>
        /// Reads user's gender input and checks if its either 1 or 2.
        /// 
        /// </summary>
        /// <returns>User's gender</returns>
        static int GenderSelection() {
            bool number_check = false;
            string user_input = "";
            int gender_selection = 0;

            while (number_check == false) {
                Console.WriteLine("\n Are you \n\t 1) Male \n\t 2)Female");
                Console.Write("\t Enter your option (1 or 2): ");
                user_input = Console.ReadLine();

                if (int.TryParse(user_input, out gender_selection)) {
                    if (gender_selection == 1) {
                        number_check = true;
                        gender_selection = 1;
                    } else if (gender_selection == 2) {
                        number_check = true;
                        gender_selection = 2;
                    } else {
                        Console.WriteLine("\n Invalid value. Enter either 1 or 2 \n");
                    }
                } else {
                    Console.WriteLine("\n Invalid value. Enter either 1 or 2 \n");
                }
            }
            return gender_selection;
        }

        /// <summary>
        /// Checks if user is obese or not by checking if their waist to height ratio 
        /// is greater than or less than the waist to height ratio of obesity 
        /// based on their gender.
        /// 
        /// </summary>
        /// <param name="gender">User's gender</param>
        /// <param name="waist_height_ratio">User's waist to height ration</param>
        static void ObesityCheck(int gender, double waist_height_ratio) {
            string high_risk = "you are at a high risk of obesity.";
            string low_risk = "you are at a low risk of obesity.";

            if (gender == 1) {
                if (waist_height_ratio >= MALE_RATIO) {
                    Console.WriteLine("\n Your waist to hieght ratio is {0} and {1} \n", waist_height_ratio, high_risk);
                } else {
                    Console.WriteLine("\n Your waist to hieght ratio is {0} and {1} \n", waist_height_ratio, low_risk);
                }
            } else if (gender == 2) {
                if (waist_height_ratio >= FEMALE_RATIO) {
                    Console.WriteLine("\n Your waist to hieght ratio is {0} and {1} \n", waist_height_ratio, high_risk);
                } else {
                    Console.WriteLine("\n Your waist to hieght ratio is {0} and {1} \n", waist_height_ratio, low_risk);
                }
            }
        }

        /// <summary>
        /// Runs the program again if the user enters "Y" or "y". 
        /// Any other input terminates the program gracefully.
        /// </summary>
        static void ExitOrRunAgain() {
            Console.Write("Do you want to run another calculation [Y/N]: ");
            string user_input = Console.ReadLine().ToLower();
            Console.WriteLine(); //Line break for better formatting

            if (user_input == "y") {
                RunProgram();
            } else {
                Console.Write("Press any key to exit ");
                Console.ReadKey();
            }
        }
    }
    }

