# 阋神星(未完成)


[![license](https://www.gnu.org/graphics/gplv3-or-later.png)](https://www.gnu.org/licenses/gpl-3.0.en.html)

**阋神星**是由C#编写的《尤里的复仇》引擎扩展项目，在AOT发布和inj文件的协作下它能以类似[Ares](https://github.com/Ares-Developers/Ares)的方式被[Syringe](https://github.com/Ares-Developers/Syringe)注入到游戏中。

![Eris YR Engine Extension](ErisLogo.png)


## 项目结构

- [PatcherYrSharp](PatcherYrSharp)
- [Eris](Eris)

## PatcherYrSharp

- 修改自[Xkein](https://github.com/Xkein)的[PatcherYRpp](https://github.com/Xkein/PatcherYRpp)
- 在非托管委托中使用`nint`和`bool`，而不是`ref YourClass`和`Bool`
- 在结构体字段中使用`Bool`而不是`bool`
- 禁止使用`Fastcall`

## Eris

- Behaviors
   - 游戏主要行为的钩子
- Extension
   - 部分游戏对象生成、销毁、存档读档和读取ini的钩子
   - 创建与部分游戏对象一一映射，同时生成销毁的扩展
- Extension.Eris
   - 阋神星的核心
   - 类似AttachEffect的样式系统
   - 快捷键
- Serializer
   - 围绕Extension开始的二进制序列化器
   - 注册可序列化类型的无参构造函数
   - 对于部分类型的特殊序列化格式
- Ui
   - 测试用控制台
   - 其他涉及到鼠标交互和界面绘制的逻辑
- Utilities
   - Ini读取和解析
   - 多人游戏事件
   - 杂项
- Program.cs
   - 与[Syringe](https://github.com/Ares-Developers/Syringe)的交互
   - 初始化

## 代办事项

- 补充和完善[PatcherYrSharp](PatcherYrSharp)
- 优化序列化器
- 添加围绕`GameObject`的脚本系统
- 为可序列化对象和脚本添加相关的源生成器
- ……

## 第三方

- [PatcherYRpp](https://github.com/Xkein/PatcherYRpp)(部分代码修改) —— 提供游戏的基本接口声明
- [DynamicPatcher](https://github.com/Xkein/YRDynamicPatcher)(部分代码借鉴) —— 提供部分钩子信息和Extension模板
- [TextCopy](https://github.com/CopyText/TextCopy)(软件包) —— 提供测试用控制台复制粘贴逻辑
