// Program 1B
// CIS 200-01
// Fall 2016
// Due: 10/17/2016
// C8560

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
                       // linq query results are displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("John Smith", "123 Any St.", "Apt. 45",
                "Louisville", "KY", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", "",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("John Rolfe", "3142 Drivy Drive", "Apt. 9",
                "Springfield", "IL", 11111); // Test Address 5
            Address a6 = new Address("Alex Anderson", "2354 IDC Road", "Apt. 10",
                "Bucket", "LA", 22222); // Test Address 6
            Address a7 = new Address("Ricky Robinson", "7465 Nowhere BLVD", "Suit 54",
                "Glendale", "FL", 33333); // Test Address 7
            Address a8 = new Address("Bob Lob Law", "8765 Don't Care Parkway", "Apt. 1",
                "dat boi", "NY", 45445);

            Letter letter1 = new Letter(a1, a2, 3.95M); // Letter test object
            Letter letter2 = new Letter(a2, a3, 4.95M); // Test Letter 2
            Letter letter3 = new Letter(a3, a4, 5.95M); // Test Letter 3
            Letter letter4 = new Letter(a4, a5, 6.95M); // Test Letter 4

            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test object
            GroundPackage gp2 = new GroundPackage(a4, a5, 10, 10, 10, 10); // Test GroundPackage 2
            GroundPackage gp3 = new GroundPackage(a5, a6, 11, 11, 11, 11); // Test GroundPackage 3
            GroundPackage gp4 = new GroundPackage(a6, a7, 12, 12, 12, 12); // Test GroundPackage 4

            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a5, a6, 13, 13, 13,
                13, 7.95M); // Test NextDayAirPackage 2
            NextDayAirPackage ndap3 = new NextDayAirPackage(a6, a7, 10, 20, 40,
                80, 8.95M); // Test NextDayAirPackage 3
            NextDayAirPackage ndap4 = new NextDayAirPackage(a7, a8, 80, 90, 100,
                200, 9.95M); // Test NextDayAirPackage 4

            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a8, a1, 14, 14, 14,
                14, TwoDayAirPackage.Delivery.Early); // Test TwoDayAirPackage 2
            TwoDayAirPackage tdap3 = new TwoDayAirPackage(a7, a2, 16, 14, 16,
                14, TwoDayAirPackage.Delivery.Saver); // Test TwoDayAirPackage 3
            TwoDayAirPackage tdap4 = new TwoDayAirPackage(a6, a3, 40, 56, 67,
                31, TwoDayAirPackage.Delivery.Early);


            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            // Populate list
            parcels.Add(letter1);
            parcels.Add(letter2);
            parcels.Add(letter3);
            parcels.Add(letter4);
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(gp3);
            parcels.Add(gp4);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(ndap3);
            parcels.Add(ndap4);
            parcels.Add(tdap1);
            parcels.Add(tdap2);
            parcels.Add(tdap3);
            parcels.Add(tdap4);

             Console.WriteLine("Original List\n");
             
             foreach (Parcel p in parcels)
             {
                 Console.WriteLine(p);
                 Console.WriteLine("===============");
             } 
            Pause();

            // Select all Parcels and order by destination zip (descending)
            Console.WriteLine("Descending Destination Zip\n");

            var descendingZip =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;

            // display descendingZip
            foreach (Parcel p in descendingZip)
            {
                Console.WriteLine(p.DestinationAddress.Zip);
                Console.WriteLine();
            }
            Pause();

            // Select all Parcels and order by cost (ascending)
            Console.WriteLine("Ascending Costs\n");

            var ascendingCosts =
                from p in parcels
                orderby p.CalcCost()
                select p;

            // display ascendingCosts
            foreach (Parcel p in ascendingCosts)
            {
                Console.WriteLine(p.CalcCost().ToString("C2"));
                Console.WriteLine();
            }
            Pause();

            // Select all Parcels and order by Parcel type (ascending) and then cost (descending)
            Console.WriteLine("Ascending Type");
            Console.WriteLine("Descending Cost\n");

            var typeThenCost =
                from p in parcels
                orderby p.GetType().ToString(), p.CalcCost() descending
                select p;

            // display typeThenCost
            foreach (Parcel p in typeThenCost)
            {
                Console.WriteLine(p.GetType().ToString());
                Console.WriteLine(p.CalcCost().ToString("C2"));
                Console.WriteLine();
            }
            Pause();

            // Select all AirPackage objects that are heavy and order by weight (descending)
            Console.WriteLine("Heavy Air Packages Sorted By Weight\n");

            var heavyAirPackageByWeight =
                from p in parcels
                where p is AirPackage
                let apkg = (AirPackage)p // downcaste to AirPackage
                where apkg.IsHeavy() // gain access to AirPackage methods
                orderby apkg.Weight
                select apkg;

            // display heavyAirPackageByWeight
            foreach (AirPackage apkg in heavyAirPackageByWeight)
            {
                Console.WriteLine(apkg.GetType().ToString());
                Console.WriteLine(apkg.Weight);
                Console.WriteLine();
            }
       }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
