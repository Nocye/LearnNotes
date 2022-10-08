DependAssetCollector 这个类型是yooassets特殊处理的，

首先主动收集被这个类型标记的资源，然后过滤掉没有被其他资源依赖的项 同时不按照shared规则生成包名，由收集器设置包名

