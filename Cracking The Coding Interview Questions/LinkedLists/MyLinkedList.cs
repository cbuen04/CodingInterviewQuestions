using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists
{
    class Node<T>
    {
        internal T data;
        internal Node<T> Next;
        internal Node<T> Prev;

        public Node(T data)
        {
            this.data = data;
        }

    }

    class MyLinkedList<T>
    {
        Node<T> head;
        int Count = 0;

        public MyLinkedList()
        {

        }

        /// <summary>
        /// this method adds to the end of a linked list
        /// </summary>
        /// <param name="data"></param>
        public void AddToLast(T data)
        {
            Node<T> current = head;
            if(head == null)
            {
                head.data = data;
                Count++;
                return;
            }
            while(current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node<T>(data);
            Count++;
        }

        public void AddFirst(T data)
        {
            if(head == null)
            {
                head.data = data;
                Count++;
                return;
            }
            Node<T> newHead = new Node<T>(data);
            newHead.Next = head;
            head = newHead;
            Count++;
        }

        public bool InsertAt(int index, T data)
        {
            Node<T> current = head;
            Node<T> insertNode = new Node<T>(data);
            if(index > Count || index < 0)
            {
                return false;
            }
            if(index == 0)
            {
                AddFirst(data);
                Count++;
                return true;
            }
            while(index - 1 != 0)
            {
                current = current.Next;
                index--;
            }
            insertNode.Next = current.Next;
            current.Next = insertNode;
            Count++;
            return true;
            
        }

        public T RemoveFirst()
        {
            if(head == null)
            {
                return default;
            }
            T data = head.data;
            head = head.Next;
            Count--;
            return data;
        }

        /// <summary>
        /// removes all occurences of a specific data entry
        /// returns true if found and removed removed, false if it was not found
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool RemoveData(T data)
        {
            Node<T> current = head;
            int removeCount = 0;
            if(head == null)
            {
                return false;
            }
            while(current.Next != null)
            {
                if(current.Next.data.Equals(data))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    removeCount++;
                }
            }
            if(removeCount > 0)
            {
                return true;
            }
            return false;
        }
    }
}
