from math import inf


class Heap:
    """Implements a heap with some basic operations."""
    heap = []

    def __init__(self, default_values):
        """Initializes the heap from an iterable of default values."""
        self.heap = default_values

        # shift down all the elements (from last to first); takes O(n)
        for i in reversed(range(len(default_values))):
            self._shift_down(i)

    def __str__(self):
        """Defines the string representation of the Heap object as a str(...) call on the heap list."""
        return str(self.heap)

    def add(self, element):
        """Add an element to a heap by shifting it up. Takes O(log(n))."""
        self.heap.append(element)

        self._shift_up(len(self.heap) - 1)

    def sorted(self):
        """Return the sorted array. Note that this empties the heap."""
        array = []

        # while there are elements in the heap, pop the biggest one
        while len(self.heap) > 0:
            array.append(self.pop())

        return list(reversed(array))

    def pop(self):
        """Pops the biggest value from the heap. Takes O(log(n))."""
        if len(self.heap) == 0:
            return None
        elif len(self.heap) == 1:
            return self.heap.pop()

        biggest_value = self.heap[0]

        # replaces the first element with the last one and shifts it down
        self.heap[0] = self.heap.pop()
        self._shift_down(0)

        return biggest_value

    def peek(self):
        """Returns the biggest value from the heap without popping it."""
        if len(self.heap) == 0:
            return None
        else:
            return self.heap[0]

    def _shift_down(self, i):
        """Shifts a number at an index down, until it is in the correct spot."""
        biggest_child = max(self._get_children(i))

        # swap until the number is not bigger than the biggest of its children
        while self._get_value(i) < biggest_child[0]:
            self.heap[i], self.heap[biggest_child[1]] = self.heap[biggest_child[1]], self.heap[i]

            i = biggest_child[1]
            biggest_child = max(self._get_children(i))

    def _shift_up(self, i):
        """Shifts a number at an index up, until it is in the correct spot."""
        parent = self._get_parent_index(i)  # the index of it's

        # while the parent is smaller, swap it and the parent
        while self._get_value(parent) < self.heap[i]:
            self.heap[parent], self.heap[i] = self.heap[i], self.heap[parent]

            # change i to the index of the parent and the parent to it's parent
            i = parent
            parent = self._get_parent_index(parent)

    def _get_value(self, index):
        """Returns the value at a specified index of the heap, or +/- infinity if the index is outside the heap."""
        return inf if index < 0 else -inf if index >= len(self.heap) else self.heap[index]

    def _get_children(self, index):
        """Returns the indexes and values of the children of an index."""
        i1, i2 = 2 * (index + 1) - 1, 2 * (index + 1)

        return [(self._get_value(i1), i1), (self._get_value(i2), i2)]

    def _get_parent_index(self, index):
        """Returns the index of the parent of an index."""
        return (index + 1) // 2 - 1
