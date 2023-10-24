import numpy as np

def angle(p1_x, p1_y, p2_x, p2_y):

    p1 = (p1_x, p1_y)
    p2 = (p2_x, p2_y)

    dx = p2[0] - p1[0]
    dy = p2[1] - p1[1]

    angle = np.arctan2(dy, dx) * 180 / np.pi


    return abs(angle) 

def distance(p1_x, p1_y, p2_x, p2_y):

    return np.sqrt((p2_x - p1_x)**2 + (p2_y - p1_y)**2)