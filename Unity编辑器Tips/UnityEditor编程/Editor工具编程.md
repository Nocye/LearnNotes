> ### 特性
>
> [OnOpenAsset]
>
> 在Unity Project窗口中点击一个资源时触发的方法
>
> [CustomEditor(Type inspectedType,bool editorForChildClasses)]
>
> 告诉Editor脚本,它是哪个类的编辑器.如果bool值为真,则type的子类也会套用此编辑器.
>
> [Header("标题名")]
>
> 在变量上添加这个特性,会在面板上的变量名中显示标题名
>
> [Tooltip("内容")]
>
> 再变量上添加这个特性,当鼠标悬浮在面板上的变量上时,会显示对应的内容

> ### 方法
>
> EditorGUILayerout的方法为自动布局的方法,不需要传入显示的大小和位置,编辑器会根据检视面板自动布局
>
> >```c#
> >EditorGUILayout.BeginHorizontal()
> >```
> >
> >创建一个横向的组,返回这个组的矩形(Rect)数据
> >
> >```c#
> >EditorGUILayout.EndHorizontal();
> >```
> >
> >结束从上一个方法创建的组,两个方法应成对出现
>
> 
>
> > ```c#
> >  EditorGUILayout.Space();
> > ```
> >
> > 在上一个区域和下一个区域之间留下一个小空隙
>
> 
>
> > ```c#
> > EditorGUILayout.Vector2Field(string label, Vector2 value, params GUILayoutOption[] options)
> > ```
> >
> > 创建一个输入Vector2的区域,Label传入要显示在区域上方的标题,value为需要编辑的值,options可选,为该布局的属性设置
>
> 
>
> > ```c#
> > EditorGUILayout.ColorField(Color value, params GUILayoutOption[] options)
> > ```
> >
> > 创建一个区域,用来选择一个颜色,Value为选择的颜色,该方法会返回修改的Value值
>
>  
>
> >  ```c#
> >  EditorGUILayout.Popup(int selectedIndex, string[] displayedOptions, params GUILayoutOption[] options)
> >  ```
> >
> >  创建一个下拉菜单,用来选择一个string数组中的选项,返回选择的int索引
>
>  
>
> > ```c#
> > EditorGUILayout.IntPopup(int selectedValue, string[] displayedOptions, int[] optionValues, params GUILayoutOption[] options)
> > ```
> >
> > 创建一个下拉菜单,传入一个int数组和一个string数组,两个数组的长度需要对应,string数组用来显示下拉菜单中的项目,int数组用来表示实际的值.方法返回选择的string数组索引在int数组中的值
>
>  
>
> > ```c#
> > EditorGUILayout.Slider(string label, float value, float leftValue, float rightValue, params GUILayoutOption[] options)
> > ```
> >
> > 创建一个滑动条,Label为标题说明,value为需要修改的值,leftValue为最小值,rightValue为最大值.方法返回修改后的值
>
> 
>
> > ```c#
> > EditorGUILayout.EnumPopup(string label, Enum selected, params GUILayoutOption[] options);
> > ```
> >
> > 创建一个枚举下拉框,Label为标题说明,selected为需要修改的枚举值,方法返回选择的枚举值.使用自定义枚举值时,返回值前需要强转为自定义枚举类型
>
>  
>
> > ```c#
> > EditorGUILayout.TagField(string tag, params GUILayoutOption[] options);
> > ```
> >
> > 创建一个tag标签的下拉框,tag为需要修改值,方法会自动读取editor中所有的tag,方法返回修改后的tag值.
>
>  
>
> > ```c#
> > EditorGUILayout.LayerField(int layer, params GUILayoutOption[] options);
> > ```
> >
> > 创建一个选择layer下拉框,layer为需要修改的值,方法会自动读取editor中所有的layer,方法返回修改后的layer值
>
>  
>
> > ```c#
> > GUILayout.Button(string text, params GUILayoutOption[] options);
> > ```
> >
> > 创建一个按钮,需要通过if语句判断是否被点击,在if语句中做点击之后的处理.
>
>  
>
> > ```c#
> > EditorUtility.DisplayDialog(string title, string message, string ok, string cancel);
> > ```
> >
> > 创建一个unity消息框,title:标题文本,message:信息文本,ok:确定按钮显示的文本,
> >
> > cancel:取消按钮显示的文本.如果点击确定返回true,否则返回false.
>
>  
>
> > ```c#
> > EditorUtility.DisplayDialogComplex(string title, string message, string ok, string cancel, string alt);
> > ```
> >
> > 创建一个unity消息框,给定OK,cancel,alt三种按钮,根据点击的按钮返回(0,1,2)三个int值,0代表OK,1代表cancel,2代表alt.
>
>  
>
> > ```c#
> > EditorGUILayout.Toggle(string label, bool value, params GUILayoutOption[] options);
> > ```
> >
> > 创建一个toggle开关,value为要修改的值,返回一个修改后的bool值,默认选择框在右边
>
>  
>
> > ```c#
> > EditorGUILayout.ToggleLeft(string label, bool value, params GUILayoutOption[] options);
> > ```
> >
> > 创建一个选择框在左边的toggle,其他和Toggle一致
>
> 
>
> > ```c#
> > EditorGUILayout.Foldout(bool foldout, string content);
> > ```
> >
> > 创建一个可折叠区域,foldout为需要修改的值,content为标题文本,返回修改后的值.
>
>  
>
> > ```c#
> > EditorGUILayout.BeginToggleGroup(string label, bool toggle);
> > ```
> >
> > 创建一个由toggle控制的组,toggle表示组的开关状态,
> >
> > ```c#
> >  EditorGUILayout.EndToggleGroup();
> > ```
> >
> > 表示上一个toggle组的结束.这两个方法应该成对出现.方法中可以写别的逻辑
>
>  
>
> > ```c#
> > EditorGUILayout.CurveField(string label, AnimationCurve value, params GUILayoutOption[] options);
> > ```
> >
> > 创建一个编辑动画曲线的区域,value为待编辑的曲线
>
>  
>
> > ```c#
> > EditorGUILayout.ObjectField(string label, UnityEngine.Object obj, Type objType, bool allowSceneObjects, params GUILayoutOption[] options);
> > ```
> >
> > 创建一个可以选择UnityEngine.Object为对象的区域,obj为选择的对象,objType表示允许选择的对象,allowSceneObjects表示是否允许选择场景中的对象
>
>   
>
> > ```c#
> > EditorGUILayout.TextField(string text, params GUILayoutOption[] options); 
> > ```
> >
> >  创建一个文本区域,可以编辑其中的内容,方法返回编辑后的字符串
>
>  
>
> 
>
> > ```c#
> > EditorGUILayout.HelpBox(string message, MessageType type, bool wide);
> > ```
> >
> > 创建一个提示区域,根据MessageType的类型显示提示,wide为true则会覆盖整个窗口的宽度
>
>  
>
> > ```c#
> > Editor.OnInspectorGUI()
> > ```
> >
> > 重写此方法,可以绘制自定义类在编辑器上的展示形式.
>
> 
> 
> > ```c#
> > EditorGUILayout .GetControlRect
> > ```
> >
> > 为一个Editor控件获取一个可绘制的矩形。
>>
> > 当创建一个新的Editor控件时，不依赖GUILayout(自动布局)来实现实际的控件，而是让控件取一个Rect作为参数，这与EditorGUI类中的控件类似，是一个合理的设计。例如,这确保了该控件也可以用于不允许使用GUILayout的PropertyDrawer中。
>>
> > 一旦实现了控件的非布局版本，也可以很容易地制作布局版本，它只需调用到非布局版本。为了得到控件的矩形拟合，可以使用GetControlRect函数。
> >
> > | hasLabel                  | 可选的布尔值，用于指定控件是否具有标签。默认为true。         |
> > | ------------------------- | ------------------------------------------------------------ |
> > | float height              | 控件的高度（以像素为单位）。默认值为[EditorGUIUtility.singleLineHeight](EditorGUIUtility-singleLineHeight.html)。 |
> > | GUIStyle style            | 用于控件的可选[GUIStyle](GUIStyle.html)。                    |
> > | GUILayoutOption[] options | 布局选项的可选列表，用于指定其他布局属性。此处传递的所有值都将覆盖由定义的设置`style`。另请参见：[GUILayout.Width](GUILayout.Width.html)，[GUILayout.Height](GUILayout.Height.html)，[GUILayout.MinWidth](GUILayout.MinWidth.html)，[GUILayout.MaxWidth](GUILayout.MaxWidth.html)，[GUILayout.MinHeight](GUILayout.MinHeight.html)， [GUILayout.MaxHeight](GUILayout.MaxHeight.html)，[GUILayout.ExpandWidth](GUILayout.ExpandWidth.html)，[GUILayout.ExpandHeight](GUILayout.ExpandHeight.html)。 |
> >
> > 



>```c#
>SerializedProperty.isExpanded
>```
>
>设置序列化属性是否被扩展,可以手动赋值,

> # 样式
>
> 编辑器内部自带了一些样式,可以快速指定区域视图的样式,
>
> ```c#
> GUI.skin
> ```
>
> 需要时通过这个类直接指定想要的样式
>
> ```c#
> GUIContent
> ```
>
> 这个类有三个属性:
>
> text,表示绘制的文字内容
>
> image,在文字内容之前绘制的一张图片
>
> tooltip,鼠标悬浮在上方显示的提示

