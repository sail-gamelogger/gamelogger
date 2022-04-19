<div id="top"></div>
<!-- PROJECT LOGO -->
<br />
<div align="center">
<h3 align="center">Gamelogger</h3>

<!--[English](https://github.com/HMS-Core/hms-ml-demo/blob/master/README_public.md) | 中文-->

  <p align="center">
    游戏应用数据收集的Android库
    <br />
    Unity平台上的集成流程
    <br />
    <a href="https://github.com/sail-gamelogger/gamelogger">首页</a>
    ·
    <a href="https://github.com/sail-gamelogger/gamelogger/issues">回报问题</a>
    ·
    <a href="https://github.com/sail-gamelogger/gamelogger/issues">功能请求</a>
  </p>
</div>


<!-- TABLE OF CONTENTS -->
<details>
  <summary>目录</summary>
  <ol>
    <li>
      <a href="#简介">简介</a>
    </li>
    <li>
      <a href="#入门">入门</a>
      <ul>
        <li><a href="#前提">前提</a></li>
        <li><a href="#Unity上的集成流程">Unity上的集成流程</a></li>
      </ul>
    </li>
    <li><a href="#联络我们">联络我们</a></li>
  </ol>
</details>


<!-- ABOUT THE PROJECT -->
## 简介

Gamelogger是一款基于华为分析服务（Analytics kit）的Android游戏分析SDK。
简单易用，开发者只需要在项目里的任何位置调用onEvent API，Gamelogger 就会自动收集APP用户的数据（详看“自动收集的数据”）以作分析。
兼容GMS/HMS，兼容minSdkVersion 18

<p align="right">(<a href="#top">回页顶</a>)</p>

<!-- GETTING STARTED -->
## 入门

请按照以下步骤操作，设定并安装Gamelogger SDK

### 前提

1. [登记华为开发者账号](https://id1.cloud.huawei.com/CAS/portal/userRegister/regbyemail.html?reqClientType=89&loginChannel=89000003&lang=zh-cn&service=https%3A%2F%2Foauth-login.cloud.huawei.com%2Foauth2%2Fv2%2Fauthorize%3Faccess_type%3Doffline%26response_type%3Dcode%26client_id%3D6099200%26login_channel%3D89000003%26req_client_type%3D89%26lang%3Dzh-cn%26redirect_uri%3Dhttps%253A%252F%252Fdeveloper.huawei.com%252Fconsumer%252Fcn%252Fdoc%252F%26state%3D4967936%26scope%3Dhttps%253A%252F%252Fwww.huawei.com%252Fauth%252Faccount%252Fcountry%2Bhttps%253A%252F%252Fwww.huawei.com%252Fauth%252Faccount%252Fbase.profile%2Bhttps%253A%252F%252Fwww.huawei.com%252Fauth%252Faccount%252Floginid%2Bhttps%253A%252F%252Fwww.huawei.com%252Fauth%252Faccount%252Faccount.flags%2Bhttps%253A%252F%252Fwww.huawei.com%252Fauth%252Faccount%252Fstate.register%2Bhttps%253A%252F%252Fwww.huawei.com%252Fauth%252Faccount%252Frealname%252Fstate%2Bhttps%253A%252F%252Fwww.huawei.com%252Fauth%252Faccount%252Frealname%252Fidentity%2Bhttps%253A%252F%252Fwww.huawei.com%252Fauth%252Faccount%252Frealname%252Fctf.type)
2. [设定华为分析服务](https://developer.huawei.com/consumer/cn/hms/huawei-analyticskit/)

### Unity上的集成流程

1. 进入 Editor -> Build Settings -> Platform -> Andriod， 点击 Switch Platform 切换到安卓平台。

![BuildSettings](https://user-images.githubusercontent.com/73451327/163764202-41c7df00-4087-45c2-abec-77442f69e4a4.png)

2. 进入 Player Settings -> Publishing Settings，勾选以下环境配置项目。

![BuildEnvironment](https://user-images.githubusercontent.com/73451327/163765306-3b7f0374-1f9c-432c-8cf8-fc82d0376709.png)

3. 进入 Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build ，启用 Custom Base Gradle Template 并在文件中添加 AppGallery Connect plugin 和 Maven repository。路径是Assets/Plugins/Android/baseProjectTemplate.gradle。

```gradle
allprojects {
    buildscript {
        repositories {
            // ...
            maven { url 'https://developer.huawei.com/repo/' }
        }
        dependencies {
            // ...
            //see latest version here: https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-Guides/agc-sdk-changenotes-0000001058732550
            classpath 'com.huawei.agconnect:{latest_version}'
        }
    }
    repositories {
        // ...
        maven { url 'https://developer.huawei.com/repo/' }
        maven { url 'https://jitpack.io' }
    }
}
// ...
```

4. 进入 Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build，启用 Custom Launcher Gradle Template 并在 launcherTemplate.gradle 中添加依赖。路径为 Assets/Plugins/Android/LauncherTemplate.gradle。

```gradle
// ...
apply plugin: 'com.huawei.agconnect'
dependencies {
    // ...
    implementation 'com.github.sail-gamelogger:gamelogger:1.0.1'
    }
// ...
```

5. 进入 Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build，启用 Custom Main Gradle Template 并在 mainTemplate.gradle 中添加依赖。路径为 Assets/Plugins/Android/mainTemplate.gradle.gradle。

```gradle
// ...
dependencies {
    // ...
    implementation 'com.github.sail-gamelogger:gamelogger:1.0.1'
}
// ...
```

6. 把 [AfterBuildToDo.cs](./Assets/Editor/AfterBuildToDo.cs) 配置到 Assets/Editor/

7. 把 [GameLogger.cs](./Assets/GameLogger.cs) 配置到 Assets/

8. 我们还需要从华为开发者账号内下载Agconnect-services.json，放到 Assets/Plugins/Android 路径下。

<p align="right">(<a href="#top">回页顶</a>)</p>

<!-- USAGE EXAMPLES -->
## 用法

Gamelogger无需初始化，只需在需要的地方调用即可

```c#
using com.sail.gamelogger;
//..
Gamelogger.onEvent(String EVENT_NAME);
```

### 事件名称 EVENT_NAME

事件名称EVENT_NAME参数可以是任何String，但是中间不能有空格或特殊字符。请注意，如果EVENT_NAME里有空格，头部或尾部的空格会被剪去，中间的空格会被替换成```_```

<!-- CONTACT -->
## 联络我们

开发者 - sailgamelogger@hotmail.com

项目链接: [https://github.com/sail-gamelogger/gamelogger](https://github.com/sail-gamelogger/gamelogger)

<p align="right">(<a href="#top">回页顶</a>)</p>



