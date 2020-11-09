此类代表与程序域相关,关于程序域需要后期学习补充.

```c#
AppDomain.CurrentDomain.GetAssemblies();
```

此方法获取当前程序域中所有加载的程序集,简单来说就是各种DLL与被unity的asmdef文件划分的文件夹

```c#
[assembly: InternalsVisibleTo("Unity.Addressables.Editor.Tests")]
```

有时写一些库工具时,会把一些属性指定为Internal,无法在外部访问,通过这个特性,可以指定的其他外部程序集(dll)来访问自己的内部方法



在E大框架中有一个用法,有一些插件库会有一些设置文件,这些设置文件根据项目有所不同,不方便放在插件库中,E大在项目中通过attribute修饰字符串字段,在插件库中通过反射当前所有程序集来查找被修饰的string字段,把这个字段的内容作为设置内容.

```c#
s_ConfigurationPath = Type.GetConfigurationPath<BuildSettingsConfigPathAttribute>()
//通过传入想要寻找的特性
```

```c#
//在所有加载的程序集中寻找被该特性修饰的字段
internal static string GetConfigurationPath<T>() where T : ConfigPathAttribute
{
    foreach (System.Type type in Utility.Assembly.GetTypes())
    {
        if (!type.IsAbstract || !type.IsSealed)
        {
            continue;
        }

        foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
        {
            if (fieldInfo.FieldType == typeof(string) && fieldInfo.IsDefined(typeof(T), false))
            {
                return (string)fieldInfo.GetValue(null);
            }
        }

        foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
        {
            if (propertyInfo.PropertyType == typeof(string) && propertyInfo.IsDefined(typeof(T), false))
            {
                return (string)propertyInfo.GetValue(null, null);
            }
        }
    }

    return null;
}
```

```c#
//获取当前域中的所有程序集
static Assembly() => Utility.Assembly.s_Assemblies = AppDomain.CurrentDomain.GetAssemblies();
//获取当前程序集中的所有Type
public static Type[] GetTypes()
{
  List<Type> typeList = new List<Type>();
  foreach (System.Reflection.Assembly assembly in Utility.Assembly.s_Assemblies)
    typeList.AddRange((IEnumerable<Type>) assembly.GetTypes());
  return typeList.ToArray();
}
```

```c#
/// <summary>
/// 配置路径属性。自定义的路径特性需要继承这个类
/// </summary>
public abstract class ConfigPathAttribute : Attribute
{
}
```