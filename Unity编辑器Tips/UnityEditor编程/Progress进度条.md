### [Background Tasks](https://docs.unity3d.com/2020.1/Documentation/Manual/BackgroundTasksWindow.html)

unity2020的新功能，让你可以进行一下操作的时候在右下角显示进度条。

简单示例：

```c#
private IEnumerator Task()
{
    var id = Progress.Start("协程", "给我跑~~~");
    var wait = new EditorWaitForSeconds(0.1f);
    for (int i = 0; i < 100; i++)
    {
        Progress.Report(id, i / 100f);
        Debug.Log((i / 100f).ToString("f4"));
        yield return wait;
    }
    Progress.Remove(id);
}
```