using System.Diagnostics;
using UnityEngine;

public class MyConditional : MonoBehaviour
{
    /// <summary>
    /// 被该特性标记的方法,仅在有对应宏定义的情况下,才执行.
    /// 可以有多个该特性,多个之间是与关系
    /// </summary>
    [Conditional("SCRIPTINGDEFINESYMBOL")]
    public void HelloWorld()
    {
        UnityEngine.Debug.Log("HelloWrold");
    }
}