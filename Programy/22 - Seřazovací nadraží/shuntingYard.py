from math import log, acos, asin, atan, cos, sin, tan, e, sqrt, radians, degrees

def evaluateExpression(expression):
    """Evaluates an arithmetic expression."""
    # TODO: Add support for multiple types of parentheses.
        # TODO: Correctly handle bracketing issues (without another function)

    # Synthesize the input
    expression = expression.replace(" ", "")

    # Return nothing if the input is empty after synthetization
    if len(expression) == 0:
        return ""
    elif not isBracketingCorrect(expression):
        return "Wrong bracketing!"

    # Information about operators
    operators = {"+":[lambda a, b: a+b, 1],
                 "-":[lambda a, b: a-b, 1],
                 "*":[lambda a, b: a*b, 2],
                 "%":[lambda a, b: a%b, 2],
                 "/":[lambda a, b: a/b, 2],
                 "^":[lambda a, b: a**b, 3]}

    # The function dictionary
    functions = {"log":lambda x: log(x, 10),
                 "ln":lambda x: log(x, e),
                 "acos":lambda x: acos(x),
                 "asin":lambda x: asin(x),
                 "atan":lambda x: atan(x),
                 "cos":lambda x: cos(x),
                 "sin":lambda x: sin(x),
                 "tan":lambda x: tan(x),
                 "rad":lambda x: radians(x),
                 "deg":lambda x: degrees(x),
                 "sqrt":lambda x: sqrt(x)}

    numberStack = []    # Used for computing the expression
    operatorStack = []  # Operators waiting to be used

    i = 0

    while i < len(expression):
        if expression[i].isdigit(): # If it's a digit
            multiplier = 1

            j = getNumberEndIndex(i, expression)
            number = expression[i:j]

            # If there is a - in front of the word and no number in front of it
            if i - 1 >= 0 and (expression[i - 1] == "-"):
                if i - 2 < 0 or not expression[i - 2].isdigit():
                    multiplier = -1

            # If there is a dot in it, try to parse it (there could be two dots)
            if "." in number:
                try:
                    numberStack.append(float(number) * multiplier)
                except ValueError:
                    return "Incorrect decimal number!"
            else:
                numberStack.append(int(number) * multiplier)

            # i gets incremented at the end of the while loop, that's why -1
            i = j - 1

        elif expression[i].isalpha():   # If it's a letter, ignore it
            pass
        elif expression[i] == "(":  # If it's an opening bracket
            # If there is a function in front of it, get the starting index
            j = getFunctionStartIndex(i - 1, expression)

            # append empty string or the function name (doesn't matter, neither)
            # of those is an operator
            operatorStack.append(expression[j:i])

        elif expression[i] == ")":  # If it's a closing bracket
            # Compute all the possible operators on the stack
            while operatorStack[-1] in operators:
                operator = operators[operatorStack.pop()][0]
                computeResult = computeOperator(numberStack, operator)
                if computeResult != None:
                    return computeResult

            # This can't be an operator, so it must be the closing bracket
            stopString = operatorStack.pop()

            # Checks if the opening bracket is a function by any chance
            if stopString in functions:
                # Computes the value of the function on the top stack number
                function = functions[stopString]
                result = computeFunction(numberStack, function)
                if result != None:
                    return result

        elif expression[i] in operators:    # If it's an operator
            # If it's a + or - and the number stack is empty, ignore it
            if expression[i] == "+" or expression[i] == "-":
                if i == 0 or expression[i - 1] == "(":
                    i += 1
                    continue

            operator = operators[expression[i]]

            # Compute all operators that are of the same or higher rank
            while len(operatorStack) > 0 and operatorStack[-1] in operators:
                if operators[operatorStack[-1]][1] >= operator[1]:
                    operator = operators[operatorStack.pop()][0]
                    computeResult = computeOperator(numberStack, operator)
                    if computeResult != None:
                        return computeResult
                else:
                    break

            # Only then add the operator to the stack
            operatorStack.append(expression[i])

        i += 1

    # Compute the remainding operators on the stack
    while len(operatorStack) != 0:
        operator = operators[operatorStack.pop()][0]
        computeResult = computeOperator(numberStack, operator)
        if computeResult != None:
            return computeResult

    if len(numberStack) != 1:
        return "Invalid expression!"
    else:
        return numberStack[0]

def isBracketingCorrect(expression):
    """Checks, whether bracketing used in an expression is correct"""
    # Brackets to look for
    openBrackets = ['(', '[', '{']
    closeBrackets = [')', ']', '}']

    # A stack to keep the opening brackets in
    brStack = []

    for char in expression:
        # Look trough both the bracket groups
        for i in range(0, len(openBrackets)):
            # If it's opening, add it to the stack
            if char == openBrackets[i]:
                brStack.append(char)
            elif char == closeBrackets[i]:
                # If it's closing, if the opposite one isn't in the stack or the
                # stack is empty, the bracketing is wrong
                if len(brStack) != 0 and brStack[-1] == openBrackets[i]:
                    brStack.pop()
                else:
                    return False

    # If there are remaining opening brackets, the bracketing is wrong
    if len(brStack) != 0:
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

    # Special case for 0^0 (Python thinks it's 1 and it really is not)
    if (a == 0 and b == 0 and operatorLambda(a, b) == 1):
        return "Result undefined!"

    try:
        numberStack.append(operatorLambda(a, b))
    except ZeroDivisionError:
        return "Division by zero!"

def computeFunction(numberStack, functionLambda):
    """Computes a one-parameter (function) lambda on a number. If an error
    occurs whilst doing so, the function returns the error statement. If the
    computation was successful, nothing is returned."""
    number, result = None, None

    try:
        number = numberStack.pop()
    except IndexError:
        return "Empty function!"

    try:
        result = functionLambda(number)
    except ValueError:
        return "Incorrect function domain!"

    numberStack.append(result)

def getNumberEndIndex(i, expr):
    """Returns the ending index of a number starting at a certain index."""
    while i < len(expr) and (expr[i].isdigit() or expr[i] == "."):
        i += 1

    return i

def getFunctionStartIndex(j, expr):
    """Return the starting index of a function ending at a certain index."""
    while j >= 0 and expr[j].isalpha():
        j -= 1

    return j + 1

# The "user interface"
while True:
    expression = input("> ")
    evaluatedExpression = evaluateExpression(expression)

    # If the function returned an expression
    if evaluatedExpression != "":
        print(evaluatedExpression)
