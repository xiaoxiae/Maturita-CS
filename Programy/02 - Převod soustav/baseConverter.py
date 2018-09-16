chars = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"]

# Get the information for conversion
print("The number to convert: ", end="")
number = list(reversed(input()))

print("Base to convert from: ", end="")
baseFrom = int(input())

print("Base to convert to: ", end="")
baseTo = int(input())

# Converts the number to base 10
sum = sum([chars.index(number[i]) * baseFrom**i for i in range(0, len(number))])

# Convers the number to the specified base
result = ""
while sum > 0:
    result = chars[int(sum % baseTo)] + result
    sum = (sum - (sum % baseTo)) // baseTo

print("Number "+"".join(reversed(number))+" in base "+str(baseTo)+" is "+result)

input()
