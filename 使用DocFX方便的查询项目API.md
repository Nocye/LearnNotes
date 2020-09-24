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