
# getting input
with open("input.txt") as f:
    lines = f.readlines()[0]

ulaz = lines.split(',')
for i in range(len(ulaz)):
    ulaz[i] = int(ulaz[i])


# calculating price for a given position
def getPrice(array, position):
    price = 0
    for i in array:
        price += abs(i - position)
    return price


# main loop
minPosition = min(ulaz)
maxPosition = max(ulaz)
minPrice = getPrice(ulaz, minPosition)

for position in ulaz:
    price = getPrice(ulaz, position)
    if price < minPrice:
        minPrice = price
print(minPrice)
