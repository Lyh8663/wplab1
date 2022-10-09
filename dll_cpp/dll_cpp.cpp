// dll_cpp.cpp : 定义 DLL 应用程序的导出函数。

// 非托管动态链接库DLL的创建步骤:
// <3> 在cpp源代码文件中引用头文件，并实现函数

#include "stdafx.h"
#include "dll_cpp.h"

int __stdcall testAdd(int a, int b) {
	return a + b;
}

int __stdcall testMulti(int a, int b) {
	return a * b;
}


