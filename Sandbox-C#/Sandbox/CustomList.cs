using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class CustomList<T>
    {
        //memb var
        //array of items
        private T[] items;
        private T[] tempItems;
        private int capacity;

        public CustomList()
        {
            capacity = 1;
            items = new T[capacity];
        }

        private void IncreaseCapacity()
        {
            tempItems = new T[capacity + 1];
            
            for (int i = 0; i<items.Length; i++)
            {
                tempItems[i] = items[i];
            }

            items = tempItems;

        }

        public void Add(T itemToAdd, int index)
        {
            //assign tempCap to array.capacity
            //reassign items to a new array(tempCap+1)

            
             //increase capacity
             IncreaseCapacity();

             if (index != (capacity-1))
             {
                 items.Prepend(itemToAdd);
             }
             else
             {
                 items.Append(itemToAdd);
             }

        }

        public void Add(T itemToAdd)
        {
            //If an index is not specified, add it to the end of the array.
            Add(itemToAdd, capacity);
        }

    }
}
