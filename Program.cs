using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHConsoleApplication
{
    // class to represent data for a person
    class PersonData
    {
        // data members for the class  
        public String firstName;    // to store the first name
        public String lastName;     // to store the last name
        public String address;      // to store the address
        public String city;         // to store the city
        public String state;        // to store the state
        public int age;             // to storethe age

        // all the fields are kept public for easier access
        // the access modifiers can be changed to private, and getter methods can be added

        public PersonData(String firstName, String lastName,
                            String address, String city, String state, int age)
        {
            this.address = address;
            this.age = age;
            this.city = city;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.state = state;
        }

        // print method to print the data in one line
        public void print()
        {
            Console.WriteLine(firstName + " " + lastName + "," +
                                address + "," +
                                city + "," +
                                state + "," +
                                age);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            /// array to store the person data
            PersonData[] data = new PersonData[100];

            /// to count the number of person data stored
            int index = 0;

            Console.WriteLine("1.Input the Firstname , LastName, Address, State , Age:" + "\n" +"Press any key after inputing all the data \n");
           
            try
            { 

            /// do while loop to read in data from the standard input
            do
            {
                /// reading Input data from Console
                String line = Console.ReadLine();

                /// break the loop if an empty line is read
                if (line.Length == 0)
                {
                    break;
                }

                /// set of separators, used to split the data into fields
                char[] seps = { ',' };


                /// storing all the fileds into this string array
                String[] fields = line.Split(seps);


                /// adding a new data item into the data array, using the fields read from a line
                data[index++] = new PersonData(fields[0].Substring(1, fields[0].Length - 2),
                                                fields[1].Substring(1, fields[1].Length - 2),
                                                fields[2].Substring(1, fields[2].Length - 2),
                                                fields[3].Substring(1, fields[3].Length - 2),
                                                fields[4].Substring(1, fields[4].Length - 2),
                                                Convert.ToInt32(fields[5].Substring(1, fields[5].Length - 2))
                                                );
            }
            while (true);
           
            Console.WriteLine("2.Input Data Sorted by Last Name then First Name where the occupant(s) is older than 18: \n");

            /// bubble sort is a stable sort technique, which means original relative order is maintained
            /// so, we first sort by first name, then last name
            /// eventually, the data is then sorted by last name and then first name

            /// sorting by first name first
            /// bubble sort technique is used
            for (int i = 0; i < index; i++)
            {
                for (int j = 0; j < index - 1; j++)
                {
                    if (data[j].firstName.CompareTo(data[j + 1].firstName) > 0)
                    {
                        PersonData temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }

            /// sorting by last name then 
            for (int i = 0; i < index; i++)
            {
                for (int j = 0; j < index - 1; j++)
                {
                    if (data[j].lastName.CompareTo(data[j + 1].lastName) > 0)
                    {
                        PersonData temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }

            /// finally, outputting the data which has age >= 18
            for (int i = 0; i < index; i++)
            {
                if (data[i].age >= 18)
                    data[i].print();
            }

                Console.WriteLine("\nPress any key to exit");
                Console.ReadLine();
        }

            ///Handling Exception case
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                Console.WriteLine("\nPress any key to exit");
                Console.ReadLine();
            }

        }
    }
}
