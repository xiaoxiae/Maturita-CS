limit = int(input("The limit under which to look for primes: "))

# create a boolean array
sieve_list = [True] * limit
primes = []

for i in range(2, limit):
    # if the number hasn't been crossed out, cross out all its multiplicands and add it to the list
    if sieve_list[i]:
        primes.append(i)

        # start at i^2 -- every smaller multiple has been crossed-out already
        for j in range(i * i, limit, i):
            sieve_list[j] = False

input("Primes under " + str(limit) + ": " + str(primes))
