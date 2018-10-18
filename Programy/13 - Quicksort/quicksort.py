from random import randint

def quicksort(list, start, end):
    """Sorts the list using quicksort"""
    pivot = list[start]

    i, j = start, end

    # Find numbers on both sides that should be swapped
    while i <= j:
        while list[i] < pivot:
            i += 1
        while list[j] > pivot:
            j -= 1

        if (i <= j):
            list[i], list[j] = list[j], list[i]
            i, j = i + 1, j - 1

    # Send only if there is more than 1 element on either side of the pivots
    if (start < j):
        quicksort(list, start, j)
    if (end > i):
        quicksort(list, i, end)

listSize = int(input("How big of a list to generate: "))
list = [randint(-listSize, listSize) for _x in range(0, listSize)]

print("Randomly generated list: "+str(list), end="\n")
quicksort(list, 0, len(list) - 1)
print("Sorted list: "+str(list))

input()
