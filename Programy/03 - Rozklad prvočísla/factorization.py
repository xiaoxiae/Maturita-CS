from math import sqrt, floor

number = int(input("The number to factorize: "))

# go through all the numbers under sqrt(num) and check, whether they are factors
factors = []
for i in range(2, floor(sqrt(number))):
    while number % i == 0:
        number //= i
        factors.append(i)

# if the number isn't fully divided, add the remaining factor
if number != 1:
    factors.append(number)

input("Factors: " + str(factors))
