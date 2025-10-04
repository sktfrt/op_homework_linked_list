using System;
using Program;

namespace Program
{
    public class LinkedList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node? Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node? head;


        public void Add(T item)
        {
            Node p = head;
            Node lastElem = null;
            Node newValue = new Node(item);

            if (head == null)
            {
                head = newValue;
            }
            else
            {
                while (p != null)
                {
                    lastElem = p;
                    p = p.Next;
                }
                lastElem.Next = newValue;
            }
        }

        public bool Remove(T item)
        {
            if (head == null) return false;

            Node p = head;
            Node last = null;
            Node prevForLast = null;
            Node prevForMid = null;

            while (p != null)
            {
                prevForLast = last;
                last = p;
                p = p.Next;
            }

            p = head;

            if (p.Value.Equals(item))
            {
                head = p.Next;
            }
            else if (last.Value.Equals(item))
            {
                prevForLast.Next = null;
            }
            else
            {
                while (p != null && !p.Value.Equals(item))
                {
                    prevForMid = p;
                    p = p.Next;
                }

                if (p == null) return false;
                
                if (prevForMid == null)
                {
                    head = p.Next;
                }
                else
                {
                    prevForMid.Next = p.Next;
                }
            }
            return true;
        }

        public T Get(int index)
        {
            int cnt = 0;
            Node p = head;

            while (cnt != index && p != null)
            {
                p = p.Next;
                cnt++;
            }
            if (p == null) throw new ArgumentOutOfRangeException($"Error! Index out of range! Max index is: {cnt}");
            return p.Value;
        }

        public int Count()
        {
            int cnt = 0;
            Node p = head;

            if (head == null) return 0;
            while (p != null)
            {
                cnt++;
                p = p.Next;
            }
            return cnt;
        }

        public void Clear()
        {
            head = null;
        }
    }
}

