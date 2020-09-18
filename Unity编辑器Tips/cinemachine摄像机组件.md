如果想实现多个目标同时保持在摄像机范围内,

需要使用CinemachineTargetGroup这个组件,这个组件挂载在一个物体上,组件控制这个物体的position,然后让一个虚拟相机follow这个物体

## Properties:

| **Property:**     |                 | **Function:**                                                |
| :---------------- | :-------------- | :----------------------------------------------------------- |
| **Position Mode** |                 | 如何计算目标组的位置.                                        |
|                   | *Group Center*  | Use the center of the axis-aligned bounding box that contains all items of the Target Group. |
|                   | *Group Average* | 使用目标组中项目位置的加权平均值。                           |
| **Rotation Mode** |                 | 如何计算目标组的旋转.                                        |
|                   | *Manual*        | 使用挂在targetGroup组件的物体的旋转                          |
|                   | *Group Average* | 目标组中各项目方向的加权平均值。                             |
| **Update Method** |                 | 如何更新目标组的transform                                    |
|                   | *Update*        | Update in the normal MonoBehaviour Update() method.          |
|                   | *Fixed Update*  | Updated in sync with the Physics module, in FixedUpdate().   |
|                   | *Late Update*   | Updated in MonoBehaviour `LateUpdate()`.                     |
| **Targets**       |                 | 目标组中所有物体的列表                                       |
|                   | *Weight*        | 计算平均数时,给该物体多少权重。不能为负数。                  |
|                   | *Radius*        | 物体的半径,用于计算物体的边界框,不能为负数                   |