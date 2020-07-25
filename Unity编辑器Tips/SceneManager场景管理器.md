```c#
public static AsyncOperation SceneManager.LoadSceneAsync(string sceneName, LoadSceneParameters parameters)
```

异步加载一个场景 返回一个AsyncOperation对象

可以在协程中等待

progress代表现在的加载进度,注意: 这个值在allowSceneActivation为false时永远不会超过0.9,同时isDone也不会为true,当加载完毕且allowSceneActivation为true时,这个值会直接变为1,且isDone可为true

这个对象中的个allowSceneActivation决定场景是否在加载完毕后直接激活,当场景加载完毕之后,再把这个值置为true,可以做到自定义时机激活加载好的场景的功能



