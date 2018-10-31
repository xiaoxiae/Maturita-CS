from math import inf
from random import randint

class Heap:
    """Implements a heap with some basic operations."""
    # A list that will hold the data of the heap
    heap = []

    def __init__(self, list):
        """Heapify the list"""
        self.heap = list

        # Shift down all the elements (from last to first), takes O(n)
        for i in reversed(range(len(list))):
            self.shiftDown(i)

    def add(self, element):
        """Add an element to a heap in O(log(n)) - shifts up."""
        self.heap.append(element)

        i = len(self.heap) - 1      # the last element (the newly added one)
        parent = self.getParent(i)  # it's parent

        # While the parent is smaller, swap it and the parent
        while(parent[0] < self.heap[i]):
            self.heap[parent[1]], self.heap[i] = self.heap[i], self.heap[parent[1]]

            # change i to the index of the parent and the parent of it's parent
            i = parent[1]
            parent = self.getParent(i)

    def sorted(self):
        """Perform heapsort, return the sorted array. Note that this empties the
        heap."""
        array = []

        # While there are elements in the heap, pop the biggest one
        while len(self.heap) > 0:
            array.append(self.pop())

        return list(reversed(array))

    def pop(self):
        """Pops the biggest value from the heap in O(log(n))."""
        if len(self.heap) == 0:
            return None
        elif len(self.heap) == 1:
            return self.heap.pop()

        maxValue = self.heap[0]

        self.heap[0] = self.heap.pop()
        self.shiftDown(0)

        return maxValue

    def peek(self):
        """Returns the biggest value from the heap without popping it."""
        if len(self.heap) == 0:
            return None
        else:
            return self.heap[0]

    def shiftDown(self, i):
        """Shifts a number at an index down, until it is in the correct spot."""
        mChild = max(self.getChildren(i))

        # Swap until our number is not bigger than the biggest of its children
        while self.getValue(i) <= mChild[0]:
            self.heap[i], self.heap[mChild[1]] = self.heap[mChild[1]], self.heap[i]

            i = maxChild[1]
            maxChild = max(self.getChildren(i))

    def getValue(self, index):
        """Returns the value at a specified index of the heap."""
        if index < 0:
            # Infinity if it's above the root
            return inf
        elif index >= len(self.heap):
            # -Infinity if it's bigger than the list (would be potential child)
            return -inf
        else:
            # Otherwise it's ok to return the value
            return self.heap[index]

    def getChildren(self, index):
        """Returns the children of an index."""
        return [(self.getValue(2*(index+1)-1), 2*(index+1)-1),
                (self.getValue(2*(index+1)), 2*(index+1))]

    def getParent(self, index):
        """Returns the parent of an index."""
        return [self.getValue((index+1)//2-1), (index+1)//2-1]
