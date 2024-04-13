namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY) 
        {
            _items = new T[DEFAULT_CAPACITY];

        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentNullException(nameof(capacity));
            }

            _items =  new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return _items[index];
            }
            set
            {
                ValidateIndex(index);
                _items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            Grow();

            this._items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return true;

                }
            }

            return false;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }

            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            Grow();


            for (int i = this.Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }


            this._items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
           var index = IndexOf(item);

            ValidateIndex(index);

            this.RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < this.Count -1 ; i++)
            {
                this._items[i] = _items[i + 1];
            }

            this._items[this.Count - 1] = default;

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => GetEnumerator();

        private void Grow()
        {

            if (_items.Length == this.Count)
            {
                T[] listCoppy = new T[this._items.Length * 2];

                for (int i = 0; i < this._items.Length; i++)
                {
                    listCoppy[i] = _items[i];
                }

                _items = listCoppy;
            }

         

        }

        private void ValidateIndex(int index)
        {

            if (index < 0)
            {
                throw new NullReferenceException(nameof(index));
            }
        }
    }
}