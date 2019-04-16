from enum import Enum


class RowType(Enum):
    """Defines types of rows."""
    ONLY_ZEROES = 0  # contains only zeroes
    ONLY_LAST_NUMBER = 1  # the last number is non-zero
    REGULAR = 2  # none of the above


class ResultType(Enum):
    """Defines the kinds of results that would make the program terminate prematurely."""
    INFINITE_SOLUTIONS = 0
    NO_SOLUTIONS = 1


def add_to_row(r1, r2, multiple):
    """Adds a multiple of row a to row b."""
    for i in range(len(r1)):
        r2[i] += r1[i] * multiple


def multiply_row(row, number):
    """Multiplies a row by a number."""
    for i in range(len(row)):
        row[i] *= number


def get_row_type(row):
    """Returns the type of the row."""
    for number in row[:-1]:
        if number != 0:
            return RowType.REGULAR

    if row[-1] == 0:
        return RowType.ONLY_ZEROES
    else:
        return RowType.ONLY_LAST_NUMBER


def gcd(a, b):
    """Returns the greatest common denominator."""
    a, b = min(a, b), max(a, b)

    while a != 0:
        a, b = b % a, a

    return b


def terminate_with_result(result_type):
    """Terminates the program and prints the result of the computation."""
    if result_type == ResultType.INFINITE_SOLUTIONS:
        print("Infinite number of solutions!")
    elif result_type == ResultType.NO_SOLUTIONS:
        print("No solutions!")
    quit()


def clear_column(i, rows, equation):
    """Makes all of the values in the specified rows of the equation in the i-th column zero using allowed operations.

    1  2  3  5      1  2  3  5
    2 -1 -1  1  ->  0 -5 -7 -9
    1  3  4  6      0  1  1  1
    """

    # it could be the case that by popping an empty row, this function is later called on a non existent row
    # in that case, simply return
    if i >= len(equation):
        return

    # if the diagonal value is 0, swap the line with one of the rows that isn't 0
    if equation[i][i] == 0:
        # look for the row with a 0 in it; if it isn't found, return/terminate the program
        for row in rows:
            if equation[row][i] != 0:
                equation[i], equation[row] = equation[row], equation[i]
                break
        else:
            # if i is 0, the entire row has to be empty, so the system has an infinite number of solutions
            # if not, simply return, since there there's nothing for us to do
            if i == 0:
                terminate_with_result(ResultType.INFINITE_SOLUTIONS)
            else:
                return

    for row in rows:
        # check, whether it isn't 0 already to prevent division by 0
        if equation[row][i] == 0:
            continue

        # to prevent the numbers from getting overly large
        common_denominator = gcd(abs(equation[row][i]), abs(equation[i][i]))
        multiple = -equation[row][i] // common_denominator

        # the same as how its done in regular matrices
        multiply_row(equation[row], equation[i][i] // common_denominator)
        add_to_row(equation[i], equation[row], multiple)

        row_type = get_row_type(equation[row])
        if row_type == RowType.ONLY_ZEROES:
            # remove the empty row
            equation.pop(row)

            # if there is not enough rows of the equation to solve it, terminate
            if len(equation[0]) > len(equation) + 1:
                terminate_with_result(ResultType.INFINITE_SOLUTIONS)
        elif row_type == RowType.ONLY_LAST_NUMBER:
            terminate_with_result(ResultType.NO_SOLUTIONS)


# get the input
equation = []
print("Input space-separated rows of numbers.")

while True:
    row_string = input("> ")

    if row_string == "":
        break

    row = list(map(int, row_string.split(" ")))
    equation.append(row)

# if there are more rows than equation variables, solutions are infinite
if len(equation[0]) > len(equation) + 1:
    terminate_with_result(ResultType.INFINITE_SOLUTIONS)

# fill the bottom half of the matrix with zeroes
for i in range(len(equation)):
    clear_column(i, list(range(i + 1, len(equation))), equation)

# fill the top half of the matrix with zeroes
for i in reversed(range(len(equation))):
    clear_column(i, list(reversed(range(i))), equation)

# divide rows by the values on their diagonals
for i in range(len(equation)):
    equation[i][-1] /= equation[i][i]

# print the result
input("K = " + str([equation[i][-1] for i in range(len(equation))]))
