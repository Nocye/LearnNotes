获取TimelineAsset中的track和clip，

```c#
//获取TimelineAsset中的所有轨道
foreach (TrackAsset track in asset.GetOutputTracks())
{
    //获取需要类型的轨道
    if (track.GetType() == typeof(MagicTrack))
    {
        //强转为需要的类型
        var myTrack = (MagicTrack) track;
		//获取轨道中所有的Clip
        foreach (TimelineClip clip in track.GetClips())
        {
            //强转为自己的clip,记得是.asset
            var myClip = (MagicClip) clip.asset;
        }
    }
}
```