使用spine合并拼装皮肤图集时发现一个问题，spine通过复制纹理在运行时合并图集，合并通过Texture2D.PackTextures 这个方法，这个方法需要图片开启read/write才能运行，如果你使用两张资源纹理去合并生成，那么会报错，但是spine是运行时生成复制纹理，调用这个方法时不会出错，但是图片合并出来是全部灰色的，无法正确合并。

如果需要打包的纹理，需要开启read/write，spine的没提示。

使用Graphics.CopyTexture 这个API去复制纹理时，请注意quality选项中的texture quality选项 是否为full res，如果不为full 会导致复制出来的纹理只有原纹理的一部分，而且不报错不警告（发现版本2019.4.31）

