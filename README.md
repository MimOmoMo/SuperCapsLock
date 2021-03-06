# 大小写增强(superCapsLock)

## 简介

目前主要是快捷工具，可以将大小写键(CapsLock)当作快捷键利用起来，并自定义这些快捷键

他是一个人我认为非常优秀的效率工具，它可以用于快捷的打开一些应用以及网站。我本人非常喜欢，也经常需要使用到这个工具

## 展示

![](<https://raw.githubusercontent.com/a1174236686/OfficeTools/master/img/Temp.jpg>)



#### 下面展示简单展示按住CapsLock后鼠标指向屏幕左上角打开记事本

![](<https://raw.githubusercontent.com/a1174236686/OfficeTools/master/img/OpenNotePad.gif>)

#### 演示了我自己平时的一些基本操作包括：快速关闭窗口、切换桌面、快速打开百度、快速打开计算器，记事本等操作



![](<https://raw.githubusercontent.com/a1174236686/OfficeTools/master/img/OprationShow.gif>)



## 功能

### 按住大小写建（CapsLock）搭配一些按键可以实现功能

**这些快捷键并不会影响大小写键的正常使用。当你按下大小写键并在500毫秒内弹起，那么将会正常切换大小写，如果超时或者触发了组合键。那么弹起时则会还原最初的状态**  

#### 目前支持按住CapsLock键的操作有：

- 键盘除fn等定制键以外的所有键

- 屏幕的上、下、左、右以及4个角

- 鼠标的左、右、滚轮向上、滚轮向下

  

#### 目前支持打开的类型有：

- 文件夹
- 文件
- 程序
- 网页
- 键盘组合键模拟



#### 当你下载了该程序，默认的数据库中有一些我自己常用的快捷键：

(win 10的多桌面功能，如果你也是Win10用户可以按Win+Tab来添加一个桌面)

- 鼠标滚轮向上：上一个桌面
- 鼠标滚轮向下：下一个桌面
- 鼠标左键：将微信弹窗到窗口最前
- 鼠标右键：将QQ弹窗到窗口最前
- W：关闭任何窗口（Alt+F4）
- Q：用默认浏览器打开百度
- E：Visual Studio中的返回
- S：Delite键
- Num1：打开记事本
- Num2：打开计算机
- Num+：打开百度翻译



## 已知问题

- 在Windows10环境下由于权限影响你可能需要以管理员身份运行程序，否则某些窗体内将无法使用如任务管理器窗口
- 快捷键基于钩子实现的,有些具有安全防护的程序无法使用，例如密码输入窗口
- 打开程序是使用C#提供的Process类打开的，但是有时会出现打开的程序不会在窗体最前面，这个我尝试使用WindowsApi来激活这些窗口但均失败了。

### 如果你知道如何解决欢迎Fork这个项目并贡献你的代码，或致电我的邮箱或者870856195@qq.com

开源程序如需转载请注明出处。

它是基于SQLite数据库+EF框架制作的。所以你的.Net Framework版本必须为4.5以上

[![ 996.icu ](https://img.shields.io/badge/link-996.icu-red.svg)](https://996.icu)





