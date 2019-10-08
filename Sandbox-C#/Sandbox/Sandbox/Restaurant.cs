using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    class Restaurant
    {
        // member variables (HAS A)
        public string name;
        public List<string> foodOptions;
        public List<Employee> staffMembers;

        // constructor (SPAWNER)
        public Restaurant(string name)
        {
            this.name = name;
            foodOptions = new List<string>();
            staffMembers = new List<Employee>();
        }

        // member methods (CAN DO)
        public void ChangeName()
        {
            Console.WriteLine("What would you like to change the name to?");
            string newName = Console.ReadLine();
            name = newName;
        }
    }
}
