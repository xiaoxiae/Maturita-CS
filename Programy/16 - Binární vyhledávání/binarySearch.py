from random import randint

def binarySearch(list, element):
    # Generate starting and ending boundaries
    start = 0
    end = len(list)
    found = False

    while start < end:
        pivot = (start + end) // 2

        # If the number is not pivot, cut the interval in half
        if number < list[pivot]:
            end = pivot - 1
        elif number > list[pivot]:
            start = pivot + 1
        else:
            # We still need to make sure that this is the first occurence
            end = pivot
            found = True

    if (found):
        return start
    else:
        return -1


listSize = int(input("Generate random list of size: "))
list = sorted([randint(0, listSize) for _x in range(0, listSize)])

print("List: "+str(list))

number = int(input("Number to search for: "))

print("Index of the number: "+str(binarySearch(list, number)))

input()
