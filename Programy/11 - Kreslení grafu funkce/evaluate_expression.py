from math import log, acos, asin, atan, cos, sin, tan, e, sqrt, radians, degrees


def evaluate_function_from_list(function: str, x_values: list):
    """Evaluates the function values of a function from a list of values.
    :param x_values: The list of x values from which to compute the y values.
    :param function: The function to use on the x values.
    :return: None if the evaluation failed and a number if it didn't.
    """

    # sanitize the input
    function = function.replace(" ", "").strip()

    # return nothing if the input is empty after sanitization or the bracketing is wrong
    if len(function) == 0 or not is_bracketing_correct(function):
        return [None] * len(x_values)

    operators = {"+": [lambda a, b: a + b, 1],
                 "-": [lambda a, b: a - b, 1],
                 "*": [lambda a, b: a * b, 2],
                 "%": [lambda a, b: a % b, 2],
                 "/": [lambda a, b: a / b, 2],
                 "^": [lambda a, b: a ** b, 3]}

    functions = {"log": lambda x: log(x, 10),
                 "ln": lambda x: log(x, e),
                 "acos": lambda x: acos(x),
                 "asin": lambda x: asin(x),
                 "atan": lambda x: atan(x),
                 "cos": lambda x: cos(x),
                 "sin": lambda x: sin(x),
                 "tan": lambda x: tan(x),
                 "rad": lambda x: radians(x),
                 "deg": lambda x: degrees(x),
                 "sqrt": lambda x: sqrt(x)}

    # multiple number stacks for the x values, since the numbers will vary (but operators will not)
    number_stacks = [[] for _x in range(len(x_values))]
    operator_stack = []

    i = 0
    while i < len(function):
        if function[i].isdigit():
            multiplier = 1

            j = _get_number_end_index(i, function)
            number = function[i:j]

            # if there is a - in front of the word and no number in front of it
            if i - 1 >= 0 and (function[i - 1] == "-"):
                if i - 2 < 0 or not function[i - 2].isdigit():
                    multiplier = -1

            # if there is a dot in it, try to parse it (there could be two dots)
            if "." in number:
                try:
                    for number_stack in number_stacks:
                        if number_stack is not None:
                            number_stack.append(float(number) * multiplier)
                except ValueError:
                    return "Incorrect decimal number!"
            else:
                for number_stack in number_stacks:
                    if number_stack is not None:
                        number_stack.append(int(number) * multiplier)

            # i gets incremented at the end of the while loop, that's why -1
            i = j - 1

        elif function[i].isalpha():
            # if it's x, treat it as a number
            if function[i] == "x":
                for j in range(len(x_values)):
                    if number_stacks[j] is not None:
                        number_stacks[j].append(x_values[j])
        elif function[i] == "(":  # if it's an opening bracket
            # if there is a function in front of it, get the starting index
            j = _get_function_start_index(i - 1, function)

            # append empty string or the function name (doesn't matter, neither)
            # of those is an operator
            operator_stack.append(function[j:i])

        elif function[i] == ")":
            # Compute all the possible operators on the stack
            while operator_stack[-1] in operators:
                operator = operators[operator_stack.pop()][0]
                for j in range(len(number_stacks)):
                    if number_stacks[j] is not None:
                        compute_result = computeOperator(number_stacks[j], operator)
                        if compute_result is not None:
                            number_stacks[j] = None

            # this can't be an operator, so it must be the closing bracket
            stop_string = operator_stack.pop()

            # checks if the opening bracket is a function by any chance
            if stop_string in functions:
                # computes the value of the function on the top stack number
                f = functions[stop_string]
                for j in range(len(number_stacks)):
                    if number_stacks[j] is not None:
                        result = computeFunction(number_stacks[j], f)
                        if result is not None:
                            number_stacks[j] = None

        elif function[i] in operators:  # if it's an operator
            # if it's a + or - and the number stack is empty, ignore it
            if function[i] == "+" or function[i] == "-":
                if i == 0 or function[i - 1] == "(":
                    i += 1
                    continue

            operator = operators[function[i]]

            # compute all operators that are of the same or higher rank
            while len(operator_stack) > 0 and operator_stack[-1] in operators:
                if operators[operator_stack[-1]][1] >= operator[1]:
                    operator = operators[operator_stack.pop()][0]
                    for j in range(len(number_stacks)):
                        if number_stacks[j] is not None:
                            compute_result = computeOperator(number_stacks[j], operator)
                            if compute_result is not None:
                                number_stacks[j] = None
                else:
                    break

            # only then add the operator to the stack
            operator_stack.append(function[i])

        i += 1

    # compute the remaining operators on the stack
    while len(operator_stack) != 0:
        operator = operators[operator_stack.pop()][0]
        for j in range(len(number_stacks)):
            if number_stacks[j] is not None:
                compute_result = computeOperator(number_stacks[j], operator)
                if compute_result is not None:
                    number_stacks[j] = None

    # return the y values
    y_values = []
    for number_stack in number_stacks:
        # return None if the value is undefined, the expression incorrect or the result complex
        if number_stack is None or len(number_stack) != 1 or type(number_stack[0]) == complex:
            y_values.append(None)
        else:
            y_values.append(number_stack[0])
    return y_values


def is_bracketing_correct(expression: str):
    """Checks, whether bracketing used in an expression is correct."""
    # Brackets to look for
    open_brackets = ['(', '[', '{']
    close_brackets = [')', ']', '}']

    # A stack to keep the opening brackets in
    bracket_stack = []

    for char in expression:
        # Look trough both the bracket groups
        for i in range(0, len(open_brackets)):
            # If it's opening, add it to the stack
            if char == open_brackets[i]:
                bracket_stack.append(char)
            elif char == close_brackets[i]:
                # If it's closing, if the opposite one isn't in the stack or the
                # stack is empty, the bracketing is wrong
                if len(bracket_stack) != 0 and bracket_stack[-1] == open_brackets[i]:
                    bracket_stack.pop()
                else:
                    return False

    # If there are remaining opening brackets, the bracketing is wrong
    if len(bracket_stack) != 0:
        return False
    else:
        return True


def computeOperator(numberStack, operatorLambda):
    """Computes the result of an infix operator and adds it to the stack. If an
    error occurs whilst doing so, the function returns the error statement. If
    the computation was successful, nothing is returned."""
    a, b = None, None

    try:
        b = numberStack.pop()
        a = numberStack.pop()
    except IndexError:
        return "Missmatched operators!"

    # catch a potential division by zero exception
    try:
        numberStack.append(operatorLambda(a, b))
    except ZeroDivisionError:
        return "Division by zero!"

    # special case for 0^0 (Python thinks it's 0)
    if (a == 0 and b == 0 and operatorLambda(a, b) == 1):
        return "Result undefined!"


def computeFunction(number_stack, function_lambda):
    """Computes a one-parameter (function) lambda on a number. If an error
    occurs whilst doing so, the function returns the error statement. If the
    computation was successful, nothing is returned."""
    try:
        number = number_stack.pop()
    except IndexError:
        return "Empty function!"

    try:
        result = function_lambda(number)
    except ValueError:
        return "Incorrect function domain!"

    number_stack.append(result)


def _get_number_end_index(i, expr):
    """Returns the ending index of a number starting at a certain index."""
    while i < len(expr) and (expr[i].isdigit() or expr[i] == "."):
        i += 1

    return i


def _get_function_start_index(j, expr):
    """Return the starting index of a function ending at a certain index."""
    while j >= 0 and expr[j].isalpha():
        j -= 1

    return j + 1
