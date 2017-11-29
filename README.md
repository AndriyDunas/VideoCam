# VideoCam

default: int NumberTres = 3

Binarize: MedianFilter=3
Niblack
Otsu: MedianFilter=3
Yen: white image, int NumberTres = 4; NPixelsFilter=2,3,4, MedianFilter=3,3
Triangle: NPixelsFilter=2, MedianFilter=3, NPixelsFilter=2

0-50; Very Low; Niblack
51-100; Low - Triangle; 
101-150; Medium - Otsu/Binarize
151-200; High - Otsu/Binarize
201-255; Very High - Otsu/Binarize. Yen?