from matrix import Matrix

a = Matrix([[0, 1, 0, 0], [0, 0, 1, 0], [0, 0, 0, 1], [1, 1, 1, 1]])

result = a
for i in range(50):
    result *= a

print(result)