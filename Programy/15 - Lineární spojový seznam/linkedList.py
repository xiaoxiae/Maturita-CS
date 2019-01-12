class Node:
    """Stores a value and a reference to the next node."""
    def __init__(self, value, reference):
        self.value = value
        self.reference = reference

class LinkedList:
    """Implements a linked list and some of its common operations."""
    def __init__(self, list=[]):
        """Initializes the values of the linked list from a normal list."""
        self.length = 0
        previousNode = None

        # Goes through the list in reversed order and adds all the elements
        for element in reversed(list):
            node = Node(element, previousNode)
            previousNode = node
            self.length += 1

        # Set the first node
        self.firstNode = previousNode

    def __len__(self):
        """Defines the result of a len() call on a LinkedList object."""
        return self.length

    def getList(self):
        """Returns the linked list in a list form."""
        list = []

        # Go through all the nodes and add them to the list
        previousNode = self.firstNode
        for i in range(0, self.length):
            list.append(previousNode.value)
            previousNode = previousNode.reference

        return list

    def add(self, element, index=0):
        """Adds an element to an index of the list."""
        # Special case for 0 - firstNode needs to be replaced
        if (index == 0):
            node = Node(element, self.firstNode)
            self.firstNode = node
            self.length += 1
        else:
            # Iterate over the list until the appropriate index is found
            previousNode = self.firstNode
            for i in range(0, index - 1):
                previousNode = previousNode.reference

            node = Node(element, previousNode.reference)
            previousNode.reference = node
            self.length += 1

    def remove(self, index=0):
        """Removes an element at an index of the list."""
        # Value of the element to return after deletion
        value = 0

        # Special case for one - replace the first node
        if (index == 0):
            value = self.firstNode.value
            self.firstNode = self.firstNode.reference
        else:
            previousNode = self.firstNode

            # Iterate through index-1 number of nodes
            for i in range(0, index - 1):
                previousNode = previousNode.reference

            # Replace the index that was reached through the iteration
            value = previousNode.reference.value
            previousNode.reference = previousNode.reference.reference

        self.length -= 1

        return value

    def index(self, element):
        """Returns the position of an element in the list and -1 if the element
        is not in the list."""

        previousNode = self.firstNode

        # Traverse the list until the element is found (or not)
        for i in range(0, self.length):
            if previousNode.value == element:
                return i
            previousNode = previousNode.reference

        return -1
