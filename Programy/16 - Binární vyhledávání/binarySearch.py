from random import randint


def binary_search(sorted_list, element):
    """Performs a binary search on a sorted list."""
    # generate starting and ending boundaries
    start, end = 0, len(sorted_list)

    while start < end:
        pivot = (start + end) // 2

        # if the number is not pivot, cut the interval in half in the appropriate direction
        if element < sorted_list[pivot]:
            end = pivot - 1
        elif element > sorted_list[pivot]:
            start = pivot + 1
        else:
            # to find the very first occurrence in the sorted list
            end = pivot

    if sorted_list[start] == element:
        return start
    else:
        return -1


size = int(input("Generate random integer list of size: "))
generated_list = sorted([randint(0, size) for _x in range(0, size)])
print("Generated list: " + str(generated_list))

number = int(input("Number to search for: "))
input("Index of the number: " + str(binary_search(generated_list, number)))
