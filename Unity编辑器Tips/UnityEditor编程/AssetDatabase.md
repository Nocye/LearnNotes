# AssetDatabase(用于操作unity下的资源文件类)

使用这个类时,所有的目录都是工程的相对目录,例如"Assets/MyAwesomeProps"

```c#
AssetDatabase.FindAssets(string filter,string[] searchInFolders)
```

用于查找所有位于项目文件夹下的资源文件,返回一个guid数组,

**注意：搜索是不区分大小写的。** 

名称： 通过文件名来过滤资源（不含扩展名）。用空格隔开的单词将被视为同个单词的名称搜索。因此，例如 "test asset"，是一个将被搜索的资源的名称。使用"name:"关键字来进行搜索.此外，可以过滤字符串名字中的指定小节,例如,上面的"test asset"可以用"test"来进行匹配.

标签:资源可以附加标签。可以使用关键字'l:' 找到带有特定标签的资产。带有这个字符串的表示正在以标签为关键字搜索资源.

类型：根据明确识别的类型查找资产。根据明确识别的类型查找资产。关键字't:'用于指定正在寻找类型资产。如果过滤字符串中包含多个类型，那么将返回匹配其中一个类的资产。类型可以是内置的类型，如Texture2D或用户创建的脚本类。用户创建的类是由项目中的ScriptableObject类创建的资产。如果想要返回所有类型的assets 请使用Object，因为所有的assets都是从Object派生出来的。

使用searchInFolders参数指定一个或多个文件夹会将搜索限制在这些文件夹和它们的子文件夹中。这比在所有文件夹中搜索所有资产要快。



### 通过Guid返回资源的路径

```c#
AssetDatabase.GUIDToAssetPath(string guid)
```

根据资源的guid来返回资源对应的路径,如果寻找的资源为空,则返回一个空字符串

```c#
AssetDatabase.CreateAsset([NotNull] UnityEngine.Object asset, string path)
```

在指定的路径新建资源。

指定的类必须是unity支持的内部资源类.

你必须保证使用的路径是一个被支持的扩展('.mat' 代表 materials， '.cubemap' 代表 cubemaps， '.GUISkin' 代表 skins， '.anim' 代表 animations and '.asset' 代表任意其他的资源文件。)

### 保存修改后的Asset

```c#
AssetDatabase.SaveAssets();
```

保存所有改变后的资源,比如TimeLine,在代码中修改后,如果不调用这个函数,则修改后的资源不会马上保存。



```c#
AssetDatabase.Refresh();
```

刷新编辑器下的Project窗口,和windows的F5刷新相似



```c#
AssetDatabase.GenerateUniqueAssetPath(string path);
```

为一个asset文件路径创造新的唯一路径,需要提供一个asset文件包含后缀名的路径,如果已有相同的文件,则在文件名之后附加数字1,再重新检查一次,依次递增



```c#
AssetDatabase.GetAssetPath(UnityEngine.Object assetObject)
```

返回存放资产的项目文件夹的相对路径名。

所有的路径都是相对于项目文件夹的，例如 "Assets/MyTextures/hello.png"。