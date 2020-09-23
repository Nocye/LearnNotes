# AssetPostprocessor

class in UnityEditor

### 描述

AssetPostprocessor 允许您挂接到导入管线并在导入资源前后运行脚本。

在模型导入期间，系统将按以下顺序调用函数：
\- [OnPreprocessModel](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPreprocessModel.html) 是在最开始时调用的，您可以覆盖在整个模型导入过程中使用的 [ModelImporter](https://docs.unity3d.com/cn/2019.4/ScriptReference/ModelImporter.html) 设置。
\- 导入网格和材质后，从导入的节点创建游戏对象层级视图。使用 [OnPostprocessMeshHierarchy](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessMeshHierarchy.html) 来更改层级视图。表示导入节点的每个游戏对象都被赋予相应的 MeshFilter、MeshRenderer 和 MeshCollider 组件。向 MeshRenderer 分配材质之前，系统会调用 [OnAssignMaterialModel](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnAssignMaterialModel.html) 函数。
\- 在游戏对象初始化 MeshRenderer 之后且存在“userdata”时，系统会调用 [OnPostprocessGameObjectWithUserProperties](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessGameObjectWithUserProperties.html)。这发生在生成子游戏对象之前。
\- 如果在先前的阶段中未禁用动画生成（请参阅 [ModelImporter.generateAnimations](https://docs.unity3d.com/cn/2019.4/ScriptReference/ModelImporter-generateAnimations.html)），则会生成带蒙皮的网格和动画。如果可能，系统还会创建化身并优化游戏对象层级。之后，系统将为根游戏对象调用 [OnPostprocessModel](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessModel.html)。

系统会在 SpeedTree 资源（.spm 文件）上调用 [OnPreprocessSpeedTree](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPreprocessSpeedTree.html) 和 [OnPostprocessSpeedTree](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessSpeedTree.html)，与调用 [OnPreprocessModel](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPreprocessModel.html) 和 [OnPostprocessModel](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessModel.html) 的方式相同，区别在于 [SpeedTreeImporter](https://docs.unity3d.com/cn/2019.4/ScriptReference/SpeedTreeImporter.html) 类型是 [assetImporter](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor-assetImporter.html)。

在制作流程中，AssetPostprocessor 应始终放置在项目中预先构建的 dll 中，而非脚本中。 AssetPostprocessor 会更改导入的资源的输出，因此，如果其中一个脚本出现编译错误，就会导致资源以不同的方式导入。 在制作流程中操作时，这是一个严重的问题。通过对 AssetPostprocessor 使用 dll，您可以确保在脚本出现编译错误时，也能够始终执行 AssetPostprocessor。 通过此方法，您可以覆盖导入设置中的默认值，也可以修改纹理或网格之类的导入数据。(**编写好后处理工具后,应该打成DLL放在项目中,防止在项目中编码错误时导入文件造成的后处理失效问题**)

### 变量

| [assetImporter](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor-assetImporter.html) | 对资源导入器的引用。(一般在OnPreprocess回调中强转为对应的资源类型之后再操作) |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [assetPath](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor-assetPath.html) | 要导入的资源的路径名称。                                     |
| [context](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor-context.html) | 导入上下文。                                                 |

### 公共函数

| [GetPostprocessOrder](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.GetPostprocessOrder.html) | 覆盖导入器的处理顺序。       |
| ------------------------------------------------------------ | ---------------------------- |
| [GetVersion](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.GetVersion.html) | 返回资源后处理器的版本。     |
| [LogError](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.LogError.html) | 将导入错误消息记录到控制台。 |
| [LogWarning](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.LogWarning.html) | 将导入警告记录到控制台。     |

### 消息(注意函数名,OnPost开头的函数在OnPreprocess后执行,OnPost执行时代表资源已经转为Unity内部资源格式)

| [OnAssignMaterialModel](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnAssignMaterialModel.html) | 提供源材质。                                                 |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [OnPostprocessAllAssets](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessAllAssets.html) | 在完成任意数量的资源导入后（当资源进度条到达末尾时）调用此函数。 |
| [OnPostprocessAnimation](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessAnimation.html) | 当 AnimationClip 已完成导入时调用此函数。                    |
| [OnPostprocessAssetbundleNameChanged](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessAssetbundleNameChanged.html) | 将资源分配给其他资源捆绑包时调用的处理程序。                 |
| [OnPostprocessAudio](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessAudio.html) | 将此函数添加到一个子类中，以在音频剪辑完成导入时获取通知。   |
| [OnPostprocessCubemap](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessCubemap.html) | 将此函数添加到一个子类中，以在立方体贴图纹理完成导入之前获取通知。 |
| [OnPostprocessGameObjectWithAnimatedUserProperties](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessGameObjectWithAnimatedUserProperties.html) | 当自定义属性的动画曲线已完成导入时调用此函数。               |
| [OnPostprocessGameObjectWithUserProperties](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessGameObjectWithUserProperties.html) | 为每个在导入文件中至少附加了一个用户属性的游戏对象调用此函数。 |
| [OnPostprocessMaterial](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessMaterial.html) | 将此函数添加到一个子类中，以在材质资源完成导入时获取通知。   |
| [OnPostprocessMeshHierarchy](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessMeshHierarchy.html) | 当变换层级视图已完成导入时调用此函数。                       |
| [OnPostprocessModel](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessModel.html) | 将此函数添加到一个子类中，以在模型完成导入时获取通知。       |
| [OnPostprocessSpeedTree](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessSpeedTree.html) | 将此函数添加到一个子类中，以在 SpeedTree 资源完成导入时获取通知。 |
| [OnPostprocessSprites](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessSprites.html) | 将此函数添加到一个子类中，以在精灵的纹理完成导入时获取通知。 |
| [OnPostprocessTexture](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPostprocessTexture.html) | 将此函数添加到一个子类中，以在纹理刚完成导入之前获取通知。   |
| [OnPreprocessAnimation](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPreprocessAnimation.html) | 将此函数添加到一个子类中，以在导入模型（.fbx、.mb 文件等）中的动画之前获取通知。 |
| [OnPreprocessAsset](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPreprocessAsset.html) | 将此函数添加到一个子类中，以在导入所有资源之前获取通知。     |
| [OnPreprocessAudio](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPreprocessAudio.html) | 将此函数添加到一个子类中，以在导入音频剪辑之前获取通知。     |
| [OnPreprocessMaterialDescription](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPreprocessMaterialDescription.html) | 将此函数添加到一个子类中，以在材质从 Model Importer 导入时接收通知。 |
| [OnPreprocessModel](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPreprocessModel.html) | 将此函数添加到一个子类中，以在导入模型（.fbx、.mb 文件等）之前获取通知。 |
| [OnPreprocessSpeedTree](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPreprocessSpeedTree.html) | 将此函数添加到一个子类中，以在导入 SpeedTree 资源（.spm 文件）之前获取通知。 |
| [OnPreprocessTexture](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetPostprocessor.OnPreprocessTexture.html) | 将此函数添加到一个子类中，以在纹理导入器运行之前获取通知。   |