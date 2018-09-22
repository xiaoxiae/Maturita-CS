limit = int(input("The limit under which to look for primes: "))

# Create a boolean array
sieveList = [True] * limit
primes = []

for i in range(2, limit):
    # If the number hasn't been crossed out, cross out all its multiplicates
    # and add it to the list
    if sieveList[i]:
        primes.append(i)

        for j in range(i * i, limit, i):
            sieveList[j] = False

print("Primes under "+str(limit)+": "+str(primes))

input()
