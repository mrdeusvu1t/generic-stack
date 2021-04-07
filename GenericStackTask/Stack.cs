using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericStackTask
{
    /// <summary>
    /// Represents extendable last-in-first-out (LIFO) collection of the specified type T.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the stack.</typeparam>
    public class Stack<T> : IEnumerable<T>
    {
        private int _capacity;
        private T[] _stack;

        /// <summary>
        /// Initializes a new instance of the stack class that is empty and has the default initial capacity.
        /// </summary>
        public Stack()
        {
            _capacity = 0;
            _stack = new T[_capacity];
        }

        /// <summary>
        /// Initializes a new instance of the stack class that is empty and has
        /// the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The initial number of elements of stack.</param>
        public Stack(int capacity)
        {
            _capacity = capacity;
            _stack = new T[_capacity];
        }

        /// <summary>
        /// Initializes a new instance of the stack class that contains elements copied
        /// from the specified collection and has sufficient capacity to accommodate the
        /// number of elements copied.
        /// </summary>
        /// <param name="collection">The collection to copy elements from.</param>
        public Stack(IEnumerable<T> collection)
        {
            int capacity = 0;
            foreach (T item in collection)
            {
                capacity++;
            }

            _capacity = capacity;
            _stack = new T[_capacity];

            int i = 0;
            foreach (T item in collection)
            {
                _stack[i] = item;
                i++;
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the stack.
        /// </summary>
        public int Count
        {
            get => _capacity;
        }

        /// <summary>
        /// Removes and returns the object at the top of the stack.
        /// </summary>
        /// <returns>The object removed from the top of the stack.</returns>
        public T Pop()
        {
            if (_capacity - 1 < 0)
            {
                throw new InvalidOperationException();
            }

            T temp = _stack[Count - 1];

            _capacity--;

            return temp;
        }

        /// <summary>
        /// Returns the object at the top of the stack without removing it.
        /// </summary>
        /// <returns>The object at the top of the stack.</returns>
        public T Peek()
        {
            T temp = _stack[Count - 1];

            return temp;
        }

        /// <summary>
        /// Inserts an object at the top of the stack.
        /// </summary>
        /// <param name="item">The object to push onto the stack.
        /// The value can be null for reference types.</param>
        public void Push(T item)
        {
            _capacity++;

            if (_capacity > _stack.Length + 1)
			{
                throw new InvalidCastException();
			}

            T[] temp = new T[_capacity];

            for (int i = 0; i < _capacity; i++)
            {
                if (i == _capacity - 1)
                {
                    temp[i] = item;
                    break;
                }

                temp[i] = _stack[i];
            }

            _stack = temp;
        }

        /// <summary>
        /// Copies the elements of stack to a new array.
        /// </summary>
        /// <returns>A new array containing copies of the elements of the stack.</returns>
        public T[] ToArray()
        {
            return _stack;
        }

        /// <summary>
        /// Determines whether an element is in the stack.
        /// </summary>
        /// <param name="item">The object to locate in the stack. The value can be null for reference types.</param>
        /// <returns>Return true if item is found in the stack; otherwise, false.</returns>
        public bool Contains(T item)
        {
            if (item == null)
			{
                return true;
			}

            foreach (var myItem in _stack)
            {
                if (item.Equals(myItem))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes all objects from the stack.
        /// </summary>
        public void Clear()
        {
            _capacity = 0;
            _stack = new T[_capacity];
        }

        /// <summary>
        /// Returns an enumerator for the stack.
        /// </summary>
        /// <returns>Return Enumerator object for the stack.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _stack.Length - 1; i >= 0; i--)
			{
                yield return _stack[i];
			}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}