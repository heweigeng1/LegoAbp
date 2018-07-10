# LegoAbp

LegoAbp是基于ABP的模块化开发框架,我设计这个框架的初衷是,提升代码的复用率.各个模块之间可以相互组合来创建新的业务.而不是像以前那样到处复制代码段.来粘贴到新项目中

## 目录

## 项目结构

- Modules 模块
	- 涉及业务,譬如订单,活动,内容管理
- PlugIn 插件
	- 不带业务, 对接第三方接口 如微信 支付宝 百度,还可以是业务的抽象实现
- src ABP的基础模块
	- LegoAbp.Core 公用的核心功能
	- LegoAbp.EntityFrameworkCore 微软的orm,这里我作了一些修改,就是通过反射也能注册Modules 里各个模块中的实体了.首次运行的时候要先在此项目中执行EF的迁移来初始化数据库
	- LegoAbp.Web 项目的入口.
- test 单元测试
	- 后期可能会添加根据单元测试来生成各个模块的文档.可以通过这个功能创建网站来查看各个模块的文档.以后模块会发布到nuget,就很方便作为资料.

## 更新明细

7-10 module的IRepository自动注册到容器 </br>
module的Initialize中添加:IocManager.Resolve<ILegoAbpModuleRepositoryRegistrar>().ModuleRepositoryRegistrar(assembly);

7-3 添加Swagger API文档生成组件

7-2 EF迁移可以迁移包括Modules 里各模块的实体,需要在实体的配置文件继承EntityConfigurationBase 类