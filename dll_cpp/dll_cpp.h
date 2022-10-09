#pragma once

// 非托管动态链接库DLL的创建步骤:
// <1> 采用C++创建项目，项目类型为类库，名称为dll_cpp

// <2> 在头文件中声明函数原型
extern "C" __declspec( dllexport ) int __stdcall testAdd ( int a, int b );
extern "C" __declspec( dllexport ) int __stdcall testMulti ( int a, int b );