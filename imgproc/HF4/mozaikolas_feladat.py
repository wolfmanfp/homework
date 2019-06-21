import matplotlib.pyplot as plt
import numpy as np
from PIL import Image
from scipy.ndimage import filters
from skimage.transform import resize

sigma = 5
num_of_dogs = 5
sigma_mul = 1.5
dog_list = []
dog_list_2 = []

image_file = 'anim1.tif'
image_file_2 = 'anim2.tif'

im_RGB = Image.open(image_file)
im_RGB_2 = Image.open(image_file_2)
im_gray = np.float64(im_RGB.convert('L'))
im_gray_2 = np.float64(im_RGB_2.convert('L'))

def create_dogs(img, dl):
    for i in range(0, num_of_dogs):
        im_filt = filters.gaussian_filter(img, sigma)
        dog = img - im_filt
        dl.append(dog)
        if i < num_of_dogs-1:
            img = resize(im_filt, (len(im_filt)/2, len(im_filt[0])/2))
    return img

im_gray = create_dogs(im_gray, dog_list)
im_gray_2 = create_dogs(im_gray_2, dog_list_2)
dog_list.reverse(), dog_list_2.reverse()

for i in range(0, num_of_dogs):
    half_index = np.uint16(len(im_gray)/2)
    im_gray[:, :half_index] += dog_list[i][:, :half_index]
    if i == 0:
        im_gray[:, half_index:] = im_gray_2[:, half_index:]
    im_gray[:, half_index:] += dog_list_2[i][:, half_index:]
    if i < num_of_dogs-1:
        im_gray = resize(im_gray, (len(im_gray)*2, len(im_gray[0])*2), mode='edge')
    else:
        plt.figure()
        plt.imshow(im_gray, 'gray')
    