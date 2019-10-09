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
        public int Capacity
        {
            get => GetCapacity();
        }
        private int count;
        public int Count
        {
            get => GetItemCount();
        }
        public T this[int i]
        {
            get { return items[i]; }
            set { items[i] = value; }
        }


        public CustomList()
        {
            capacity = 0;
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
            tempItems = new T[capacity*2];
            
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
            tempItems = new T[items.Length+1];
            for (int i = 0; i<items.Length; i++)
            {
                tempItems[i] = items[i];
            }
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
                success = true;
            }
            catch (ArgumentOutOfRangeException)
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
                    //UpdateList();
                    items = tempItems;
                }
            }
        }

        private void UpdateList()
        {
            //int newListLength = items.Length;
            //for (int i = 0; i<items.Length; i++)
            //{
            //    if ()
            //}

        }

        public void Add(T itemToAdd)
        {
            //If an index is not specified, add it to the end of the array.
            Add(itemToAdd, items.Length);
        }

        private int GetCapacity()
        {
            return capacity;
        }

        private int GetItemCount()
        {
            return (items.Length);
        }

    }
}
