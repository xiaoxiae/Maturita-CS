def generatePartitions(number, partitionList, startingPartitionIndex):
    """Recursively prints all partitions of a number."""
    if number == 0:
        print(partitionList)

    # Try all of the partitions
    for i in range(startingPartitionIndex, len(partitions)):
        partition = partitions[i]

        # If it fits into the number, recursivelly send it through
        if number - partition >= 0:
            partitionList.append(partition)
            generatePartitions(number - partition, partitionList, i)
            partitionList.pop()
        else:
            break

number = int(input("Input a number to partition: "))

partitions = [x for x in range(1, number + 1)]

generatePartitions(number, [], 0)

input()
