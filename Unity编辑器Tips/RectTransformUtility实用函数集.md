```c#
RectTransformUtility.ScreenPointToLocalPointInRectangle(
      RectTransform rect,
      Vector2 screenPoint,
      Camera cam,
      out Vector2 localPoint);
```

以传入的rect的pivot为中心坐标系,检测传入的screenPoint点相对于这个坐标系的位置 还需要提供传入的UIrect的相机模式 将转换后的坐标装在localPoint中 ,如果转换后的点在这个矩形范围内 返回true

虽然官方建议如果UIrect Canvas的相机模式是overlay,cam值应为null,实际上是方法内部是使用Camera.main的,而这个方法又会通过tag在场景中寻找相机,性能并不是很好,(参考:Unity游戏优化(第二版) 40页) 可以考虑缓存主摄像机

因为转换后的坐标是相对于传入的rect的坐标,所以可根据这个坐标求出该坐标相对rect的

