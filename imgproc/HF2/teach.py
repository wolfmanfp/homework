from PIL import Image
import matplotlib.pyplot as plt
import numpy as np
import glob

ROI = (150, 95, 220, 250)
R_lista = []
G_lista = []
B_lista = []
green_log = np.array([0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0])

for filename in glob.glob('teach/*.png'):
    im_RGB = Image.open(filename)
    im_crop = im_RGB.crop(ROI)
    im_crop_array = np.array(im_crop)
    R_lista.append(im_crop_array[:,:,0].mean())
    G_lista.append(im_crop_array[:,:,1].mean())
    B_lista.append(im_crop_array[:,:,2].mean())
    
R_nolog = np.ma.masked_where(green_log == 1, np.array(R_lista))
R_log = np.ma.masked_where(green_log == 0, np.array(R_lista))
G_nolog = np.ma.masked_where(green_log == 1, np.array(G_lista))
G_log = np.ma.masked_where(green_log == 0, np.array(G_lista))

plt.figure()
plt.xlabel('R'), plt.ylabel('G'), plt.grid(True)
plt.scatter(R_nolog, G_nolog, 30, marker='^')
plt.scatter(R_log, G_log, 30, marker='o')