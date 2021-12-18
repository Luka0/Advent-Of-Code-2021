with open("input.txt") as f:
    lines = f.readlines()

c = 0
for i in range(len(lines)):
    lines[i] = lines[i].split(" | ")
    lines[i][0] = lines[i][0].split()
    lines[i][1] = lines[i][1].split()
    for element in lines[i][1]:
        if len(element) in [2, 3, 4, 7]:
            c += 1

print(c)
