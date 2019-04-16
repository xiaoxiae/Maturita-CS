def generate_partitions(number, partition_list, starting_partition_index):
    """Recursively prints all partitions of a number."""
    if number == 0:
        print(partition_list)

    # try all of the partitions
    for i in range(starting_partition_index, len(partitions)):
        partition = partitions[i]

        # if it fits into the number, recursively call itself
        if number - partition >= 0:
            partition_list.append(partition)
            generate_partitions(number - partition, partition_list, i)
            partition_list.pop()
        else:
            break


number = int(input("Input a number to partition: "))
partitions = [x for x in range(1, number + 1)]

generate_partitions(number, [], 0)

input()
