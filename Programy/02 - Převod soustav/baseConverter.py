chars = "0123456789ABCDEF"

# get conversion information
numberString = input("The number to convert: ")
baseFrom = int(input("Base to convert from: "))
baseTo = int(input("Base to convert to: "))

# converts the number to base 10
sum = 0
for char in numberString:
    sum = sum * baseFrom + chars.index(char)

# convers the number to the specified base
result = ""
while sum > 0:
    result = chars[int(sum % baseTo)] + result
    sum = (sum - (sum % baseTo)) // baseTo

print("Number "+numberString+" in base "+str(baseTo)+" is "+result)

input()
