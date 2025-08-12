using Application.Events;
using Application.UseCases;
using Domain.Interfaces;
using Domain.Models.HeroModel;
using VContainer;
using VContainer.Unity;
using MessagePipe;
using R3;

namespace Infrastructure
{
    public class RootLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<OnTryUpgrade>(options);
            
            builder.Register(sp => new HeroModel(1, 10), Lifetime.Singleton).As<HeroModel, IUpgradable>();
            
            builder.Register(sp =>  sp.Resolve<HeroModel>().Level, Lifetime.Singleton).Keyed("LevelStream");
            builder.Register(sp =>  sp.Resolve<HeroModel>().Strength, Lifetime.Singleton).Keyed("StrengthStream");
            
            builder.RegisterEntryPoint<UpgradeHeroUseCase>();
        }
    }
}