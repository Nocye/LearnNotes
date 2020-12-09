# EditorUtility

### 弹窗提示[EditorUtility](EditorUtility.html).DisplayDialog

| title   | 消息框的名称。                  |
| ------- | ------------------------------- |
| message | 消息的文本。                    |
| ok      | OK 对话框按钮上显示的标签。     |
| cancel  | Cancel 对话框按钮上显示的标签。 |

### 标记需要保存的对象[EditorUtility](EditorUtility.html).SetDirty



### 显示保存文件夹窗口[EditorUtility](EditorUtility.html).SaveFolderPanel

显示“保存文件夹”对话框并返回所选的路径名称。这个方法打开的窗口默认只识别文件夹,其他文件不在其中.

### 显示保存文件窗口[EditorUtility](EditorUtility.html).SaveFilePanel

显示“保存文件”对话框并返回所选的路径名称。这个方法根据后缀名筛选会显示出的文件。

### 仿人类排序[EditorUtility](EditorUtility.html).NaturalCompare

对字符串按字母顺序排序，但对于字符串中的数字则按数字顺序排序，这样，“xx11”便位于“xx2”之后。