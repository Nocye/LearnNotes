Pixels Per Unit 

精灵图像中对应于世界空间一个距离单位的宽度/高度像素数。

一个世界单位（Unit）内包含的像素数量，默认为100，修改这个值会显著的影响在世界空间中Sprite的大小。

例如图片移动了x轴1个单位，那么对应的像素移动了长度*100。



如果是作为UI的Image：

Set Native size后，实际物体大小=Canvas Scaler Reference Pixels Per Unit / Speite Pixels Per Unit * 图片原始大小

