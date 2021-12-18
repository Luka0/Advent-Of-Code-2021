# getting the input
with open("input.txt") as f:
    lines = f.readlines()

heightmap = [[] for i in range(len(lines))]

for i in range(len(lines)):
    for j in range(len(lines[0]) - 1):
        heightmap[i].append(int(lines[i][j]))


# checks if point is a low point
def IsLowPoint(r, c, hmap):
    if r == 0 and c == 0:
        return hmap[r][c] < hmap[r+1][c] and hmap[r][c] < hmap[r][c+1]
    elif r == 0 and c == len(hmap[0]) - 1:
        return hmap[r][c] < hmap[r][c-1] and hmap[r][c] < hmap[r+1][c]
    elif r == len(hmap) - 1 and c == 0:
        return hmap[r][c] < hmap[r-1][c] and hmap[r][c] < hmap[r][c+1]
    elif r == len(hmap)-1 and c == len(hmap[0])-1:
        return hmap[r][c] < hmap[r-1][c] and hmap[r][c] < hmap[r][c-1]
    elif r == 0:
        return hmap[r][c] < hmap[r][c-1] and hmap[r][c] < hmap[r][c+1] and hmap[r][c] < hmap[r+1][c]
    elif r == len(hmap)-1:
        return hmap[r][c] < hmap[r][c-1] and hmap[r][c] < hmap[r][c+1] and hmap[r][c] < hmap[r-1][c]
    elif c == 0:
        return hmap[r][c] < hmap[r-1][c] and hmap[r][c] < hmap[r+1][c] and hmap[r][c] < hmap[r][c+1]
    elif c == len(hmap[0])-1:
        return hmap[r][c] < hmap[r-1][c] and hmap[r][c] < hmap[r+1][c] and hmap[r][c] < hmap[r][c-1]
    else:
        return hmap[r][c] < hmap[r-1][c] and hmap[r][c] < hmap[r+1][c] and hmap[r][c] < hmap[r][c-1] and hmap[r][c] < hmap[r][c+1]


# calculates and returns the size of a dip around any given lowpoint
def GetDipSize(r, c, hmap):
    suma = 0
    if c - 1 >= 0 and hmap[r][c-1] != 9:
        hmap[r][c-1] = 9
        suma += 1 + GetDipSize(r, c-1, hmap)
    if c + 1 <= len(hmap[0])-1 and hmap[r][c+1] != 9:
        hmap[r][c+1] = 9
        suma += 1 + GetDipSize(r, c+1, hmap)
    if r - 1 >= 0 and hmap[r-1][c] != 9:
        hmap[r-1][c] = 9
        suma += 1 + GetDipSize(r-1, c, hmap)
    if r + 1 <= len(hmap)-1 and hmap[r+1][c] != 9:
        hmap[r+1][c] = 9
        suma += 1 + GetDipSize(r+1, c, hmap)
    return suma


# main loop
rows = len(heightmap)
columns = len(heightmap[0])
dips = []

for row in range(rows):
    for c in range(columns):
        if IsLowPoint(row, c, heightmap):
            dips.append(GetDipSize(row, c, heightmap.copy()))

dips = sorted(dips, reverse=True)
print(dips[0] * dips[1] * dips[2])
