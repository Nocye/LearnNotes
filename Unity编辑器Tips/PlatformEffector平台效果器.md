#### Description 描述

适用“平台”的行为，比如单向碰撞等。

当源Collider2D 时个触发器时，该效应器每当源重叠时应用力到目标Collider2D 。当源碰撞器不是触发器时，仅当该效应器接触源碰撞器时应用力。

1、这个Platform Effector 2D是用来做横版2D游戏从下往上跳而不被阻挡的那种跳跃平台用的。
2、这个组件要配合其他2D 碰撞器使用，例如：再添加一个2D Box Collider，然后勾选 Used By Effector即可。
3、Use One Way 只允许单方向碰撞，若要做跳跃平台的话必须勾选。
4、Use One Way Groupping 如果你的跳跃平台摆得很紧密的话，为了防止Bug，必须勾选这个，它会自动将临近的算为一个组
5、Surface Arc就是允许碰撞的角度，如果设为180的话，那么从左边和右边水平靠近平台的移动都会受到碰撞。如果要做上面提到的跳跃平台的话，用90即可。

### Variables 变量

| [sideArc](http://wiki.ceeger.com/script/unityengine/classes/platformeffector2d/platformeffector2d.sidearc) | The angle of an arc that defines the sides of the platform centered on the local 'left' and 'right' of the effector. Any collision normals within this arc are considered for the 'side' behaviours. 弧形的角度指定义在以效应器自身“左”和“右”上的平台的两侧。任何碰撞法线在该弧形内部认为是该“侧面”的行为。 |
| ------------------------------------------------------------ | :----------------------------------------------------------- |
| [surfaceArc](http://wiki.ceeger.com/script/unityengine/classes/platformeffector2d/platformeffector2d.surfacearc) | The angle of an arc that defines the surface of the platform centered of the local 'up' of the effector. 弧形的角度定义集中在效应器自身上方的平台表面。 |
| [useOneWay](http://wiki.ceeger.com/script/unityengine/classes/platformeffector2d/platformeffector2d.useoneway) | Should the one-way collision behaviour be used? 是否使用单向碰撞行为？ |
| [useOneWayGrouping](http://wiki.ceeger.com/script/unityengine/classes/platformeffector2d/platformeffector2d.useonewaygrouping) | Ensures that all contacts controlled by the one-way behaviour act the same. 确保所有通过单向接触控制行为相同。 |
| [useSideBounce](http://wiki.ceeger.com/script/unityengine/classes/platformeffector2d/platformeffector2d.usesidebounce) | Should bounce be used on the platform sides? 在平台侧面是否使用反弹？ |
| [useSideFriction](http://wiki.ceeger.com/script/unityengine/classes/platformeffector2d/platformeffector2d.usesidefriction) | Should friction be used on the platform sides? 是否应该在平台侧面使用摩擦力？ |