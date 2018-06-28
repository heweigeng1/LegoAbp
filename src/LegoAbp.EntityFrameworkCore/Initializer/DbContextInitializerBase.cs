using Abp.Dependency;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LegoAbp.Initializer
{

    /// <summary>
    /// 数据上下文初始化基类
    /// </summary>
    public abstract class DbContextInitializerBase
    {
        public virtual void RegistrarEntitySetMap(EntityTypeBuilder entityTypeBuilder)
        {

        }
    }
}
