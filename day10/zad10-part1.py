with open("input.txt") as f:
    lines = f.readlines()

#loopaj do predzadnjeg elementa mslm jer je zadnji \n
suma = 0
for line in lines:
    stog = []
    for i in range(len(line) - 1):
        if line[i] in ['<', '(', '[', '{']:
            stog.append(line[i])
        else:
            if ['>',')',']','}'].index(line[i]) == ['<','(','[','{'].index(stog[-1]):
                stog.pop()
            else:
                if line[i] == '>':
                    suma += 25137
                elif line[i] == ')':
                    suma += 3
                elif line[i] == '}':
                    suma += 1197
                else:
                    suma += 57
                break
print(suma)
                
