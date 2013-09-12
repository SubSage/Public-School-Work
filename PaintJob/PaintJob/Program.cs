using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Luis Martinez
 * 20185073
 * CSCI 3328
 * Assingment 2
 * Due 9/11/2013
 * Turned in 9/10/13
 */
namespace PaintJob
{
    class Program
    {
        static void Main(string[] args)
        {
            InputHandler reader = new InputHandler();
            MathHandler math = new MathHandler();
            DisplayHandler display = new DisplayHandler();

            display.ShowIntro();
            display.SetNameNumber(reader);
            
            math.SetPrice(reader);

            while (math.update(reader)){ }

            display.ShowOuttro(math);

            Console.ReadLine();

            //Not gonna lie, I feel like I'm showing off with my modular approach :I
            //But I liked it. It was fun putting this all as it is. And it works well!
        }
    }

    


    public class MathHandler
    {
        private int walls = 0;
        private int sqft = 0;
        private int gallons = 0;
        private double price = 0;
        private double paintCost = 0;
        private double laborCost = 0;
        private double subtotal = 0;
        private double total = 0;
        private double tax = 0;
        
        //Remember that one gallon will cover 450 ft.

        //Takes two numbers, adds their multiple to the total sqft and returns true if all went well. Returns false if it recieved negative length
        public Boolean update(InputHandler reader)
        {

            Console.WriteLine("=================");
            Console.WriteLine("Enter Length and Height for Wall #: {0}", walls);

            double a = Convert.ToDouble(reader.Get("Enter Length of the Wall (0 to quit): "));
            if (a == 0)
            {
                return false;
            }

            walls++;
            sqft += Convert.ToInt32(a * Convert.ToDouble(reader.Get("Enter Heigth of the Wall: ")));
            return true;
        }

        public double GetPaintCost()
        {
            return paintCost;
        }

        public double GetLaborCost()
        {
            return laborCost;
        }

        public double GetSubTotal()
        {
            return subtotal;
        }

        public double GetTotal()
        {
            return total;
        }

        public double GetTax()
        {
            return tax;
        }

        public int GetWalls()
        {
            return walls;
        }

        public int GetGallons()
        {
            return gallons;
        }

        public double GetPrice()
        {
            return price;
        }

        public int GetSqft()
        {
            return sqft;
        }


        public void SetPrice(InputHandler reader)
        {
            price = Convert.ToDouble(reader.Get("Enter Price of the Paint per Gallon: "));
        }

        internal void Tally()
        {
            gallons = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sqft/450F)));
            paintCost = gallons * price;
            laborCost = sqft * .6;
            subtotal = laborCost + paintCost;
            tax = subtotal * .0825;
            total = subtotal + tax;
        }
    }


    public class InputHandler
    {
        public string Get(string output)
        {
            Console.Write(output);
            return Console.ReadLine();
        }

        

    }


    public class DisplayHandler
    {
        private string name = "";
        private string number = "";
        
        public void ShowIntro()
        {
            Console.WriteLine("This Program will Calculate Cost of Painting inside walls of a house.\n"
                            + "You need to Enter the cost of a gallon of paint,\n"
                            + "   and length and height of each wall.\n"
                            + "The program will calculate number of gallons of paint needed using\n"
                            + "   one gal of paint for 450 sqfeet of wall space.\n"
                            + "Labor cost is a constant of 0.60 cents per sqft.\n");
        }

        public void ShowOuttro(MathHandler math)
        {
            math.Tally();
            Console.WriteLine("\nCSharp Painting Company\n"
                            + "UTPA CSCI 3328\n"
                            + "Edinburg, TX 78541\n\n"
                            + "==================\n\n\n"
                            + "Date of this Quote: " + DateTime.Now.ToString() + "\n"
                            + "Name of the Customer: " + name + "\n"
                            + "Customer Telephone  : " + number+ "\n"
                            + "==================\n\n"
                            + "Number of Walls--------------------> " + math.GetWalls() + "\n"
                            + "Total SqFt-------------------------> " + math.GetSqft() + "\n"
                            + "Number of Gallons Paint Needed-----> " + math.GetGallons() + "\n"
                            + "Price of Paint Per Gallon----------> " + math.GetPrice().ToString("##,###,##0.00").PadLeft(10) + "\n"
                            + "Cost of Paint----------------------> " + math.GetPaintCost().ToString("##,###,##0.00").PadLeft(10) + "\n"
                            + "Cost of Labor----------------------> " + math.GetLaborCost().ToString("##,###,##0.00").PadLeft(10) + "\n"
                            + "Sub Total--------------------------> " + math.GetSubTotal().ToString("##,###,##0.00").PadLeft(10) + "\n"
                            + "Sales Tax--------------------------> " + math.GetTax().ToString("##,###,##0.00").PadLeft(10) + "\n\n"
                            + "                                  -------------"  + "\n"
                            + "Grand Total------------------------> " + math.GetTotal().ToString("##,###,##0.00").PadLeft(10));


        }

        public void SetNameNumber(InputHandler reader)
        {
            name = reader.Get("Enter Name of the Customer: ");
            number = reader.Get("Enter Telephone Number of the Customer: ");
        }
    }
}
