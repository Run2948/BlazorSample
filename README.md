# Blazor WebAssembly极简入门教程

> 笔记源于课堂编写：BiliBili
>
> Github源码地址：https://github.com/Run2948/BlazorSample
>
> 源视频教程：https://www.bilibili.com/video/BV19K4y1e7kd



### 第一课：准备、开始

#### 1.什么是Blazor

Blazor是微软最近推出的，使用C#和HTML来构架交互式WebUI的框架；



#### 2.Blazor的两种方式？

- 基于WebAssembly
- 运行在Seerver
- 无需插件，基于Web标准
- 可以与Javascript进行交互
- 可以利用.NET的优势，例如性能、安全性、现有的程序等等



#### 3.Blazor历史![img]()![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1604155733563-20042091-e306-4c92-bbe6-741abf5bd86f.png)



#### 4.Blazor的两种宿主模型

- 客户端
- 服务器端



#### 5.客户端的Blazor？

![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1605248134773-d471cda2-4f76-453c-b2fd-c30e08525547.png)

优点：

- 可以运行在所有现代浏览器上面，包括ipad和手机上的浏览器。
- 服务器端不需要.NET
- SPA的体验

缺点：

- 老一点的浏览器不一定支持，例如IE
- 首次需下载的应用比较大
- Debug体验有限



#### 6.服务器端的Blazor？

![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1605248118368-e3ebb292-3022-4bc6-a29d-4de3271656a6.png)

优点：

- 需要下载的东西很小
- 可以使用所有服务器端的API
- 完整的Bebug体验
- 可在不支持WebAssembly的浏览器中运行

缺点：

- 不支持离线运行
- 网络延迟影响较大
- 可扩展星是个问题





### 第二课：HttpClient读取数据到页面

#### 1.结构

![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1605433790282-266128e2-0f11-4a11-87f4-8e0017f3c422.png)



#### 2.调用Web API

- HttpClient

- - GetFromJsonAsync()
  - PostAsJaonAsync()
  - PutAsJsonAsync()
  - DeleteAsync()

- IHttpClientFactory





### 第三课：数据绑定

#### 1.数据绑定

- 单项绑定：

<h2>Child Component</h2>

<p>Rear:  @Year</p>

- 双向绑定：

<input @bind="CurrentValue"/>

<input @bind="CurrentValue"@bind:event="oninput" />



### 第四课：EditForm

#### 1.EditForm

- Input组件

- - InputText：普通文本输入
  - InputTextArea：多行文本框
  - InputNumber：数字
  - InputSelect：下拉框
  - InputDate：日期
  - InputCheckbox：复选框

- 数据绑定
- 数据验证



#### 2.EditForm例子

![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1605597191656-90cb56fe-5504-4e6b-a81a-9f74473a9fa3.png?x-oss-process=image%2Fwatermark%2Ctype_d3F5LW1pY3JvaGVp%2Csize_10%2Ctext_5ruU5ruU56iL5bqP54y_%2Ccolor_FFFFFF%2Cshadow_50%2Ct_80%2Cg_se%2Cx_10%2Cy_10)





### 第五课：表单验证

#### 1.Blazor内置表单验证

- EditForm
- InputComponent



#### 2.提示

- Blazor表单验证和ASP.NET Core的验证相似
- 在Model上：Data Annotations

- - [Required] [MaxLength]

- DataAnnotationsCalidator——在Form中使用，可以对输入进行验证
- ValidationSummary——显示错误信息





### 第六课：调用JavaScript

#### 1.JavaScript互操作

- C# 代码调用JavaScript
- JavaScript 调用 C#
- 可以封装成一个库



#### 2.IJSRuntime

[Inject] //注入

public IJSRuntime JSRuntime {get;set;}



//第一个参数就是：JS函数方法

//第二个参数是JS函数方法的参数，可变长度的参数，需要传JSON格式

//返回类型是一个字符串

var reuslt=await jsRuntime.InvokeAsync<string>("sayHello","");



#### 3.实例教程

1.写一个JS函数

![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1605699301210-e9ddd00a-79aa-4581-90c1-75d546ee1357.png)

2.在【wwwroot/Index.html】中引入刚刚写的JS文件。

![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1605699320687-abf1c46c-8412-4c4b-ac13-612830dedb30.png)

![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1605699314869-36ce5165-7690-4589-98cb-4450df53141c.png)

3.在需要注入的地方注入IJSRuntime【EmployeeOverviewBase】，然后先一个属性用来显示。

![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1605699368441-3d38851b-d1f0-47ed-bbcb-c7cfc206ef41.png)

4.在前端xxx.razor文件中写一个按钮，具有单击事件；使用Result属性进行页面的显示。

![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1605699438661-0431cf8c-3854-4553-b1b2-14ed92b0b5b4.png)

5.使用异步方式实现方法单击事件方法。

![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1605699494044-69c9be78-a1a9-472b-abb9-f1f418005ed1.png)



### 第七课：部署

#### 1.部署要求

- 可以Serve静态文件
- HTML
- 能够连接API
- CORS
- 压缩



#### 2.发布实例教程

1.选择客户端项目，进行发布

![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1605699660139-0b925b8a-4a4b-42c7-8cde-02c9eb653db9.png)

2.选择【文件夹】

![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1605699688651-4f2f7322-7a1c-4992-9f90-029769b30bd4.png?x-oss-process=image%2Fwatermark%2Ctype_d3F5LW1pY3JvaGVp%2Csize_10%2Ctext_5ruU5ruU56iL5bqP54y_%2Ccolor_FFFFFF%2Cshadow_50%2Ct_80%2Cg_se%2Cx_10%2Cy_10)

3.点击【发布】

![image.png](https://cdn.nlark.com/yuque/0/2020/png/1183442/1605699776408-0e88516c-4c4a-42d8-aa82-15f9ffdb78d7.png?x-oss-process=image%2Fwatermark%2Ctype_d3F5LW1pY3JvaGVp%2Csize_14%2Ctext_5ruU5ruU56iL5bqP54y_%2Ccolor_FFFFFF%2Cshadow_50%2Ct_80%2Cg_se%2Cx_10%2Cy_10)