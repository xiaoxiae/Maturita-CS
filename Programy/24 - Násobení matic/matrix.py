from copy import deepcopy

class Matrix:
    """A Python implementation of a matrix class and some of its operations."""
    matrix = None

    def __init__(self, input):
        """Creates a matrix from a list of values."""
        self.matrix = input

        # check for row length and values
        row_length = len(input[0])
        for row in self.matrix:

            # check for the correct length of the row
            if len(row) != row_length:
                raise ValueError("Input matrix has the wrong dimensions!")

            # check for non-numberical values.
            for number in row:
                if type(number) != int and type(number) != float:
                    raise ValueError("Input matrix contains non-numberics!")


    def __str__(self):
        """Defines the string representation of the matrix."""
        return str(self.matrix)


    def __add__(self, other):
        """Defines matrix addition."""
        # if we are trying to add something else than a matrix, throw TypeError
        if type(other) != Matrix:
            raise TypeError("Undefined addition operation!")

        m1, m2 = self.matrix, other.matrix

        # if dimensions of the matrices don't match up
        if len(m1) != len(m2) or len(m1[0]) != len(m2[0]):
            raise TypeError("Wrong matrix dimensions!")

        # perform the addition
        result = [[0] * len(m1[0]) for _x in range(len(m1))]
        for i in range(len(m1)):
            for j in range(len(m1[0])):
                result[i][j] = m1[i][j] + m2[i][j]

        return Matrix(result)


    def __sub__(self, other):
        """Defines matrix subtraction (in terms of addition)."""
        return self.__add__(other * -1)


    def __mul__(self, other):
        """Defines scalar and matrix multiplication for a matrix object."""
        if (type(other) == int or type(other) == float):
            # Scalar multiplication
            return self.__scalar_multiplication(other)
        elif (type(other) == Matrix):
            # Vector multiplication
            return self.__matrix_multiplication(other)
        else:
            raise TypeError("Undefined multiplication operation!")


    # reverse multiplication is the same as normal multiplication for matrices
    __rmul__ = __mul__


    def __scalar_multiplication(self, scalar):
        """Returns a result of scalar multiplication."""
        # deepcopy the array
        m = deepcopy(self.matrix)

        # multiply each of the indexes of the matrix by the scalar
        for i in range(len(m[0])):
            for j in range(len(m)):
                m[j][i] *= scalar

        return Matrix(m)


    def __matrix_multiplication(self, other):
        """Returns a result of matrix multiplication."""
        m1 = self.matrix
        m2 = other.matrix

        # check for correct matrix dimensions
        if (len(m1[0]) != len(m2)):
            raise TypeError("Wrong matrix size for matrix multiplication.")

        # perform the matrix multiplication
        result = [[0] * len(m2[0]) for _x in range(len(m1))]
        for i in range(len(m1)):
            for j in range(len(m2[0])):
                for k in range(len(m1[0])):
                    result[i][j] += m1[i][k] * m2[k][j]

        return Matrix(result)
