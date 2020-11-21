# RuntimePlatform

enumeration

## 描述

正在运行的平台应用程序。由 Application.platform 返回。

**注意：**使用 RuntimePlatform 与平台相关的编译之间的不同在于 使用 RuntimePlatform 是在运行时评估的，而依赖于平台的编译是 在编译时评估的。因此，如果可以使用平台相关的编译，就不要犹豫。在大多数情况下，使用两者 可以获得相同的功能，使用这些定义可以生成更小更快的代码，因为无需在运行时进行检查。 也有一些情况需要在运行时使用 RuntimePlatform。