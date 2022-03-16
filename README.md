<div id="top"></div>
<!-- PROJECT LOGO -->
<br />
<div align="center">
<h1 align="center">Gamelogger</h1>

[English](https://github.com/HMS-Core/hms-ml-demo/blob/master/README_public.md) | 中文

  <p align="center">
    游戏应用数据收集的Android库
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
        <li><a href="#安装">安装</a></li>
      </ul>
    </li>
    <li><a href="#用法">用法</a></li>
    <li><a href="#数据列表">数据列表</a></li>
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

### 安装

1. 在root的build.gradle
```gradle
allprojects {
    repositories {
	//..
	maven { url 'https://jitpack.io' }
    }
}
```
2. 在app的build.gradle
```gradle
dependencies {
    //..
    implementation 'com.github.sail-gamelogger:gamelogger:1.0.0'
}
```

<p align="right">(<a href="#top">回页顶</a>)</p>


<!-- USAGE EXAMPLES -->
## 用法

Gamelogger无需初始化，只需在需要的地方调用即可

```java
import com.sail.gamelogger.Gamelogger；

//..

Gamelogger.onEvent(String EVENT_NAME);
```

### 事件名称 EVENT_NAME

事件名称EVENT_NAME参数可以是任何String，但是中间不能有空格或特殊字符。请注意，如果EVENT_NAME里有空格，头部或尾部的空格会被剪去，中间的空格会被替换成```_```

以下列表是Gamelogger分不同的场景预设的EVENT_NAME，供开发者参考和使用。开发者也可以自定义EVENT_NAME传入onEvent API。

#### 登入
```java
EventPresets.Login.ATTEMPT = "LOGIN_ATTEMPT_INITIATED"
EventPresets.Login.SUCCESS = "LOGIN_ATTEMPT_SUCCESS"
EventPresets.Login.FAILED = "LOGIN_ATTEMPT_FAILED"
EventPresets.Login.INVALID_CREDENTIALS = "LOGIN_INVALID_CREDENTIALS"
EventPresets.Login.INCORRECT_PASSWORD = "LOGIN_INCORRECT_PASSWORD"
EventPresets.Login.USER_NOT_FOUND = "LOGIN_USER_NOT_FOUND"
EventPresets.Login.HUAWEI_LOGIN = "LOGIN_PLATFORM_HUAWEI"
EventPresets.Login.GOOGLE_LOGIN = "LOGIN_PLATFORM_GOOGLE"
EventPresets.Login.APPLE_LOGIN = "LOGIN_PLATFORM_APPLE"
EventPresets.Login.FACEBOOK_LOGIN = "LOGIN_PLATFORM_FACEBOOK"
EventPresets.Login.TWITTER_LOGIN = "LOGIN_PLATFORM_TWITTER"
```

#### 支付
```java
EventPresets.Payment.INITIATED = "PAYMENT_REQUEST_INITIATED"
EventPresets.Payment.SUCCESS = "PAYMENT_REQUEST_SUCCESS"
EventPresets.Payment.FAILED = "PAYMENT_REQUEST_FAILED"
EventPresets.Payment.CARD_DECLINED = "PAYMENT_CARD_DECLINED"
EventPresets.Payment.CARD_EXPIRED = "PAYMENT_CARD_EXPIRED"
EventPresets.Payment.CARD_INVALID_EXPIRATION_DATE = "PAYMENT_CARD_INVALID_EXPIRATION_DATE"
EventPresets.Payment.CARD_INVALID_dCVV = "PAYMENT_CARD_INVALID_CVV"
EventPresets.Payment.INSUFFICIENT_FUNDS = "PAYMENT_INSUFFICIENT_FUNDS"
EventPresets.Payment.INVALID_TRANSACTION = "PAYMENT_INVALID_TRANSACTION"
EventPresets.Payment.INVALID_SKU = "PAYMENT_INVALID_SKU"
```

#### 广告
```java
EventPresets.Advertisement.BANNER_AD_REQUESTED = "ADS_BANNER_AD_REQUESTED"
EventPresets.Advertisement.NATIVE_AD_REQUESTED = "ADS_NATIVE_AD_REQUESTED"
EventPresets.Advertisement.INTERSTITIAL_AD_REQUESTED = "ADS_INTERSTITIAL_AD_REQUESTED"
EventPresets.Advertisement.REWARDED_AD_REQUESTED = "ADS_REWARDED_AD_REQUESTED"
EventPresets.Advertisement.SPLASH_AD_REQUESTED = "ADS_SPLASH_AD_REQUESTED"
EventPresets.Advertisement.BANNER_AD_FILLED = "ADS_BANNER_AD_FILLED"
EventPresets.Advertisement.NATIVE_AD_FILLED = "ADS_NATIVE_AD_FILLED"
EventPresets.Advertisement.INTERSTITIAL_AD_FILLED = "ADS_INTERSTITIAL_AD_FILLED"
EventPresets.Advertisement.REWARDED_AD_FILLED = "ADS_REWARDED_AD_FILLED"
EventPresets.Advertisement.SPLASH_AD_FILLED = "ADS_SPLASH_AD_FILLED"
EventPresets.Advertisement.BANNER_AD_SHOWN = "ADS_BANNER_AD_SHOWN"
EventPresets.Advertisement.NATIVE_AD_SHOWN = "ADS_NATIVE_AD_SHOWN"
EventPresets.Advertisement.INTERSTITIAL_AD_SHOWN = "ADS_INTERSTITIAL_AD_SHOWN"
EventPresets.Advertisement.REWARDED_AD_SHOWN = "ADS_REWARDED_AD_SHOWN"
EventPresets.Advertisement.SPLASH_AD_SHOWN = "ADS_SPLASH_AD_SHOWN"
EventPresets.Advertisement.NO_AD = "ADS_NO_AD"
```

### 在AppGallery Connect上查看数据

已收集的数据可在华为AppGallery Connect的[华为分析服务](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/dashboard-0000001050985173)中查看。

![readme_agc_screenshot](https://user-images.githubusercontent.com/101535354/158502766-6c525803-e03d-4381-866e-af98fa756ae5.png)


#### 实时调试

开发者也可在[应用调试](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/app-debugging-0000001051799712)中查看实时数据。

![readme_app_debugging_screenshot](https://user-images.githubusercontent.com/101535354/158502829-75fa5e1f-9a12-4bb2-8040-ee40448f6c67.png)


<p align="right">(<a href="#top">回页顶</a>)</p>

<!-- List of Data Per Event -->
## 自动收集的数据
每次调用onEvent API都会收集以下数据：

```
1. allow_push （是否允许推送）	
2. app_ver（APP版本号）
3. channel （安装来源渠道，如有）
4. country_code （国家码，如有）
5. emui_ver （华为手机EMUI版本号，如有）
6. gaid （谷歌广告ID，没有获取的话返回 "00000000-0000-0000-0000-000000000000"）
7. gms_availability （设备是否有谷歌服务GMS）
8. hms_availability （设备是否有华为服务HMS）
9. huawei_aaid （华为设备标识符，没有获取的话返回 "00000000-0000-0000-0000-000000000000"）
10. huawei_oaid （华为OAID，没有获取的话返回 "00000000-0000-0000-0000-000000000000"）
11. is_emulator （设备是否模拟器）
12. manufacturer （设备厂商）
13. model （设备型号）
14. oaid_tracking_flag （用户是否允许通过OAID追踪）
15. os （设备操作系统）
16. os_ver （设备操作系统版本号）
17. package_name （APP包名）
18. rom_ver （设备ROM版本号）
19. screen_height （设备屏幕高度）
20. screen_width （设备屏幕宽度）
21. sys_language （设备系统语言）
22. terminal_name （设备名称）
23. timestamp （触发EVENT的时间戳）
24. timezone （设备时间的时区）
25. user_agent （用户代理）
26. uuid （Gamelogger生成的UUID）
```

<p align="right">(<a href="#top">回页顶</a>)</p>



<!-- CONTACT -->
## 联络我们

开发者 - sailgamelogger@hotmail.com

项目链接: [https://github.com/sail-gamelogger/gamelogger](https://github.com/sail-gamelogger/gamelogger)

<p align="right">(<a href="#top">回页顶</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/sail-gamelogger/Gamelogger.svg?style=for-the-badge
[contributors-url]: https://github.com/sail-gamelogger/Gamelogger/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/sail-gamelogger/Gamelogger.svg?style=for-the-badge
[forks-url]: https://github.com/sail-gamelogger/Gamelogger/network/members
[stars-shield]: https://img.shields.io/github/stars/sail-gamelogger/Gamelogger.svg?style=for-the-badge
[stars-url]: https://github.com/sail-gamelogger/Gamelogger/stargazers
[issues-shield]: https://img.shields.io/github/issues/sail-gamelogger/Gamelogger.svg?style=for-the-badge
[issues-url]: https://github.com/sail-gamelogger/Gamelogger/issues
[license-shield]: https://img.shields.io/github/license/sail-gamelogger/Gamelogger.svg?style=for-the-badge
[license-url]: https://github.com/sail-gamelogger/Gamelogger/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[product-screenshot]: images/screenshot.png
[agc-screenshot]: images/readme_agc_screenshot.png
[app_debugging-screenshot]: images/readme_app_debugging_screenshot.png
