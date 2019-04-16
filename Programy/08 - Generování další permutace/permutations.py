def permutations(array):
    """Generates all lexicographic permutations of a list of numbers."""

    # go from the end till the numbers stop rising
    i = len(array) - 1
    while i >= 1:
        if array[i - 1] < array[i]:
            # find the next bigger number from the end to [i - 1] and swap it
            for j in reversed(range(i, len(array))):
                if array[j] > array[i - 1]:
                    array[i - 1], array[j] = array[j], array[i - 1]

                    # reverse the numbers from the end that are consecutive
                    for k in range(i, len(array) - (len(array) - i) // 2):
                        reverseK = i + (len(array) - k - 1)

                        array[k], array[reverseK] = array[reverseK], array[k]

                    # yield the new permutation and start the process over
                    yield array
                    i = len(array) - 1
                    break
        else:
            i -= 1
    return None


size = int(input("How big of a list to generate permutations of: "))
l = [x for x in range(1, size + 1)]

print(l)
for permutation in permutations(l):
    print(permutation)

input()
