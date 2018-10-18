numbers = [int(number) for number in input("Input two numbers: ").split(" ")]

while numbers[1] != 0:
    numbers[0], numbers[1] = min(numbers), max(numbers) % min(numbers)

print("Greatest common denominator: "+str(numbers[0]))
