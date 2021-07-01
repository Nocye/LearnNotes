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

