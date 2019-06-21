# Difference of Gaussians

import matplotlib.pyplot as plt
import numpy as np
from scipy.ndimage import filters
from PIL import Image
from skimage import feature

sigma = 5
num_of_dogs = 9
sigma_mul = 1.5
image_file = 'cat.jpg'

im_RGB = Image.open(image_file)
im_gray = im_RGB.convert('L')

plt.figure(figsize=(16,6))
for i in range(1, num_of_dogs+1):
    im_filt = filters.gaussian_filter(im_gray, sigma)
    dog = np.int16(im_gray) - np.int16(im_filt)
    
    plt.subplot(2, num_of_dogs, i)
    plt.imshow(im_filt, 'gray')
    
    plt.subplot(2, num_of_dogs, i+num_of_dogs)
    plt.imshow(dog, 'hot')
    peaks = feature.peak_local_max(dog, min_distance=10, threshold_rel=0.05, num_peaks=200)
    plt.scatter(peaks[:,1], peaks[:,0])
    
    sigma *= sigma_mul
    im_gray = im_filt