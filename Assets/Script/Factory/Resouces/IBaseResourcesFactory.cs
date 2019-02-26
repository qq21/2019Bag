///<summary>描述:   资源工厂 基类
///作者:唐泽彬 
///创建时间: 2019/02/15 10:22:03 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseResourceFactory<T>
{
    void GetSinleResouces(string Path);
}