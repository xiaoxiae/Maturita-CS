factorial = int(input("How big of a factorial to calculate: "))

# reverse the input (and convert to numbers) to operate easily
result = [int(char) for char in reversed(str(factorial))]

# multiply by all the numbers from 2 to i - 1
for i in range(2, factorial):
    carry = 0

    # like normal multiplication - multiply digits, carry the remainder
    for j in range(len(result)):
        result[j] = result[j] * i + carry
        carry = result[j] // 10
        result[j] %= 10

    # if the carry is non-zero, create new digits
    while carry != 0:
        result.append(carry % 10)
        carry //= 10

# print the result (it's reversed, so print in reverse)
print(str(factorial)+"! = ", end="")

# 0! = 1
if factorial == 0:
    print("1")
else:
    for number in reversed(result):
        print(number, end="")

input()
