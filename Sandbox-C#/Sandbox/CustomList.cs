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
        public T this[int i]
        {
            get { return items[i]; }
            set { items[i] = value; }
        }
        private int capacity;
        public int Capacity
        {
            get => GetCapacity();
        }
        private int count;
        public int Count
        {
            get => GetItemCount();
        }

        public CustomList()
        {
            capacity = 0;
            //capacity = 1;
            items = new T[capacity];
        }

        public CustomList(int length)
        {
            //if (length==0)
            //{

            //}
            //else
            //{

            //}
            //items = new T[length];
            //CustomList<int> testCustomList = new CustomList<int>();
        }

        private void IncreaseCapacity()
        {
            if (capacity == 0)
            {
                tempItems = new T[1];
            }
            else
            {
                tempItems = new T[capacity * 2];
            }
            
            
            for (int i = 0; i<items.Length; i++)
            {
                tempItems[i] = items[i];
            }

            items = tempItems;
            capacity = items.Length;

        }


        public void Add(T itemToAdd, int index)
        {
            //if ((count+1) == capacity)
            //if ((index + 1) == capacity)
            if ((index + 1) >= capacity)
            {
                IncreaseCapacity();
            }

            tempItems = new T[capacity];

            for (int i = 0; i<items.Length; i++)
            {
                tempItems[i] = items[i];
            }

            //tempItems = new T[items.Length + 1];

            bool success = false;

            try
            {
                if (index == 0)
                {
                    tempItems.Prepend<T>(itemToAdd);
                }
                else
                {
                    tempItems.Append<T>(itemToAdd);
                }
                tempItems[index] = itemToAdd;
                this[index] = tempItems[index];
                success = true;
            }
            catch (/*ArgumentOutOfRangeException,*/ IndexOutOfRangeException)
            {
                //increase capacity
                IncreaseCapacity();
            }
            finally
            {
                if (!success)
                {
                    Add(itemToAdd, index);
                }
                else
                {
                    items = tempItems;
                    count++;

                }
            }
        }


        public void Add(T itemToAdd)
        {
            //If an index is not specified, add it to the end of the array.
            //Add(itemToAdd, items.Length);
            Add(itemToAdd, count);
        }

        private int GetCapacity()
        {
            return capacity;
        }

        private int GetItemCount()
        {
            return count;
        }

    }
}
