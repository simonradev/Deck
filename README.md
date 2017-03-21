# Deck

This is my first implementation of the deck. It is a linear data structure which is also 
generic and static. It works just like a Stack<> (LIFO) but you it has two sides which hold elements 
a left one and a right one. Separately they work just like a Stack<> but in the deck
they are connected. This means you can insert from the left and from the right and when 
you want to retrieve an element you choose from which side and you get the last one that
was pushed/inserted. Static means that the left and the right elements are arrays which have default size of 6 
and double up their sizes when you fill them up.

These are the implemented methods:
- PeekLeft();
- PeekRight();
- PopLeft();
- PopRight();
- PushLeft();
- PushRight();

These are the implemented properties:
- Count;
- LeftCount;
- RightCount;
