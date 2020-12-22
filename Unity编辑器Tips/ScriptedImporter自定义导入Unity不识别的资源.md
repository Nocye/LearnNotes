# ScriptedImporter

##### 自定义资源导入器的抽象基类。

脚本化导入器是与特定文件扩展名关联的脚本。Unity 的资源管线调用它们来将关联文件的内容转换为资源。

Scripted Importer 是 [Unity Scripting API](https://docs.unity3d.com/cn/2019.4/Manual/ScriptingSection.html) 的一部分。使用Scripted Importer在C# 中编写自定义资源导入器，用于Unity本身不支持的文件格式。(比如.lua,或者其他自定义后缀)。

应通过专门定义继承抽象类 [ScriptedImporter](https://docs.unity3d.com/cn/2019.4/ScriptReference/Experimental.AssetImporters.ScriptedImporter.html) 的子类，并应用 [ScriptedImporter](https://docs.unity3d.com/cn/2019.4/ScriptReference/Experimental.AssetImporters.ScriptedImporterAttribute.html) 属性来创建自定义导入器。这样会注册您的自定义导入器以处理一个或多个文件扩展名。当资源管线检测到一个与注册的文件扩展名匹配的文件为新文件或已更改的文件时，Unity 会调用自定义导入器的 `OnImportAsset` 方法。

注意：Scripted Importer 无法处理已由 Unity 本身处理的文件扩展名。

**注意：限制**

这是 Scripted Importer 功能的实验性版本，因此仅限于可以使用 Unity Scripting API 创建的资源。这不是此功能在实现或设计方面的限制，而是对其实际使用施加了限制。

**当修改了导入器脚本后，导入的资源不会实时更改，需要删除.meta文件后让Unity重新识别一次才会进行修改后的导入器处理，记得把导入器脚本放在Editor文件夹下。**

##### 使用导入器把.lua文件识别成TextAsset的示例，导入后可以当作TextAsset拖拽使用，但是打包时还是要额外处理一下后缀名

```c#
[ScriptedImporter(1, "lua")]
public class LuaImporter : ScriptedImporter
{
    public override void OnImportAsset(AssetImportContext ctx)
    {
        var asset = new TextAsset(File.ReadAllText(ctx.assetPath));
        ctx.AddObjectToAsset("MainText", asset);
        ctx.SetMainObject(asset);
    }
}
```