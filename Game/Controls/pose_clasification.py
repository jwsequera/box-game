from operations import angle 
from pose_calcs import get_action

def determine_action(landmark):

        right_ear_x, right_ear_y = landmark[7].x, landmark[7].y
        left_ear_x, left_ear_y = landmark[8].x, landmark[8].y
        right_elbow_x, right_elbow_y = landmark[13].x, landmark[13].y
        left_elbow_x, left_elbow_y = landmark[14].x, landmark[14].y
        right_wrist_x, right_wrist_y = landmark[15].x, landmark[15].y
        left_wrist_x, left_wrist_y = landmark[16].x, landmark[16].y
        right_shoulder_x, right_shoulder_y = landmark[11].x, landmark[11].y
        left_shoulder_x, left_shoulder_y = landmark[12].x, landmark[12].y


        #Determinating the current position



        '''
        if  all(guard_conditions):
            current_action = "In guard"

        elif all(jab_conditions):
            current_action = "Jab"

        else: 
            current_action = "Out of Guard"'''
        
        
        # current_action = angle(left_elbow_x, left_elbow_y, left_shoulder_x, left_shoulder_y)
        current_action = get_action(landmark)

        return current_action
