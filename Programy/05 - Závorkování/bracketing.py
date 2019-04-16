arithmetic_expression = input("Input an arithmetic expression to check: ")

# brackets to look for
opening_brackets = ['(', '[', '{']
closing_brackets = [')', ']', '}']

# a stack to keep the opening brackets in
bracket_list = []

for char in arithmetic_expression:
    for i in range(len(opening_brackets)):
        # if it's opening, add it to the stack
        if char == opening_brackets[i]:
            bracket_list.append(char)
        elif char == closing_brackets[i]:
            # if the opposite one isn't in the stack or the stack is empty, the
            # bracketing is wrong
            if len(bracket_list) != 0 and bracket_list[-1] == opening_brackets[i]:
                bracket_list.pop()
            else:
                input("Wrong!")
                quit()

# if there are no remaining brackets to be closed, the expression is correct
if len(bracket_list) == 0:
    input("Right!")
else:
    input("Wrong!")
