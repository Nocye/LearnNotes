

## Playable是什么?

Playable是Unity中,对所有"可播放的"对象做的一次封装,只要你根据规则编写了相关的脚本,那么这个组件可以播放任何你想播放的东西(动画,逻辑,等等).通常配合Unity的TImeLine使用.

## Playable解决了什么问题?

暂时留空,后期学习

## Playable的简单使用

在Project视图中右键新建TimeLIne,在TImeLine新建想播放的对象的轨道.在物体上添加PlayableDirector组件,把刚才创建的TimeLIne拖入PlayableAsset中,即可通过PlayableDiroctor组件控制播放/暂停.

## Playable的自定义播放

如果要通过TimeLine控制逻辑的话,需要新建四种脚本:(一个简单的创建自定义Play资源的插件,[Default Playables](https://assetstore.unity.com/packages/essentials/default-playables-95266#description) 由官方出品,一键生成你想要的类型和对应的behavior脚本,asset等,)

1. 继承PlayableBehaviour的脚本,TimeLine中的时间变化时定义的行为都在这个脚本
2. 继承PlayableAsset的脚本,同时需要继承ITimeLineClipAsset接口,用来定义这个Playable的一些属性,这些属性可以在TimeLIne面板中编辑
3. 继承TrackAsset的脚本,用来自定义在TimeLine编辑界面中右键时添加自定义轨道时的操作,有一些固定的写法
4. 同样继承PlayableBehaviour的脚本,不同于1的是这个脚本通常是混合器,假如你的两段Playable中需要实现混合,比如动画混合,音频混合等操作

## TimeLine更改轨道绑定的Object

TimeLine中的每个轨道可以绑定一个Object,可以动态设置绑定的对象.通过TimleLineAsset中的outputs集合来筛选对应轨道名的绑定对象

```c#
playableDirector = GetComponent<PlayableDirector>();
List<PlayableBinding> list = playableDirector.playableAsset.outputs
    //通过名字来筛选,也可通过类型筛选,但是感觉有点怪
    .Where(x => { return x.streamName.Equals(targetTrackName); })
    .ToList();
//更改获取到的绑定对象
playableDirector.SetGenericBinding(list[0].sourceObject, otherObject.GetComponent<AudioSource>());
```

