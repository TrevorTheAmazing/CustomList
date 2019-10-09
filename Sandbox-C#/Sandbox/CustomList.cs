﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class CustomList<T>
    {
        //memb var
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

        //constructor
        public CustomList()
        {
            capacity = 0;
            items = new T[capacity];
        }

        //memb meth
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
            bool success = false;

            if ((index + 1) >= capacity)
            {
                IncreaseCapacity();
            }

            tempItems = new T[capacity];

            for (int i = 0; i<items.Length; i++)
            {
                tempItems[i] = items[i];
            }

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

        //public void Delete(T itemToDelete)
        public void Delete(T value)
        {//imitate Remove()
            int tempIndex = -1;
            tempItems = items;

            for (int i = 0; i < this.Count; i++)
            {
                if (value.Equals(tempItems[i]))
                {
                    tempIndex = i;
                    break;
                }
            }

            //if a matching value was found...
            if (tempIndex>=0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (i == tempIndex)
                    {
                        //count--;
                        //continue;
                        for (int j = tempIndex; j < count; j++)
                        {
                            items[j] = tempItems[j + 1];
                        }
                        
                    }
                    else
                    {
                        items[i] = tempItems[i];
                    }
                }
                count--;
            }
        }
    }
}
