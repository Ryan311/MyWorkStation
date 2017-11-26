import numpy as np
import cv2

# Load an color image in grayscale
img = cv2.imread('123.jpg',cv2.IMREAD_COLOR)

# Show the image
cv2.namedWindow('image', cv2.WINDOW_NORMAL)
cv2.imshow('image',img)
cv2.waitKey(0)
cv2.destroyAllWindows()