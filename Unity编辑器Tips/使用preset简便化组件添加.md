# Presets（预设）

> Preset是Unity2018的新功能。
>
> [官方地址](https://docs.unity3d.com/2019.3/Documentation/Manual/class-PresetManager.html)

Preset是保存对象属性的资源。Preset存储在项目的Project文件夹中，使用.preset扩展名。可以从大多数对象类型创建Preset，包括Component，Asset Importer和Scriptable objects。

![img](https:////upload-images.jianshu.io/upload_images/78733-b0b77ee818a11192.png?imageMogr2/auto-orient/strip|imageView2/2/w/291/format/webp)

从“帮助”图标旁边的“Preset”菜单创建或使用Preset

> 修改Preset不会影响使用这个Preset的对象。如果您想要类似的功能，请使用Prefab。

> 注意：Preset功能仅限编辑器，在Unity Runtime中不可用。

## 创建Preset

1. 选中你想基于它的属性创建Preset的物体
2. 点击物体上一个组件的Preset图标，会弹出Preset的窗口。

![img](https:////upload-images.jianshu.io/upload_images/78733-b6c62de46fd9fbdb.png?imageMogr2/auto-orient/strip|imageView2/2/w/1130/format/webp)

1. 点击`Save current to...`按钮，会弹出一个文件对话框
2. 选择Preset的名称和位置，然后点击保存。

## 使用Preset

为对象类型创建Preset后，可以将Preset应用于同一类型的其他对象。

1. 选择一个或多个要应用Preset的对象。
2. 单击Inspector窗口中的Preset图标。出现Preset选择窗口。
3. 从Preset选择器窗口中选择一个Preset。
4. 选择的Preset会应用于选定的对象，Preset上面的属性将会覆盖对象上的属性。

![img](https:////upload-images.jianshu.io/upload_images/78733-a2160d2b2fbefed4.png?imageMogr2/auto-orient/strip|imageView2/2/w/515/format/webp)

选择一个灯光并使用橙色Preset使所选灯光成为橙色

## 拖放使用Preset

拖放项目中的Preset可以覆盖属性或创建新的GameObjects/组件。覆盖或创建取决于拖放Preset的位置：

- 将Preset拖到Scene窗口中或Hierarchy中，会使用Preset中的属性和组件创建一个新的GameObject。
- 将Preset拖到GameObject上或Inspector的空白处，会将Preset中的组件添加到该物体上。
- 将Preset拖到Inspector的同类型的组件上，将会使用Preset中的值覆盖组件的值。

## 设置默认Preset

在编辑器中创建对象时或在检查器窗口中重置对象时会使用默认Preset。默认Preset会覆盖Unity的出厂默认设置。

要将Preset设置为默认Preset，请在Project中选中Preset并在Inspector单击设为默认按钮。

![img](https:////upload-images.jianshu.io/upload_images/78733-ae17dee3e179b142.png?imageMogr2/auto-orient/strip|imageView2/2/w/312/format/webp)

在检查器窗口中设置为默认Preset按钮

如上图所示，将橙色灯光设置为默认后，新创建的Light都会是橙色。

还可以使用Preset Manager设置管理默认Preset，
 可以从菜单**Edit** > **Project Settings** > **Preset Manager**打开。

## 修改Preset

使用Inspector窗口修改Preset。修改Preset里的属性的方式和修改GameObject的属性的方式相同。

# Preset Manager

从菜单**Edit** > **Project Settings** > **Preset Manager**打开。

![img](https:////upload-images.jianshu.io/upload_images/78733-202c20c7ce7384ce.png?imageMogr2/auto-orient/strip|imageView2/2/w/311/format/webp)

Preset管理器可以为任何支持的对象类型设置默认Preset。在编辑器中创建对象时，或在Inspector窗口中重置选定对象时都会使用默认Preset。在编辑器中创建对象时，默认Preset会由ObjectFactory API创建。

## 添加新的默认Preset

1. 单击“+”按钮查看没有默认Preset的对象类型的列表。
2. 选择添加默认Preset的对象。
3. 在Preset Manager列表将会创建所选对象类型的默认Preset。这一类型的对象在创建和重置时将使用这个默认Preset中的值。

![img](https:////upload-images.jianshu.io/upload_images/78733-295b9d849479df2f.png?imageMogr2/auto-orient/strip|imageView2/2/w/486/format/webp)

还可以直接将Preset文件拖到Preset Manager的空白处来添加新的默认Preset。注意：如果删除了默认Preset的资源文件，则这个默认Preset也会丢失。

## 更改默认Preset

1. 单击对象类型的默认Preset旁边的下拉菜单。出现具有相同对象类型的Preset列表。
2. 从列表中选择一个Preset。所选Preset成为默认Preset。

![img](https:////upload-images.jianshu.io/upload_images/78733-c5c9a98a968834bf.png?imageMogr2/auto-orient/strip|imageView2/2/w/311/format/webp)

还可以直接将Preset文件拖放到Preset Manager的Inspector窗口，或将Preset文件拖放到相应的对象字段中来替换。

## 删除默认Preset

1. 从默认Preset列表中选择要删除的默认Preset。选中时，默认Preset会突出显示。
2. 点击' - '按钮删除所选的默认Preset。

> 注意：这会从默认Preset列表中删除Preset。Preset文件本身不会被删除。

![img](https:////upload-images.jianshu.io/upload_images/78733-f901860261db089b.png?imageMogr2/auto-orient/strip|imageView2/2/w/314/format/webp)



