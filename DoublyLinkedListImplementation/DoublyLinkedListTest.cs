using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListImplementation
{
    class DoublyLinkedListTest
    {
        static void Main()
        {
            DoublyLinkedList list = new DoublyLinkedList();

            list.Add("Milk");
            list.Add("Bread");
            list.Add("Olives");
            list.Add("Oranges");
            list.Insert("Lemon", 2);
            list.Remove("Oranges");
            int index = list.indexOf(list[3]);
            Console.WriteLine(index);
            object[] array = list.LikeArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            list.Clear();
        }
    }
}
