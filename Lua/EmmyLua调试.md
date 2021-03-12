原理简单说明：
	lua代码中通过 local dbg = require("emmy_core") 主动加载 emmy_core.dll
	到宿主程序中，并启动调试内核代码。调试内核通过socket与IDEA/VSCode侧连接通
	讯。
	注意：Windows下的emmy_core.dll 分32位和64位，注意区分

启动顺序的要求：
	上面提到调试内核与 IDEA/VSCode 通过socket通信，有 Server端和 Client
	端角色之分，所以提供了两种连接模式和对应的启动顺序要求：
	1. Debugger connect IDE: 即IDE充当Server侧，这时应先启动IDE侧的调试功能
		，等待被调试的程序启动并主动连接到IDE。注意：此时插入的Lua代码应当是
		dbg.tcpConnect('localhost', 9966)
	2. IDE connect debugger: 即被调试的程序充当Server端，这时被调试的程序应
		先启动，再启动IDE侧的调试功能连接到调试内核。注意：此时插入的Lua代码应
		当是 dbg.tcpListen('localhost', 9966)

Q: 不能连接的问题：
	IDEA 提示相关错误： Connection refused: connect
	原因：没有按启动顺序要求启动Server端
	解决思路：按照 “启动顺序的要求” 先启动被调试的程序

Q: 不能断点的问题：
	IDEA/VSCode 下了断点但不能命中：
	1. 首先检查使用最新版本emmy_lua插件，群里的版本比较新，但想要最新的最好是
		去CI上去下载每日构建版本，地址见群公告
	2. 不能断点的大部分原因是你的宿主代码中(c++/c#)对于类似 load 函数的调用中
		的 chunkname 的值给的不正确，导致文件路径不匹配而不能命中断点。例如代
		码用到了 require("a.b.c") ，那么在加载 c.lua 文件时给的 chunkname 
		参数应当是 "a/b/c.lua"
	另外调试器提供了一个“强断”的功能，即在要断点的地方写上lua代码：dbg.breakHere()
	用这个功能可以查看强断后堆栈里显示的路径正不正常

Q: Mac上提示 'dynamic libraries not enabled;check your lua installation'
	这个问题需要重新编译lua c代码所在的模块，加上编译宏： LUA_USE_MACOSX。（Unity下
		下的xlua.bundle/tolua.bundle替换之后要重启Unity）

Q: local dbg = require("emmy_core") 失败报错
	你的代码里写了自定义的loader，emmy_core并不是一个lua文件，请判断一下，如果加载的
	是emmy_core请不要处理也不要报错，交由低层的clib loader继续处理

Q: local dbg = require("emmy_core") 返回一个boolean值
	emmy_core库初始化失败，通常是发生在windows平台下。这是因为emmy_core在初始化会
	根据lua函数名字去找函数地址，如根据"lua_settop"去找内存中的函数地址，如果找不到则会
	导致初始化失败，通常是因为lua相关的函数没有被导出
	解决方法1：让你的程序导出lua符号表（加上编译宏LUA_BUILD_AS_DLL）
	解决方法2：选择使用自带lua代码版本的emmy_core.dll（下个版本）