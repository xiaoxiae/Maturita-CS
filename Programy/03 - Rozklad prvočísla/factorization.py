from math import sqrt, floor

number = int(input("The number to factorize: "))

# Go through all the numbers under sqrt(num) and check, if they are factors
factors = []
for i in range(2, floor(sqrt(number))):
    while number % i == 0:
        number //= i
        factors.append(i)

# If the number isn't fully divided, add the remainding factor
if number != 1:
    factors.append(number)

print("Factors: "+str(factors))

input()
