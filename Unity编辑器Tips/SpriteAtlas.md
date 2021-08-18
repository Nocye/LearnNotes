学习马三的博客发现下面这种latebinding的方法已过时，现在可以直接勾选Include in Build，打包时过滤掉SpriteAtlas文件，同图集的散图打进同个包，需要的图片正常根据路径加载就好。([【Unity游戏开发】SpriteAtlas与AssetBundle最佳食用方案](https://www.cnblogs.com/msxh/p/14194756.html))

Include in Build 选项，非常容易引起歧义，

使用场景：部分带着图片的UI预制体，这些图片已经打进了图集，且在打AB包时只打图集不打散图。

那么加载这个预制体时，理所当然的会去寻找这个预制体ab包的依赖，先加载这个依赖，然后再加载这个预制体。

当我们只打图集不打散图时，会发现预制体AB打出来时的依赖信息里并没有图集AB，那么他们是怎么找到对应的图集的？

因为这个是Unity底层的操作，这里只能猜测，当你不勾选Include in Build时加载这个图集，它会提示你SpriteAtlasManager.atlasRequested wasn't listened to while SpriteAtlasName requested。也就是说Unity底层在打包时会保留一份预制体中图片对应图集的名字，但不会归为依赖项。在运行时通过SpriteAtlasManager.atlasRequested这个事件去注册申请图集的消息。如果勾选了，会在引擎层自动加载对应的图集图片，这部分是黑盒，研究了一下没有找到详细的加载位置。

这里还有一个需要注意的点，如果你后续把图集的AB给Unload（true），他的引用就丢失了，但是假如你通过Unload（false）去卸载图集ab，他的图集引用还会在内存中驻留一段时间，除非你使用Resource.UnloadUnusedAssets()就可以立刻卸载。

预制体P中使用了一张图片S，图片S打进了图集A，现在图集A和预制体P分别打成两个AB包，打包显示无依赖关系。现在需要加载P时正常显示图片：

```c#
//先注册图集申请事件
SpriteAtlasManager.atlasRequested += (spriteAtlasName, callback) =>
{
    ab =  AssetBundle.LoadFromFile(Application.streamingAssetsPath + "atlas");
    //这里申请时,注意只会传入图集的名称,不包含相对路径和后缀,如果你打包时对address做了处理,那么相应的这里也需要做
    var atlas = ab.LoadAsset<SpriteAtlas>(spriteAtlasName);
    callback(atlas);
};
```

```c#
ab= AssetBundle.LoadFromFile(Application.streamingAssetsPath + "prefab");
//在加载到有依赖图集时就会去申请图集了
var obj = ab2.LoadAsset<GameObject>("P");
var o = Instantiate(obj);
```

猜测Unity底层维护了一份数据记载了引用图片的图集归属，因为图集的获取Sprite和普通的获取Sprite获取的方式有所不同，所以做了这个manager。



