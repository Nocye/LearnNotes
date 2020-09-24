# AssetImporter

class in UnityEditor / 继承自：[Object](https://docs.unity3d.com/cn/2019.4/ScriptReference/Object.html)

### 描述

从中派生特定资源类型的资源导入器的基类。

### 变量

| [assetBundleName](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetImporter-assetBundleName.html) | 获取或设置 AssetBundle 名称。                                |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [assetBundleVariant](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetImporter-assetBundleVariant.html) | 获取或设置 AssetBundle 变体。                                |
| [assetPath](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetImporter-assetPath.html) | 此导入器的资源的路径名称。（只读）                           |
| [importSettingsMissing](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetImporter-importSettingsMissing.html) | 如果导入的资源未随附任何元文件，则此值为 true。(判断资源是否首次导入,2019版本经过测试  by马三大佬) |
| [userData](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetImporter-userData.html) | 获取或设置任意用户数据。                                     |

### 公共函数

| [AddRemap](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetImporter.AddRemap.html) | 将子资源从导入的资源（例如 FBX 文件）映射到同类型的外部资源。 |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [GetExternalObjectMap](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetImporter.GetExternalObjectMap.html) | 获取 AssetImporter 使用的外部对象映射的副本。                |
| [RemoveRemap](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetImporter.RemoveRemap.html) | 从外部对象的映射中删除项。                                   |
| [SaveAndReimport](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetImporter.SaveAndReimport.html) | **如果资源导入器已标记为“脏”，则保存资源导入器设置。(在资源后处理器中对继承此类的资源类型进行处理后,需要调用这个函数,一帧后才会生效)** |
| [SetAssetBundleNameAndVariant](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetImporter.SetAssetBundleNameAndVariant.html) | 设置 AssetBundle 名称和变体。                                |
| [SupportsRemappedAssetType](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetImporter.SupportsRemappedAssetType.html) | 检查 AssetImporter 是否支持重新映射给定的资源类型。          |

### 静态函数

| [GetAtPath](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetImporter.GetAtPath.html) | 在 path 处检索资源的资源导入器。 |
| ------------------------------------------------------------ | -------------------------------- |
|                                                              |                                  |

> # TextureImporter
>
> class in UnityEditor/继承自：[AssetImporter](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetImporter.html)
>
> ### 描述
>
> 纹理导入器允许您从编辑器脚本修改 [Texture2D](https://docs.unity3d.com/cn/2019.4/ScriptReference/Texture2D.html) 导入设置。
>
> 此类中的设置与 [Texture Import Settings](https://docs.unity3d.com/cn/2019.4/Manual/class-TextureImporter.html) 中显示的设置相匹配。
>
> 主要是不同平台的差异化配置 ,需要通过函数获取,修改后再通过函数设置,平台字符串的选项为：**“Standalone”、“iPhone”、“Android”、“WebGL”、“Windows Store Apps”、“PS4”、“XboxOne”、“Nintendo 3DS”和“tvOS”**。
>
> ```c#
> public TextureImporterPlatformSettings GetPlatformTextureSettings (string platform);
> public void SetPlatformTextureSettings (TextureImporterPlatformSettings platformSettings);
> ```
>
> 其中不同平台主要对应不同的纹理格式,蓝大推荐使用DTX5和ASTC_5X5的纹理格式,但是具体需要根据游戏适配的机型范围决定.