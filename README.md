# LegoAbp

LegoAbp�ǻ���ABP��ģ�黯�������,����������ܵĳ�����,��������ĸ�����.����ģ��֮������໥����������µ�ҵ��.����������ǰ�����������ƴ����.��ճ��������Ŀ��

## Ŀ¼

## ��Ŀ�ṹ

- Modules ģ��
	- �漰ҵ��,Ʃ�綩��,�,���ݹ���
- PlugIn ���
	- ����ҵ��, �Խӵ������ӿ� ��΢�� ֧���� �ٶ�,��������ҵ��ĳ���ʵ��
- src ABP�Ļ���ģ��
	- LegoAbp.Core ���õĺ��Ĺ���
	- LegoAbp.EntityFrameworkCore ΢���orm,����������һЩ�޸�,����ͨ������Ҳ��ע��Modules �����ģ���е�ʵ����.�״����е�ʱ��Ҫ���ڴ���Ŀ��ִ��EF��Ǩ������ʼ�����ݿ�
	- LegoAbp.Web ��Ŀ�����.
- test ��Ԫ����
	- ���ڿ��ܻ���Ӹ��ݵ�Ԫ���������ɸ���ģ����ĵ�.����ͨ��������ܴ�����վ���鿴����ģ����ĵ�.�Ժ�ģ��ᷢ����nuget,�ͺܷ�����Ϊ����.

## ������ϸ

7-10 module��IRepository�Զ�ע�ᵽ���� </br>
module��Initialize�����:IocManager.Resolve<ILegoAbpModuleRepositoryRegistrar>().ModuleRepositoryRegistrar(assembly);

7-3 ���Swagger API�ĵ��������

7-2 EFǨ�ƿ���Ǩ�ư���Modules ���ģ���ʵ��,��Ҫ��ʵ��������ļ��̳�EntityConfigurationBase ��