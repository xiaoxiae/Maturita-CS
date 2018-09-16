aithmeticExpression = input()

# Brackets to look for
openingBrackets = ['(', '[', '{']
closingBrackets = [')', ']', '}']

# A stack to keep the opening brackets in
bracketList = []

for char in aithmeticExpression:
    # Look trough both the bracket groups
    for i in range(0, len(openingBrackets)):
        # If it's opening, add it to the stack
        if char == openingBrackets[i]:
            bracketList.append(char)
        elif char == closingBrackets[i]:
            # If it's closing, if the opposite one isn't in the stack or the
            # stack is empty, the bracketing is wrong
            if len(bracketList) != 0 and bracketList[-1] == openingBrackets[i]:
                bracketList.pop()
            else:
                print("Wrong!")
                quit()
print("Right!")

input()
