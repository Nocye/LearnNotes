Overrlay模式：

该模式下，canvas大小与屏幕的比例为1：1，1像素=1unity单位（米），这个模式下，UI直接渲染在屏幕上，虽然看似在场景中，但是不会渲染到场景摄像机中。

Camera模式：

需要指定一个相机用来渲染，实际上仍然是场景的一部分，所以这么使用时都是新开一个相机，与主场景保持较远的距离，避免UIcamera渲染到其他物体。

这个模式下，Canvas会在保持Width，Height不变下，对Scale进行缩放，符合摄像机的视口大小。在摄像机是视锥模式，根据距离摄像机的距离放大/缩小Scale。实际视觉效果不变

World Space模式：

Canvas就像一个普通的游戏物体一样，随意调整大小和scale。

##### Canvas Scaler（画布缩放器）：

Constant Pixel size：

无论屏幕大小如何，UI元素都保持自己的像素大小，不会根据对应的屏幕变化。

Scale Factor ：按此系数，缩放画布中的元素，简单来说就是改变canvas的Scale大小达成UI缩放，但是Canvas的宽高比是不会变的。

Reference Pixels Pre Unit：该系数是配合Sprite的Pixels Per Unit使用的，直接看代码，图片PPU / 该值 得到还原像素时使用的ppu，图片PPU大于RPPU，图片缩小，反之放大。 

sprite首先换算成unity单位unit，1Unit = 1Pixels / PPU

再通过这个值换算成canvas下的单位 1CanvasUnit = 1Unit * RPPU

```c#
spritePixelsPerUnit = activeSprite.pixelsPerUnit;
m_CachedReferencePixelsPerUnit = canvas.referencePixelsPerUnit;
pixelsPerUnit = spritePixelsPerUnit / m_CachedReferencePixelsPerUnit;
```

```c#
public override void SetNativeSize()
{
    if (activeSprite != null)
    {
        float w = activeSprite.rect.width / pixelsPerUnit;
        float h = activeSprite.rect.height / pixelsPerUnit;
        rectTransform.anchorMax = rectTransform.anchorMin;
        rectTransform.sizeDelta = new Vector2(w, h);
        SetAllDirty();
    }
}
```

Scale With Screen Size（最常用）：

本质还是操纵ScaleFactor，不过是通过Match来决定取宽度还是高度的比例

Match 表示优先保证长度，或者高度

当屏幕的长宽比改变时，0表示优先保持UI组件的长度的相对位置，图片相对屏幕的长度保持不变，比如图片完全覆盖到屏幕左右边界，那么分辨率改变时会优先计算长度需要改变的比例，比如修改后的长为之前的1.2倍大小，那么长和高会同时放大1.2倍,保持图片相对位置不变，但是不会去管高度是否超过屏幕范围或者缩小。

1表示优先按高度0.5表示取中间值，其他同上

