import cv2
import mediapipe as mp
import pose_calcs

mp_drawing = mp.solutions.drawing_utils
mp_pose = mp.solutions.pose

cap = cv2.VideoCapture(0, cv2.CAP_DSHOW)


with mp_pose.Pose( static_image_mode = False ) as pose:
    while cap.isOpened():
        success, frame = cap.read()
        if not success:
            break

        frame = cv2.flip( frame, 1 )
        height, width, _ = frame.shape
        frame_rgb = cv2.cvtColor( frame, cv2.COLOR_BGR2RGB )
        results = pose.process( frame_rgb )

        if results.pose_landmarks:
            mp_drawing.draw_landmarks( 
                frame, results.pose_landmarks, mp_pose.POSE_CONNECTIONS,
                mp_drawing.DrawingSpec( color = (128, 0, 250), thickness = 2, circle_radius = 2 ),
                mp_drawing.DrawingSpec( color = (255, 255, 255), thickness = 2, circle_radius = 2 ))
          
        landmark = results.pose_landmarks.landmark
        current_action = pose_calcs.get_action(landmark)

        cv2.putText(frame, str(current_action), (10, 20), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 2)
        cv2.imshow('Frame', frame )

        if cv2.waitKey(1) & 0xFF == 27:
            break

cap.release()
cv2.destroyAllWindows()
