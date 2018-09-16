print("How big of a factorial to calculate: ", end="")
factorial = int(input())

# Reverse the input (and convert to numbers) to operate easily
result = [int(char) for char in reversed(str(factorial))]

# Multiply by all the numbers from 2 to i - 1
for i in range(2, factorial):
    carry = 0

    # Like normal multiplication - multiply digits, carry the remainder
    for j in range(0, len(result)):
        result[j] = result[j] * i + carry
        carry = result[j] // 10
        result[j] %= 10

    # If the carry is non-zero, create new digits
    while carry != 0:
        result.append(carry % 10)
        carry //= 10

# Print the result (it's reversed, so print in reverse)
print(str(factorial)+"! = ", end="")
for number in reversed(result):
    print(number, end="")
    
input()
