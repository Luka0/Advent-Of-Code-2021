
# getting the input in the right shape
with open("input.txt") as f:
    lines = f.readlines()

for i in range(len(lines)):
    lines[i] = lines[i].split(" | ")
    lines[i][0] = lines[i][0].split()
    lines[i][1] = lines[i][1].split()


# checking if str1 contains every char from str2
def Contains(str1, str2):
    contains = True
    for c in str2:
        if c not in str1:
            contains = False
            break
    return contains


# return the number of common segments between 2 digits
def CommonSegments(str1, str2):
    c = 0
    for i in str1:
        for j in str2:
            if i == j:
                c+=1
    return c


# decoding the digits from a given line of input
def Decode(line):
    # lists of potential candidates for each segment
    digits = ["" for i in range(10)]
    for element in line[0]:
        if len(element) == 2:
            digits[1] = element
        if len(element) == 3:
            digits[7] = element
        if len(element) == 4:
            digits[4] = element
        if len(element) == 7:
            digits[8] = element
    for element in line[1]:
        if len(element) == 2:
            digits[1] = element
        if len(element) == 3:
            digits[7] = element
        if len(element) == 4:
            digits[4] = element
        if len(element) == 7:
            digits[8] = element
    
    for element in line[0]:
        if len(element) == 6:
            # 0 ili 6 ili 9
            if Contains(element, digits[4]):
                digits[9] = element # tu neki if digits[9] == "" ?, da ne prepisem?
            elif Contains(element, digits[1]):
                digits[0] = element
            else:
                digits[6] = element
        elif len(element) == 5:
            # 2 ili 3 ili 5
            if Contains(element, digits[1]):
                digits[3] = element
            elif CommonSegments(element, digits[4]) == 2:
                digits[2] = element
            else:
                digits[5] = element
            
    return digits


# Main Program
decodedDigits = []
for line in lines:
    digits = Decode(line)
    output = ""
    for i in line[1]:
        for j in digits:
            if CommonSegments(i, j) == len(i) and len(i) == len(j):
                output += str(digits.index(j))
                continue
    decodedDigits.append(int(output))
print(sum(decodedDigits))
