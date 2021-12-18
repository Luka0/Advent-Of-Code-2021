# formatting the input
with open('test_input.txt') as f:
    lines = f.readlines()

ulaz = lines[0].split(',')
for i in range(len(ulaz)):
    ulaz[i] = int(ulaz[i])


# main loop
for i in range(180):
    n = len(ulaz)
    for j in range(n):
        if ulaz[j] == 0:
            ulaz[j] = 6
            ulaz.append(8)
        else:
            ulaz[j] -= 1
print(len(ulaz))
