namespace Deck
{
    using System;
    
    /// <summary>
    /// This is a linear, generic data type that works like a STACK but has two sides /Right and Left/.
    /// You can choose into which side you want to insert an element.
    /// You can retrieve the elements only from the side you inserted it into.
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    class Deck<TType>
    {
        private TType[] leftElements;
        private TType[] rightElements;
        private int leftCount;
        private int rightCount;
        private int leftElementsSize = 6;
        private int rightElementsSize = 6;
        private bool rightIsForResizing;

        public Deck()
        {
            leftElements = new TType[leftElementsSize];
            rightElements = new TType[rightElementsSize];
        }

        public int Count
        {
            get { return (this.leftCount + this.rightCount); }
        }

        public int RightCount
        {
            get { return this.rightCount; }
        }

        public int LeftCount
        {
            get { return this.leftCount; }
        }

        /// <summary>
        /// Insert the element on the right of the deck.
        /// </summary>
        /// <param name="rightElement"></param>
        public void PushRight(TType rightElement)
        {
            if (rightCount == rightElements.Length)
            {
                rightIsForResizing = true;
                DoubleUpTheSize();
            }

            rightElements[rightCount] = rightElement;

            rightCount++;
        }

        /// <summary>
        /// Insert the element on the left of the deck.
        /// </summary>
        /// <param name="leftElement"></param>
        public void PushLeft(TType leftElement)
        {
            if (leftCount == leftElements.Length)
            {
                rightIsForResizing = false;
                DoubleUpTheSize();
            }

            leftElements[leftCount] = leftElement;

            leftCount++;
        }

        /// <summary>
        /// Returns and removes the last element from the right side of the deck.
        /// </summary>
        /// <returns></returns>
        public TType PopRight()
        {
            ValidateTheOperation(rightCount, "The right deck is empty. No item to pop. Try inserting something first.");

            int indexToRemoveFromRight = rightCount - 1;

            TType elementToReturn = rightElements[indexToRemoveFromRight];
            rightElements[indexToRemoveFromRight] = default(TType);

            rightCount--;

            return elementToReturn;
        }

        /// <summary>
        /// Returns and removes the last element from the left side of the deck.
        /// </summary>
        /// <returns></returns>
        public TType PopLeft()
        {
            ValidateTheOperation(leftCount, "The left deck is empty. No item to pop. Try inserting something first.");

            int indexToRemoveFromLeft = leftCount - 1;

            TType elementToReturn = leftElements[indexToRemoveFromLeft];
            leftElements[indexToRemoveFromLeft] = default(TType);

            leftCount--;

            return elementToReturn;
        }

        /// <summary>
        /// Only returns without removing the last element from the right side of the deck.
        /// </summary>
        /// <returns></returns>
        public TType PeekRight()
        {
            ValidateTheOperation(rightCount, "The right deck is empty. No item to peek. Try inserting something first.");

            int itemToPeek = rightCount - 1;

            return rightElements[itemToPeek];
        }

        /// <summary>
        /// Only returns without removing the last element from the left side of the deck.
        /// </summary>
        /// <returns></returns>
        public TType PeekLeft()
        {
            ValidateTheOperation(leftCount, "The left deck is empty. No item to peek. Try inserting something first.");

            int itemToPeek = leftCount - 1;

            return leftElements[itemToPeek];
        }

        private void DoubleUpTheSize()
        {
            if (rightIsForResizing)
            {
                rightElementsSize *= 2;
                TType[] rightArrHolder = new TType[rightElements.Length];
                Array.Copy(rightElements, rightArrHolder, rightElements.Length);
                rightElements = new TType[rightElementsSize];
                Array.Copy(rightArrHolder, rightElements, rightArrHolder.Length);
                rightArrHolder = default(TType[]);
            }
            else
            {
                leftElementsSize *= 2;
                TType[] leftArrHolder = new TType[leftElements.Length];
                Array.Copy(leftElements, leftArrHolder, leftArrHolder.Length);
                leftElements = new TType[leftElementsSize];
                Array.Copy(leftArrHolder, leftElements, leftArrHolder.Length);
                leftArrHolder = default(TType[]);
            }
        }

        private void ValidateTheOperation(int count, string message)
        {
            if (count == 0)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
