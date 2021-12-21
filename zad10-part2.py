from math import floor as pod

with open("input.txt") as f:
    lines = f.readlines()

def IsCorrupted(line):
    stog = []
    left = ['(','[','{','<']
    right = [')',']','}','>']
    # loopaj do predzadnjeg elementa jer je zadnji '\n'
    for i in range(len(line) - 1):
        if line[i] in left:
            stog.append(line[i])
        else:
            if len(stog) == 0 or right.index(line[i]) != left.index(stog[-1]):
                return True
            else:
                stog.pop()
    return False

def GetScore(line):
    stog = []
    left = ['(','[','{','<']
    right = [')',']','}','>']
    score = 0
    for bracket in line[:-1]:
        if bracket in left:
            stog.append(bracket)
        else:
            stog.pop()
    for bracket in reversed(stog):
        score *= 5
        score += left.index(bracket) + 1
    return score

# Discarding corrupted lines
toRemove = []
for i in range(len(lines)):
    if IsCorrupted(lines[i]):
        toRemove.append(i)
for i in reversed(toRemove):
    lines.pop(i)

# Calculating scores for the remaining lines
scores = []
for line in lines:
    scores.append(GetScore(line))
scores.sort()
print(scores[pod(len(scores)/2)])
