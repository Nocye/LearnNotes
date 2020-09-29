## [DocFx](https://dotnet.github.io/docfx/index.html) 

微软开源的一个API查询工具

从Markdown和代码文件生成静态网站

DocFX可以从源代码（包括C＃，F＃，Visual Basic，REST，JavaScript，Java，Python和TypeScript）以及原始Markdown文件中生成文档。

> ### 快速入门(Windows下)
>
> 1. 下载DocFx,解压到硬盘上的任意位置,然后打开系统环境变量,在系统变量中找到Path,选择添加,复制刚才解压到的目录位置
> 2. 新建一个文件夹,,在文件夹下启动CMD命令行或者Powershell
> 3. 输入 **docfx init -q**自动化生成命令,或者**docfx init**自定义生成命令,后者需要你自定义一些选项,(暂未学习),最后会生成一个docfx_project文件夹
> 4. 输入**docfx docfx_projec/docfx.json** 生成_site文件夹,这是根据项目生成的静态网站目录,需要注意的是如果你不在docfx.json所在的文件夹下使用命令行,需要先定位到文件夹下,或者使用相对路径,相反则不需要添加前缀路径
> 5. 输入**docfx docfx_projec --serve** 来启动网页服务**(默认使用本地服务器 http://localhost:8080/)**,同样,需要定位到docfx.json所在的目录 这两句命令也可以合成一句 **docfx docfx_project/docfx.json --serve** 同时生成网站文件和启动网站服务

现在一个最最简单的DocFx就已经搭建好了,当然里面没有任何内容,接下来需要学习对docfx.json的参数自定义来实现其他功能

一个DocFx项目下的其他文件:

> **toc.yml** 目录文件,应该是定义标题栏的tab对应的文件夹,实际细节后期看文档更新
>
> **docfx.json** 最重要的配置文件,docfx构建需要的所有参数都在这个json中,也有很大的自定义空间.
>
> **index.md** 部署网页的首页,如果改名或没有不会报错,会变成自带的一个主页,里面没有东西
>
> **.gitignore** git的忽略文件列表,暂时不清楚用处

> ### 巨坑注意
>
> docfx项目的obj文件夹下的.cache会保存构建时的缓存,有时候你修改了一些yml项目,重新构建时发现没有修改,就是因为没有删除cache的原因

> ### 在网站上添加一些文章
>
> 1. 将更多的.md文件添加到articles文件夹中,例:details1.md , details2.md , details3.md,如果文件引用了其他资源和图片,请把这些资源放到Images文件夹中,并修改md文件中的图片路径为之前的Images文件中.
>
> 2. 添加进articles的.md文件需要添加到toc文件中才可以正常显示,toc文件可以是两种格式, .yml或者.md,使用yml时的格式为:
>
>    ```c
>    name: <文章需要显示的标题>//去掉尖括号
>    href: <文章的文件名,带后缀>//去掉尖括号
>    ```
>
>    使用md时的格式为
>
>    ```c
>    #[文章显示名](文章的文件名,带后缀)  //因为是md格式,在md中会自动转为超链接
>    ```
>
>    

> ### toc.yml文件的格式
>
> ```c
> - name: <标题名> //注意name之前的 - 符号
>   href: <文件名或目录> //文件名需要加后缀,文件目录需要在最后加/
> ```
>
> 

> ### 添加API文档(c#工程在DocFx项目文件夹内部的情况)
>
> 1. 首先把c#工程放置在DocFx项目下任意一个文件夹,这里假设文件夹名为project
>
> 2. 打开docfx.json配置
>
>    ```json
>          "src": [
>            {
>            //"src": "project/", //指定c#项目所在的目录.如果是在docfx项目目录下可省略 ,也可直接用files的项目路径           
>              "files": [
>                "project/**.sln"//获取project文件夹下的所有.sln文件,也可以是.csproj
>              ],
>              "exclude": [ //排除项,排除掉c#项目中哪些不需要的文件或文件夹
>                "**/bin/**",
>                "**/obj/**",
>                "_site/**"
>              ]
>            }
>          ],
>          "dest": "api" //最后生成的yml文件输出目录
>    ```
>
> 3. 运行 docfx docfx.json --serve 根据c#元数据构筑项目,同时生成网页,简单的一个API文档就制作完毕
>
> 扩展:添加其他项目文档
>
> ```json
>  {
>       "src": [
>         {
>         	"src": "../../",// ../为命令行语法,为上级目录 本行的意义在于返回docfx的上级目录的上级目录
>           "files": [
>             "ObjectPool/**.sln"  // 在这个目录里搜索指定的文件类型
>           ],
>           "exclude": [
>             "**/bin/**",
>             "**/obj/**",
>             "_site/**"
>           ]
>         }
>       ],
>       "dest": "api-2" //导出的文档目录,最好一个项目一个目录
>     },
> ```
>
> 如果扩展了其他项目文档,需要在build项中也添加
>
> ```json
> "content": [
>       {
>         "files": [
>           "api/**.yml",
>           "api/index.md",
>           "api-2/**.yml" //添加了几个项目,就需要在这里添加几个,注意也可以在这里和文件夹里加入index.md文件,作为点击页面的初始界面   
>         ]
>       },
> ```
>
> 编辑完docfx.json后 ,需要再编辑一下toc.yml文件,在下面添加上新加项目的文档目录,参考toc.yml目录格式

> ### 网页的主题(模板)
>
> ```json
> "template": [
>       "default"
>     ]
> ```
>
> 在docfx.json中修改template项,可以对网页的主题进行修改,官网上有很多不错的主题,内置的主题通过 docfx template list查看
>
> 最常使用的是"default","default(zh-cn)",后者可以把注释中的数学和描述的英文替换为中文(一个小问题是如果使用其他主题,单独使用default(zh-cn)会导致主题不适用,需要加上default才可以正常使用)

> ### 引用外部HTML文件(用不好)
>
> 1. 首先需要一个.yml文件,这里用xrefmap.yml来举例,建议放在docfx.json同目录,参照以下格式
>
>    ```json
>    references:
>    - uid: uid_of_topic(MD中填写的UID)
>      name: title_of_topic(标题名)
>      href: url_of_topic.html(HTML文件地址,绝对路径和相对路径都可,但绝对路径的使用似乎需要别的设置,暂时没懂)
>      fullName: full_title_of_topic(全称)
>    - ...
>    ```
>
> 2. 修改docfx.json文件,
>
>    ```json
>    {
>      "build": {
>        "xref": [
>          "<path_to_xrefmap>"//上面的yml文件名
>        ],
>        ...
>      }
>    }
>    ```
>
>    

