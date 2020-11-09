# [UnityWebRequest](https://docs.unity3d.com/cn/2019.4/ScriptReference/Networking.UnityWebRequest.html)

## 描述

UnityWebRequest 对象用于与 Web 服务器进行通信。

UnityWebRequest 处理 HTTP 与 Web 服务器进行通信的流程。其他对象 - 特别是 [DownloadHandler](https://docs.unity3d.com/cn/2019.4/ScriptReference/Networking.DownloadHandler.html) 和 [UploadHandler](https://docs.unity3d.com/cn/2019.4/ScriptReference/Networking.UploadHandler.html) - 分别管理数据的下载和上传。

为方便起见，系统提供一组静态函数；这些函数可返回针对许多常见用例相应配置的 UnityWebRequest 对象。*请参阅：*[Get](https://docs.unity3d.com/cn/2019.4/ScriptReference/Networking.UnityWebRequest.Get.html)、[Post](https://docs.unity3d.com/cn/2019.4/ScriptReference/Networking.UnityWebRequest.Post.html)、[Put](https://docs.unity3d.com/cn/2019.4/ScriptReference/Networking.UnityWebRequest.Put.html)、[GetTexture](https://docs.unity3d.com/cn/2019.4/ScriptReference/Networking.UnityWebRequest.GetTexture.html)。**(除非你完全理解你在做什么且熟悉此类,否则最好都使用这些静态方法而不是new来创建UnityWebRequest).**

**注意：**UnityWebRequest 通过调用 [SendWebRequest](https://docs.unity3d.com/cn/2019.4/ScriptReference/Networking.UnityWebRequest.SendWebRequest.html) 方法开始与远程服务器进行通信后，UnityWebRequest 对象的大部分属性将无法更改。

**注意：**代理设置应在操作系统级别上配置。UnityWebRequest 会采用这些设置。

```c#
//一个简单的下载方法
private IEnumerator TestWebDownLoad()
{
    UnityWebRequest web=UnityWebRequest.Get("https://www.baidu.com/");
    //会返回一个unity协程等待类,可以像其他等待类那样获取进度
    yield return web.SendWebRequest();    
    if (web.isHttpError||web.isNetworkError)
        Debug.Log(web.error);
    else 
    {
        Debug.Log(web.downloadHandler.text);
    }
}
```