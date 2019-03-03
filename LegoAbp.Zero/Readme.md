# LegoAbp的基础模块

主要包括用户,权限,租户等一些通用的功能

## 目录

## 结构

1. Application 是应用层.生成与用户权限的Services

## 本地化

在Localization文件夹下有一个针对当前模块或者功能的配置文件,与xml文档的文件夹.

添加新的本地化语言时,注意culture="zh-CN"也要修改为与文档匹配.如下:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<localizationDictionary culture="zh-CN">//zh-CN也要修改
  <texts>
    <text name="MyLocalization" value="么么哒!" />
  </texts>
</localizationDictionary>
```

LegoAbpZeroLocalization里面包含了一个Configure方法,用来配置本地化的信息.添加XML里面的本地化文档到系统里.

最后在LegoAbpModule里的PreInitialize里添加到本地化配置里

```c#
LegoAbpZeroLocalization.Configure(Configuration.Localization);
```

## 异步Service抛异常会中断调试

```c#
        public async void Login()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = "12345678901",
                PhoneNumber = "12345678901",
            };
            var result = await _userManager.CreateAsync(user, "123Aa_123");
            throw new UserFriendlyException("123");
        }
```
