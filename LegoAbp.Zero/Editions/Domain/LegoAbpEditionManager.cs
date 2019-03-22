using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Dependency;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Editions.Domain
{
    public class LegoAbpEditionManager : AbpEditionManager, ITransientDependency
    {
        public LegoAbpEditionManager(IRepository<Edition> editionRepository, IAbpZeroFeatureValueStore featureValueStore) : base(editionRepository, featureValueStore)
        {
        }
    }
}
