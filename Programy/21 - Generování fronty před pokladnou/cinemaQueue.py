def recursive_queue(g1, g2, queue, remainder):
    # if we're all out of people, we are done
    if g1 + g2 == 0:
        print(queue)
        return

    # if there is a remainder and we can pick people from group 2, do so
    if remainder >= 1 and g2 >= 1:
        queue[len(queue) - (g1 + g2)] = 20  # the person gave a 20
        recursive_queue(g1, g2 - 1, queue, remainder - 1)

    # if there are any people in group 1, do so
    if g1 >= 1:
        queue[len(queue) - (g1 + g2)] = 10  # the person gave a 10
        recursive_queue(g1 - 1, g2, queue, remainder + 1)


groupSize = int(input("How many people are there in each of the groups: "))
groupSizeList = [0 for _x in range(groupSize * 2)]

recursive_queue(groupSize, groupSize, groupSizeList, 0)

input()
