numbers = [int(number) for number in input("Input two numbers: ").split(" ")]

a, b = min(numbers), max(numbers)

while a != 0:
    a, b = b % a, a

input("Greatest common denominator: " + str(b))
