using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class CustomList<T> : IEnumerable
    {

        //memb var
        private T[] items;
        private T[] tempItems;
        public T this[int i]
        {
            //get { return items[i]; }
            get { return GetListIndex(i); }
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
            //capacity = 0;
            capacity = 1;
            items = new T[capacity];
        }

        //memb meth
        private void IncreaseCapacity()
        {
            tempItems = new T[capacity * 2];

            for (int i = 0; i<items.Length; i++)
            {
                tempItems[i] = items[i];
            }

            items = tempItems;
            capacity = items.Length;
        }

        public void Add(T itemToAdd, int index)
        {
            if ((index + 1) >= capacity)
            {
                IncreaseCapacity();
            }

            items[index] = itemToAdd;
            count++;
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

        public void Delete(T value)
        {
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

        public override string ToString()
        {
            string tempResult = "";
            for (int i = 0; i < count; i++)
            {
                tempResult += items[i].ToString();
            }
            //return base.ToString();
            return tempResult;
        }

        public CustomList<T> Zip(CustomList<T> List1, CustomList<T> List2)
        {
            CustomList<T> zippedCustomList = new CustomList<T>();

            for (int i=0; i<List1.Count; i++)
            {
                try
                {
                    zippedCustomList.Add(List1[i]);
                    zippedCustomList.Add(List2[i]);
                }
                catch(ArgumentOutOfRangeException)
                {
                    break;
                }
            }
            return zippedCustomList;            
        }

        public static CustomList<T> operator +(CustomList<T> List1, CustomList<T> List2)
        {
            CustomList<T> tempCustomList = new CustomList<T>();
            for (int i = 0; i < List1.Count; i++)
            {
                tempCustomList.Add(List1[i]);
            }

            for (int i = 0; i < List2.Count; i++)
            {
                tempCustomList.Add(List2[i]);
            }

            return tempCustomList;
        }

        public static CustomList<T> operator -(CustomList<T> List1, CustomList<T> List2)
        {
            CustomList<T> tempCustomList = new CustomList<T>();

            for (int i = 0; i < List1.Count; i++)
            {
                for (int j = 0; j < List2.Count; j++)
                {
                    if (List2[j].Equals(List1[i]))
                    {
                        List1.Delete(List1[i]);
                    }
                }
            }
            return List1;
        }

        public T GetListIndex(int i)
        {
            int tempNdx = i;
            
            if ((i >= 0) && (i < this.count))
            {
                return items[tempNdx];
            }
            else
            {
                tempNdx = (this.count - 1);
                throw new ArgumentOutOfRangeException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        } 
    }    
}
