using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListImplementation
{
    public class DoublyLinkedList
    {
        private class DoublyLinkedListNode
        {
            private object element;
            private DoublyLinkedListNode next;
            private DoublyLinkedListNode previous;

            public DoublyLinkedListNode(object element)
            {
                this.element = element;
                this.next = null;
                this.previous = null;
            }

            public DoublyLinkedListNode(object element, DoublyLinkedListNode prevNode)
            {
                this.element = element;
                this.previous = prevNode;
                prevNode.next = this;
            }

            public object Element
            {
                get { return this.element; }
                set { this.element = value; }
            }

            public DoublyLinkedListNode Next
            {
                get { return this.next; }
                set { this.next = value; }
            }

            public DoublyLinkedListNode Previous
            {
                get { return this.previous; }
                set { this.previous = value; }
            }
        }

        private DoublyLinkedListNode head;
        private DoublyLinkedListNode tail;
        private int count;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public int Count
        {
            get { return this.count; }
        }

        public object this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Out of range!");
                }
                DoublyLinkedListNode currentNode = this.head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode.Element;
            }
            set
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Out of range!");
                }
                DoublyLinkedListNode currentNode = this.head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Element = value;
            }
        }

        public void Add(object item)
        {
            if (this.head == null)
            {
                this.head = new DoublyLinkedListNode(item);
                this.tail = this.head;
            }
            else
            {
                DoublyLinkedListNode newItem = new DoublyLinkedListNode(item, tail);
                this.tail = newItem;
            }
            count++;
        }

        public void Insert(object item, int index)
        {
            count++;
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Out of range!");
            }
            DoublyLinkedListNode newItem = new DoublyLinkedListNode(item);
            int currentIndex = 0;
            DoublyLinkedListNode currentItem = this.head;
            DoublyLinkedListNode prevItem = null;
            while (currentIndex < index)
            {
                prevItem = currentItem;
                currentItem = currentItem.Next;
                currentIndex++;
            }
            if (index == 0)
            {
                newItem.Previous = this.head.Previous;
                newItem.Next = this.head;
                this.head.Previous = newItem;
                this.head = newItem;
            }
            else if (index == count - 1)
            {
                newItem.Previous = this.tail;
                this.tail.Next = newItem;
                newItem = this.tail;
            }
            else
            {
                newItem.Next = prevItem.Next;
                prevItem.Next = newItem;
                newItem.Previous = currentItem.Previous;
                currentItem.Previous = newItem;
            }
        }

        public void Remove(object item)
        {
            int currentIndex = 0;
            DoublyLinkedListNode currentItem = this.head;
            DoublyLinkedListNode prevItem = null;
            while (currentItem != null)
            {
                if ((currentItem.Element != null &&
                    currentItem.Element.Equals(item)) ||
                    (currentItem.Element == null) && (item == null))
                {
                    break;
                }
                prevItem = currentItem;
                currentItem = currentItem.Next;
                currentIndex++;
            }
            if (currentItem != null)
            {
                count--;
                if (count == 0)
                {
                    this.head = null;
                }
                else if (prevItem == null)
                {
                    this.head = currentItem.Next;
                    this.head.Previous = null;
                }
                else if (currentItem == tail)
                {
                    currentItem.Previous.Next = null;
                    this.tail = currentItem.Previous;
                }
                else
                {
                    currentItem.Previous.Next = currentItem.Next;
                    currentItem.Next.Previous = currentItem.Previous;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Out of range!");
            }

            int currentIndex = 0;
            DoublyLinkedListNode currentItem = this.head;
            DoublyLinkedListNode prevItem = null;
            while (currentIndex < index)
            {
                prevItem = currentItem;
                currentItem = currentItem.Next;
                currentIndex++;
            }
            if (this.count == 0)
            {
                this.head = null;
            }
            else if (prevItem == null)
            {
                this.head = currentItem.Next;
                this.head.Previous = null;
            }
            else if (index == count - 1)
            {
                prevItem.Next = currentItem.Next;
                tail = prevItem;
                currentItem = null;
            }
            else
            {
                prevItem.Next = currentItem.Next;
                currentItem.Next.Previous = prevItem;
            }
            count--;
        }

        public int indexOf(object item)
        {
            int index = 0;
            DoublyLinkedListNode currentItem = this.head;
            while (currentItem != null)
            {
                if (((currentItem.Element != null) && (item == currentItem.Element)) ||
                    ((currentItem.Element == null) && (item == null)))
                {
                    return index;
                }
                index++;
                currentItem = currentItem.Next;
            }
            return -1;
        }

        public object[] LikeArray()
        {
            object[] array = new object[this.count];
            DoublyLinkedListNode currentItem = this.head;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = currentItem.Element;
                currentItem = currentItem.Next;
            }
            return array;
        }

        public bool Contains(object element)
        {
            int index = indexOf(element);
            bool contains = (index != -1);
            return contains;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
    }
}
