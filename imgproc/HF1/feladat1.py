from PIL import Image
from scipy.ndimage import filters
import matplotlib.pyplot as plt
import numpy as np

im_RGB = Image.open('pattern_o.tif')
im_gray = im_RGB.convert('L')
im_gray_array = np.array(im_gray)

plt.figure()
plt.imshow(im_gray, 'gray')
plt.savefig('feladat1_input.png')

mask_A = np.array([[-1, -1, 0], [-1, 0, 1], [0, 1, 1]])
mask_B = np.array([[0, -1, -1], [1, 0, -1], [1, 1, 1]])
mask_D = np.array([[-1, -1, -1], [-1, 8, -1], [-1, -1, -1]])

im_A = filters.convolve(im_gray, mask_A)
im_B = filters.convolve(im_gray, mask_B)
im_C = filters.laplace(im_gray)
im_D = filters.convolve(im_gray, mask_D)

out_images = [im_A, im_B, im_C, im_D]
out_labels = ['a)', 'b)', 'c)', 'd)']
plt.figure()
for i in range(4):
    plt.subplot(2, 2, i+1)
    plt.xticks([])
    plt.yticks([])
    plt.imshow(out_images[i], 'gray')
    plt.xlabel(out_labels[i])
plt.savefig('feladat1_output.png')