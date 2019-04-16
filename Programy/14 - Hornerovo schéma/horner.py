coefficients = [int(c) for c in input("Input coefficients: ").split(" ")]
x = int(input("Input the x value: "))

value = coefficients[0]
for i in range(1, len(coefficients)):
    value = x * value + coefficients[i]

input("y = " + str(value))
