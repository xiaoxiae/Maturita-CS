def add_to_row(r1, r2, multiple):
    """Adds a multiple of row a to row b."""
    for i in range(len(r1)):
        r2[i] += r1[i] * multiple


def multiply_row(row, number):
    """Multiplies a row by a number."""
    for i in range(len(row)):
        row[i] *= number


def zero_row(row):
    """Returns true if the array only contains (and False if not)."""
    for number in row:
        if number != 0:
            return False
    return True


def gcd(a, b):
    """Returns the greatest common denominator."""
    while a != 0:
        b, a = min(a, b), max(a, b) % min(a, b)
    return b


def pprint(equation):
    """Pretty-prints the equation."""
    for line in equation:
        for symbol in line:
            print(str(symbol) + "\t", end="")
        print()
    print()


def terminate_with_result(result_type):
    """Terminates the program and prints the result of the computation."""
    if result_type == 0:
        print("No possible solution!")
    elif result_type == 1:
        print("Infinite number of solutions!")



def clear_column(i, rows, equation):
    """Makes all of the values in the specified rows of the equation in the
    i-th column zero.

    1  2  3  5      1  2  3  5
    2 -1 -1  1  ->  0 -5 -7 -9
    1  3  4  6      0  1  1  1
    """

    # if the diagonal value is 0, swap the line with one that isn't 0
    if equation[i][i] == 0:
        j = 0
        while j < len(rows) and equation[rows[j]][i] == 0:
            j += 1

        # if the rest of the rows are also 0, the equation has no solutions
        # if they are not, we can simply swap the rows and continue
        if j == len(rows):
            terminate_with_result(0)
        else:
            equation[i], equation[rows[j]] = equation[rows[j]], equation[i]

    for j in rows:
        # check, whether it isn't 0 already to prevent division by 0
        if equation[j][i] == 0:
            continue

        common_denominator = gcd(abs(equation[j][i]), abs(equation[i][i]))
        multiple = -equation[j][i] // common_denominator

        # the same as how its done in regular matrices
        multiply_row(equation[j], equation[i][i] // common_denominator)
        add_to_row(equation[i], equation[j], multiple)

        # if the row only contains number 0, the number of solutions is infinite
        if zero_row(equation[j]):
            terminate_with_result(1)


# get the input
equation = []
number_of_rows = int(input("Input the number of rows: "))

print("\nInput " + str(number_of_rows) + " space-separated rows of numbers.")
for i in range(number_of_rows):
    row_string = input(str(i + 1) + " > ")
    row = list(map(int, row_string.split(" ")))

    equation.append(row)


# if there are more rows than equation variables, solutions are infinite
if len(equation[0]) > len(equation) + 1:
    terminate_with_result(1)

# fill the bottom half of the matrix with zeroes
for i in range(len(equation)):
    clear_column(i, list(range(i + 1, len(equation))), equation)

# fill the top half of the matrix with zeroes
for i in reversed(range(len(equation))):
    clear_column(i, list(reversed(range(i))), equation)

# divide rows by the values on their diagonals
for i in range(len(equation)):
    equation[i][-1] /= equation[i][i]
    equation[i][i] = 1

# print the result
print("\nK = " + str([equation[i][-1] for i in range(len(equation))]))

