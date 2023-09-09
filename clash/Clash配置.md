[恩山教程](https://www.right.com.cn/forum/forum.php?mod=viewthread&tid=8267066&highlight=shellclash) [subconverter](https://github.com/tindy2013/subconverter) [clash文档](https://dreamacro.github.io/clash/zh_CN/configuration/configuration-reference.html) [代理规则](https://github.com/blackmatrix7/ios_rule_script/tree/master/rule/Clash)



配置文件通过subconvert配置生成 [配置](./nocye.ini )

注意配置文件需要部署到网络课访问地址,自己用就本机开个cdn丢进去 然后把链接加到subconverter的参数里

[现在用的参数](http://127.0.0.1:25500/sub?target=clash&url=$URLS$&config=http%3A%2F%2F127.0.0.1%3A8000%2FNocye%2Fnocye.ini)

访问地址需要修改为本机ip,clash参数地址之后同步修改,需要urlUncoding

目前不需要给配置文件配置太多的rule,通过rule-providers来添加,还方便更新

> rule-providers:
>   bilibili:
>     type: http
>     behavior: classical
>     url: https://cdn.jsdelivr.net/gh/blackmatrix7/ios_rule_script@master/rule/Clash/BiliBili/BiliBili.yaml
>     path: ./rule_providers/bilibili.yaml
>     interval: 86400
>   Microsoft:
>     type: http
>     behavior: classical
>     url: https://cdn.jsdelivr.net/gh/blackmatrix7/ios_rule_script@master/rule/Clash/Microsoft/Microsoft.yaml
>     path: ./rule_providers/Microsoft.yaml
>     interval: 86400
>   steam:
>     type: http
>     behavior: classical
>     url: https://cdn.jsdelivr.net/gh/blackmatrix7/ios_rule_script@master/rule/Clash/Steam/Steam.yaml
>     path: ./rule_providers/steam.yaml
>     interval: 86400    
>   google:
>     type: http
>     behavior: classical
>     url: https://cdn.jsdelivr.net/gh/blackmatrix7/ios_rule_script@master/rule/Clash/Google/Google.yaml
>     path: ./rule_providers/google.yaml
>     interval: 86400    

配置文件生成后复制到路由器的data/clash/yamls/里的config.yaml

如果没有others.yaml等其他配置文件,先ssh进路由器 shellclash 配置相关设置-自定义高级功能

rule-providers添加的rule,在rules.yaml中配置

> - DOMAIN-KEYWORD,nikke,Proxy
> - RULE-SET,bilibili,Bilibili
> - RULE-SET,Microsoft,微软
> - DOMAIN-KEYWORD,parsec,DIRECT
> - RULE-SET,steam,Steam
> - RULE-SET,google,Proxy