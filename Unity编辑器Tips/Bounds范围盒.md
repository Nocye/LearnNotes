### Bounds

描述
表示一个轴对齐的包围盒。

轴对齐的包围盒（简称 AABB）是与坐标轴对齐并且完全包围 某个对象的盒体。由于该盒体从不相对于这些轴旋转，因此仅通过其 center 和 extents 或者通过 min 和 max 点便可对它进行定义。

这个结构的修改比较繁琐，牵一发而动全身。

##### 关键属性和函数

center：包围盒的中心，修改这个值不会导致min点和max点等其他属性的改变，如果你知道你在做什么，请手动修改其他属性。

min：包围盒的左下角点。center - extents。

max：包围盒的右上角点。center + extents。

size：代表包围盒的总大小。max - min。

extents：包围盒的范围，始终是size的一半。



###### Bounds.Encapsulate

增大该Bounds，包含进一个Point。

算法比较简单，判断一下需要扩大的是min还是max，然后把min或者max等于新的点，再把center，extents重新计算。

