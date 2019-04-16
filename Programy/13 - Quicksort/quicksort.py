from random import randint


def quicksort(array, start, end):
    """Sorts the list using quicksort."""
    pivot = array[start]

    i, j = start, end

    # find numbers on both sides that should be swapped
    while i <= j:
        while array[i] < pivot:
            i += 1
        while array[j] > pivot:
            j -= 1

        if i <= j:
            array[i], array[j] = array[j], array[i]
            i, j = i + 1, j - 1

    # send only if there is more than 1 element on either side of the pivots
    if start < j:
        quicksort(array, start, j)
    if end > i:
        quicksort(array, i, end)


array_size = int(input("How big of a list to generate: "))
array = [randint(-array_size, array_size) for _x in range(0, array_size)]

print("Randomly generated list: " + str(array), end="\n")

quicksort(array, 0, len(array) - 1)

input("Sorted list: " + str(array))
