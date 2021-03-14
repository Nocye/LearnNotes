Rijndael 
Rijndael（读作rain-dahl）是由美国国家标准与技术协会（NIST）所选的高级加密标准（AES）的候选算法。

简单使用:

```c#
public static byte[] AesDecrypt(byte[] buffer, string key){
	byte[] keyBytes=Encoding.UTF8.GetBytes(key);
	RijndaelManaged decrypt=new RijndaelManaged();
	decrypt.key = keyBytes;
	decrypt.Mode = CipherMode.ECB;
	decrypt.Padding = PaddingMode.None;
	ICryptoTransform transform = decrypt.CreateDecryptor();
	byte[] result = tansform.TransformFinalBlock(buffer,0,buffer.Length);
	return buffer;
}
```

