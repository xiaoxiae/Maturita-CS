def recursiveQueue(group1, group2, queue, remainder):
    # if we're all out of people, we are done
    if group1 + group2 == 0:
        print(queue)
        return

    # if there is a remainder and we can pick people from group 2, do so
    if remainder >= 1 and group2 >= 1:
        queue[len(queue) - (group1 + group2)] = 20  # the person gave a 20
        recursiveQueue(group1, group2 - 1, queue, remainder - 1)

    # if there are any people in group 1, do so
    if group1 >= 1:
        queue[len(queue) - (group1 + group2)] = 10  # the person gave a 10
        recursiveQueue(group1 - 1, group2, queue, remainder + 1)

groupSize = int(input("How many people are there in each of the groups: "))
groupSizeList = [0 for _x in range(groupSize * 2)]

recursiveQueue(groupSize, groupSize, groupSizeList, 0)

input()
