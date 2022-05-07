GF的WebRequest模块，通过Web Request Agent Helper Count去控制同时进行的web Agent数量，一个web Agent对应一个UnityWebRequestDownloadAgentHelper 框架默认是一个，所以同时只会有一个网络请求进行，如果有需要可以调整这个数值，在Web模块的Start方法中会实例化相应的helper并注册agent，也可以在代码中添加。

web请求流程：

1.注册web事件

2.调用AddWebRequest

3.等待web请求完成，抛出相应事件，处理事件中请求回复的数据

4.反注册web事件

WebHelper中有一个DownloadHandler类，重写了DownloadHandlerScript 可以每帧更新当前下载的数据进度，

