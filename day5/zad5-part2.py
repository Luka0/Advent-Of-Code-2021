# formatting the input
with open('input.txt') as f:
    lines = f.readlines()

ulaz = []
for l in lines:
    a = l.split(" -> ");
    for i in range(2):
        a[i] = a[i].split(',')
    for i in range(2):
        for j in range(2):
            a[i][j] = int(a[i][j])
    ulaz.append(a)

# finding the biggest x and y value(matrix size)
maxX = 0
maxY = 0
for line in ulaz:
    for point in line:
        if point[0] > maxX:
            maxX = point[0]
        if point[1] > maxY:
            maxY = point[1]

matrix = [[0 for i in range(maxX + 1)] for j in range(maxY + 1)]

# za svaki range u ulazu:
#   za svaku tocku u range-u:
#       mjesto s tim indexom += 1
for line in ulaz:
    if line[0][0] == line[1][0]:
        #vertikalna linija
        for i in range(min(line[0][1], line[1][1]), max(line[0][1], line[1][1])+1):
            matrix[i][line[0][0]] += 1
    elif line[0][1] == line[1][1]:
        #horizontalna linija
        for i in range(min(line[0][0], line[1][0]), max(line[0][0], line[1][0])+1):
            matrix[line[0][1]][i] += 1
    else:
        if (line[0][0] <= line[1][0] and line[0][1] <= line[1][1]) or (line[0][0] >= line[1][0] and line[0][1] >= line[1][1]):
            # glavno-dijagonalne linije
            t1 = [min(line[0][0], line[1][0]), min(line[0][1], line[1][1])]
            t2 = [max(line[0][0], line[1][0]), max(line[0][1], line[1][1])]

            for i in range(0, t2[0] - t1[0] + 1):
                matrix[t1[1]+i][t1[0]+i] += 1
        else:
            # sporedno-dijagonalne linije
            t1 = [min(line[0][0], line[1][0]), max(line[0][1], line[1][1])]
            t2 = [max(line[0][0], line[1][0]), min(line[0][1], line[1][1])]
            for i in range(0, t2[0] - t1[0] + 1):
                matrix[t1[1]-i][t1[0]+i] += 1


# za svaku tocku u matrix:
#   ako je tocka > 1: counter += 1
# vrati counter
counter = 0;
for row in matrix:
    for point in row:
        if point > 1:
            counter += 1

print(counter)
