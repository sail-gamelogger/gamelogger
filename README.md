<div id="top"></div>
<!-- PROJECT LOGO -->
<br />
<div align="center">
<h1 align="center">Gamelogger</h1>

<!--[English](https://github.com/HMS-Core/hms-ml-demo/blob/master/README_public.md) | 中文-->

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
    <li>
      <a href="#查看和使用数据">查看和使用数据</a>
      <ul>
        <li><a href="#实时调试">实时调试</a></li>
        <li>
          <a href="#深度数据分析">深度数据分析</a>
            <ul>
              <li><a href="#会话路径分析">会话路径分析</a></li>
              <li><a href="#漏斗分析">漏斗分析</a></li>
            </ul>
        </li>
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

### 安装

1. 在root的build.gradle
```gradle
buildscript {
    repositories {
	//..
        maven { url 'https://developer.huawei.com/repo/' }
    }
    dependencies {
	//..
	//see latest version here: https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-Guides/agc-sdk-changenotes-0000001058732550
        classpath 'com.huawei.agconnect:agcp:{latest_version}'
    }
}

allprojects {
    repositories {
	//..
	maven { url 'https://developer.huawei.com/repo/' }
	maven { url 'https://jitpack.io' }
    }
}
```
2. 在app的build.gradle
```gradle
dependencies {
    //..
    implementation 'com.github.sail-gamelogger:gamelogger:1.0.1'
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

<!-- List of Data Per Event -->
### 自动收集的数据
每次调用onEvent API都会收集以下数据：

#### 参数
```
1. allow_push （是否允许推送）  
2. app_ver（APP版本号）
3. channel （安装来源渠道，如有）
4. country_code （国家码，如有）
5. emui_ver （华为手机EMUI版本号，如有）
6. gaid （谷歌广告ID，没有获取的话返回 "00000000-0000-0000-0000-000000000000"）
7. huawei_aaid （华为设备标识符，没有获取的话返回 "00000000-0000-0000-0000-000000000000"）
8. huawei_oaid （华为OAID，没有获取的话返回 "00000000-0000-0000-0000-000000000000"）
9. manufacturer （设备厂商）
10. model （设备型号）
11. oaid_tracking_flag （用户是否允许通过OAID追踪）
12. os （设备操作系统）
13. os_ver （设备操作系统版本号）
14. package_name （APP包名）
15. rom_ver （设备ROM版本号）
16. screen_height （设备屏幕高度）
17. screen_width （设备屏幕宽度）
18. sys_language （设备系统语言）
19. terminal_name （设备名称）
20. timestamp （触发EVENT的时间戳）
21. user_agent （用户代理）
22. uuid （Gamelogger生成的UUID）
```

#### 用户属性
```
1. GMS_Availability （设备是否有谷歌服务GMS）
2. HMS_Availability （设备是否有华为服务HMS）
3. Emulator （设备是否模拟器）
4. Timezone （设备时间的时区）
````

<p align="right">(<a href="#top">回页顶</a>)</p>

## 查看和使用数据

已收集的数据可在华为AppGallery Connect的[华为分析服务](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/dashboard-0000001050985173)中查看。

[![AppGallery Connect Analytics Screen Shot][agc-screenshot]](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/dashboard-0000001050985173)

### 实时调试

开发者也可在[应用调试](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/app-debugging-0000001051799712)中查看实时数据。

[![App Debugging Screen Shot][app_debugging-screenshot]](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/app-debugging-0000001051799712)

### 深度数据分析

收集回来的数据可以透过AppGallery Connect的工具进行深度分析，例如[会话路径分析](https://github.com/sail-gamelogger/gamelogger/edit/main/README.md#%E4%BC%9A%E8%AF%9D%E8%B7%AF%E5%BE%84%E5%88%86%E6%9E%90)和[漏斗分析](https://github.com/sail-gamelogger/gamelogger/edit/main/README.md#%E6%BC%8F%E6%96%97%E5%88%86%E6%9E%90)。

#### 事件及用户属性管理

在进行深度分祈前，需要在AppGallery Connect配置。

##### 事件管理

把需要用的事件在[事件管理](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/meta-manage-0000001050985177)进行添加。

[![Event Management Screenshot][event-mgt-screenshot]](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/meta-manage-0000001050985177)

亦可编辑事件以添加需要用到的参数。

##### 用户属性管理

把需要用的用户属性在[用户属性管理](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/user-attribute-management-0000001078556286)进行添加。

[![User Attribute Management Screenshot][ua-mgt-screenshot]](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/user-attribute-management-0000001078556286)

#### 会话路径分析

可在[会话路径分析](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/session-path-analysis-0000001078524332)查看事件路径。

[![Session Path Analysis Screenshot][sp-analysis-screenshot]](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/session-path-analysis-0000001078524332)

可以用用户属性在"添加过滤器"中筛选事件。

[![Session Path Analysis Screenshot][sp-analysis-ua-screenshot]](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/session-path-analysis-0000001078524332)

#### 漏斗分析

可以透过[漏斗分析](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/funnel-analysis-0000001051065100)查看用户的流失率．

[![Funnel Analysis Screenshot][fn-analysis-screenshot]](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/funnel-analysis-0000001051065100)

可以用用户属性在"添加过滤器"中筛选事件。

[![Funnel Analysis Screenshot][fn-analysis-ua-screenshot]](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/funnel-analysis-0000001051065100)

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
[event-mgt-screenshot]: images/readme_eventmanagement.png
[event-mgt-edit-screenshot]: images/readme_eventmanagement_edit.png
[ua-mgt-screenshot]: images/readme_userattributemanagement.png
[sp-analysis-screenshot]: images/readme_sessionpathanalysis.png
[sp-analysis-ua-screenshot]: images/readme_sessionpathanalysis_ua.png
[fn-analysis-screenshot]: images/readme_funnelanalysis.png
[fn-analysis-ua-screenshot]: images/readme_funnelanalysis_ua.png

