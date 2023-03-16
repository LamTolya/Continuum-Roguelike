for x in 0,1:
    for y in 0,1:
        for z in 0,1:
            for w in 0,1:
                if ((x and not(y)) or (y == z) or w) == False:
                    print(x, y, z, w)