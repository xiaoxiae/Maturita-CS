def nextPermutation(inputList):
    """Generates the next lexicographic permutation of a list of numbers."""

    # Copy the list - we don't want to be messing with the orignal data
    array = list(inputList)

    # Go from the end and stop, once the numbers stop rising
    for i in reversed(range(1, len(array))):
        if array[i - 1] < array[i]:

            # Find the next bigger number from the end to [i - 1] and swap it
            for j in reversed(range(i, len(array))):
                if array[j] > array[i - 1]:
                    array[i - 1], array[j] = array[j], array[i - 1]

                    # Reverse the numbers from the end that are consecutive
                    for k in range(i, len(array) - (len(array) - i) // 2):
                        reverseK = i + (len(array) - k - 1)

                        array[k], array[reverseK] = array[reverseK], array[k]

                    return array
    return None

listSize = int(input("How big of a list to generate permutations of: "))
array = [x for x in range(1, listSize+1)]

print(array)

# Print out all the permutations
while (nextPermutation(array)) != None:
    array = nextPermutation(array)
    print(array)

input()
