```c#
PropertyDrawer 
```

绘制类型的基类,各种如果要自定义类型的绘制方法,继承此类,然后加上特性

```c#
[CustomPropertyDrawer(typeof(Type))]
```

类型自定义脚本编辑器,基本用法

重写OnGui可以实现自定义的属性绘制,示例用法

```c#
public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
    	EditorGUI.BeginProperty(position, label, property);
        
        EditorGUILayout.LabelField(label);
        EditorGUI.indentLevel += 1;
        EditorGUILayout.PropertyField(property.FindPropertyRelative("nums"));
        EditorGUILayout.PropertyField(property.FindPropertyRelative("Names"));
        EditorGUI.indentLevel -= 1;

        EditorGUI.EndProperty();
}
```

其中 label自带了字段名