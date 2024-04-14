namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
       private class Node
        {
            public T Element { get; set; }

            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
            {
                this.Element = element;
              
            }
        }


        private Node head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
           var node =  this.head;

            while (node != null)
            {
                if (node.Element.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            CheckIfHeadIsNull(this.head);
          


            var oldHead = this.head;
            this.head = oldHead.Next;

            this.Count--;
            return oldHead.Element;
           
        }

        public void Enqueue(T item)
        {
            var node = new Node(item);

            if (head is null)
            {
                this.head = node;
            }
            else
            {
                var headNode = this.head;

                while (headNode.Next != null)
                {
                    headNode = this.head.Next;
                }

                headNode.Next = node;
            }

            this.Count++;

        }

        public T Peek()
        {
            CheckIfHeadIsNull(this.head);
            return this.head.Element;

        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while (node != null)
            {
             
                yield return node.Element;
                node = node.Next;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();


        private void CheckIfHeadIsNull(Node top)
        {
            if (top is null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}