from PIL import Image
from scipy.ndimage import morphology
import matplotlib.pyplot as plt
import numpy as np

brightness = 30
contrast = 2.5

im_RGB = Image.open('sample_f.jpg')
im_gray = np.array(im_RGB.convert('L')) # szürkeárnyalatossá konvertálás
im_gray = np.uint8(np.maximum(0, np.minimum(255, contrast * im_gray + brightness))) # fényerő, kontraszt állításával kiemelem az alakzatot
plt.figure(), plt.xlabel('x'), plt.ylabel('y')
plt.hist(im_gray.flatten(), bins=10)

im_bin = 1 - (im_gray > 230) & (im_gray < 260) # hisztogram alapján küszöbérték állításával bináris kép létrehozása
im_bin = morphology.binary_closing(im_bin, np.ones([5,5])) # alakzaton belüli pepper eltüntetése
im_bin = morphology.binary_opening(im_bin, np.ones([5,5])) # alakzaton kívüli salt eltüntetése

# középpont keresése
X, Y = im_RGB.size
x_coords = []
y_coords = []
for x in range(X):
    for y in range(Y):
        if (im_bin[y][x] == True):
            x_coords.append(x)
            y_coords.append(y)
center_x = np.int(np.round(np.average(x_coords)))
center_y = np.int(np.round(np.average(y_coords)))

print(f"Az alakzat középpontja: ({center_x}, {center_y}).")
plt.figure()
plt.imshow(im_RGB)
plt.plot(center_x, center_y, "+")