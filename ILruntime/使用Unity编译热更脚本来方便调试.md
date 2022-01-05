这个方法是参考ET的，使用Unity编译热更脚本，通过Assemly.Load去加载热更DLL和PDB，达到直接调试的效果。

```c#
[MenuItem("Tools/BuildCode")]
public static void BuildCode()
{
    string csPath = @"D:\Project\Mono\TestMono\Hotfix";
    //cs脚本文件
    string[] files = Directory.GetFiles(csPath);
    //DLL路径
    string dllPath = Path.Combine(csPath, "Hotfix.dll");
    string pdbPath = Path.Combine(csPath, "Hotfix.pdb");
    File.Delete(dllPath);
    File.Delete(pdbPath);
    //这个类是unity封装的编译器类,通过它来编译
    AssemblyBuilder builder = new AssemblyBuilder(dllPath, files);
    //下面都是编译时的选项
    var buildTarget = BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget);
    builder.compilerOptions.ApiCompatibilityLevel = PlayerSettings
        .GetApiCompatibilityLevel(buildTarget);
    builder.compilerOptions.CodeOptimization = CodeOptimization.Debug;
    builder.flags = AssemblyBuilderFlags.None;
    builder.referencesOptions = ReferencesOptions.UseEngineModules;
    builder.buildTargetGroup = buildTarget;
    builder.Build();
}
```

通过这种方式编译的dll，可以实现在外部工程单步调试。

ILR同样也可以使用