from operations import angle, distance

def get_action(landmark):

    right_ear_x, right_ear_y = landmark[7].x, landmark[7].y
    left_ear_x, left_ear_y = landmark[8].x, landmark[8].y
    right_elbow_x, right_elbow_y = landmark[13].x, landmark[13].y
    left_elbow_x, left_elbow_y = landmark[14].x, landmark[14].y
    right_wrist_x, right_wrist_y = landmark[15].x, landmark[15].y
    left_wrist_x, left_wrist_y = landmark[16].x, landmark[16].y
    right_shoulder_x, right_shoulder_y = landmark[11].x, landmark[11].y
    left_shoulder_x, left_shoulder_y = landmark[12].x, landmark[12].y

    guard_conditions = [
        right_wrist_y < 1.5 * right_shoulder_y,
        left_wrist_y < 1.5 * left_shoulder_y,

        right_shoulder_y < right_elbow_y,
        left_shoulder_y < left_elbow_y,

        int(angle(right_elbow_x, right_elbow_y, right_wrist_x, right_wrist_y)) in range(80, 120),
        int(angle(left_elbow_x, left_elbow_y, left_wrist_x, left_wrist_y)) in range(60, 100),

        int(angle(right_elbow_x, right_elbow_y, right_shoulder_x, right_shoulder_y)) in range(80, 130),
        int(angle(left_elbow_x, left_elbow_y, left_shoulder_x, left_shoulder_y)) in range(50, 120)
    ]


    jab_conditions = [
        right_wrist_y < 1.5 * right_shoulder_y,
        right_shoulder_y < right_elbow_y,

        int(angle(right_elbow_x, right_elbow_y, right_wrist_x, right_wrist_y)) in range(80, 120),
        int(angle(right_elbow_x, right_elbow_y, right_shoulder_x, right_shoulder_y)) in range(80, 130),

        distance(left_wrist_x, left_wrist_y, left_shoulder_x, left_shoulder_y) < 3*distance(right_ear_x, right_ear_y, left_ear_x, left_ear_y),
        distance(left_elbow_x, left_elbow_y, left_shoulder_x, left_shoulder_y) < 3*distance(right_ear_x, right_ear_y, left_ear_x, left_ear_y),
    ]

    cross_conditions = [
        left_wrist_y < 1.5 * left_shoulder_y,
        left_shoulder_y < left_elbow_y,

        int(angle(left_elbow_x, left_elbow_y, left_wrist_x, left_wrist_y)) in range(60, 100),
        int(angle(left_elbow_x, left_elbow_y, left_shoulder_x, left_shoulder_y)) in range(50, 120),

        distance(right_wrist_x, right_wrist_y, right_shoulder_x, right_shoulder_y) < 3*distance(right_ear_x, right_ear_y, left_ear_x, left_ear_y),
        distance(right_elbow_x, right_elbow_y, right_shoulder_x, right_shoulder_y) < 3*distance(right_ear_x, right_ear_y, left_ear_x, left_ear_y),
    ]

    if all(guard_conditions):
        current_action = "In guard"
    elif all(jab_conditions):
        current_action = "LeadJab"
    elif all(cross_conditions):
        current_action = "Cross"
    else:
        current_action = "Out of Guard" 

    return current_action

    """
    Old jab conditions     
    abs(right_shoulder_x - right_elbow_x) < 0.2, 
    abs(left_shoulder_x - left_elbow_x) < 0.3, 

    abs(right_wrist_x - right_elbow_x) < 0.1, 
    abs(left_wrist_x - left_elbow_x) < 0.1,
    
    abs(left_shoulder_y - left_elbow_y) < 0.125, 
    abs(left_wrist_y - left_shoulder_y) < 0.125,
    
    abs(right_shoulder_y - right_elbow_y) > 0.15,
    abs(right_wrist_y - right_shoulder_y) + abs(right_wrist_y - right_ear_y) < 0.3
    """

    """ 
    Old guard conditions       
    abs(right_shoulder_x - right_elbow_x) < 0.2, 
    abs(left_shoulder_x - left_elbow_x) < 0.2, 

    abs(right_wrist_x - right_elbow_x) < 0.1, 
    abs(left_wrist_x - left_elbow_x) < 0.1,
    
    abs(right_shoulder_y - right_elbow_y) > 0.15, 
    abs(left_shoulder_y - left_elbow_y) > 0.15, 
    
    abs(right_wrist_y - right_shoulder_y) + abs(right_wrist_y - right_ear_y) < 0.3, 
    abs(left_wrist_y - left_shoulder_y) + abs(left_wrist_y - left_ear_y) < 0.3
    """