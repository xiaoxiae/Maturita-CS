class Node:
    """Stores a value and a reference to the next node."""

    def __init__(self, value, reference):
        self.value = value
        self.reference = reference


class LinkedList:
    """Implements a linked list and some of its common operations."""

    def __init__(self, default_values=[]):
        """Initializes the values of the linked list from a normal list."""
        self.length = 0
        previousNode = None

        # adds the default values to the linked list
        for elem in default_values:
            self.add(elem, 0)

        # set the first node
        self.firstNode = previousNode

    def __len__(self):
        """Defines the length of a LinkedList object as the number of its nodes."""
        return self.length

    def __str__(self):
        """Defines the string representation of a LinkedList object as a str(...) call on a list of nodes."""
        list = []
        node = self.firstNode

        while node is not None:
            list.append(node.value)
            node = node.reference

        return str(list)

    def add(self, element, index=0):
        """Adds an element to an index of the list."""
        # special case for 0 - replace the first node
        if index == 0:
            node = Node(element, self.firstNode)
            self.firstNode = node
        else:
            # iterate over the list until the appropriate index is found
            previousNode = self.firstNode
            for i in range(index - 1):
                previousNode = previousNode.reference

            node = Node(element, previousNode.reference)
            previousNode.reference = node

        self.length += 1

    def pop(self, index=0, peek=False):
        """Pops an element (at the specified index) of the list."""
        # special case for one - replace the first node
        if index == 0:
            value = self.firstNode.value

            if not peek:
                self.firstNode = self.firstNode.reference
        else:
            previousNode = self.firstNode
            for i in range(index - 1):
                previousNode = previousNode.reference

            value = previousNode.reference.value

            # if we aren't peeking, remove the node
            if not peek:
                previousNode.reference = previousNode.reference.reference

        self.length -= 1

        return value

    def peek(self, index=0):
        """Returns an element (at the specified index) of the list."""
        return self.pop(index, peek=True)

    def index(self, element):
        """Returns the position of an element in the list and -1 if the element is not in the list."""

        previousNode = self.firstNode

        # traverse the list until the element is found (or not)
        for i in range(self.length):
            if previousNode.value == element:
                return i
            previousNode = previousNode.reference

        return -1
