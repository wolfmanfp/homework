from PIL import Image
import matplotlib.pyplot as plt
import numpy as np
import glob

m = 0.8333
c = 50

ROI = (150, 95, 220, 250)
R_lista = []
G_lista = []
dontes = []
filenames = []

for filename in glob.glob('test/*.png'):
    filenames.append(filename)
    im_RGB = Image.open(filename)
    im_crop = im_RGB.crop(ROI)
    im_crop_array = np.array(im_crop)
    R_avg = im_crop_array[:,:,0].mean()
    R_lista.append(R_avg)
    G_avg = im_crop_array[:,:,1].mean()
    G_lista.append(G_avg)
    G = m * R_avg + c
    if G_avg < G:
        dontes.append(0)
    else:
        dontes.append(1)
    
dontes = np.array(dontes)
R_nocap = np.ma.masked_where(dontes == 1, np.array(R_lista))
R_cap = np.ma.masked_where(dontes == 0, np.array(R_lista))
G_nocap = np.ma.masked_where(dontes == 1, np.array(G_lista))
G_cap = np.ma.masked_where(dontes == 0, np.array(G_lista))

plt.figure()
plt.xlabel('R'), plt.ylabel('G'), plt.grid(True)
plt.scatter(R_nocap, G_nocap, 30, marker='^')
plt.scatter(R_cap, G_cap, 30, marker='o')

for i in range(len(dontes)):
    print(filenames[i], dontes[i], sep=": ")