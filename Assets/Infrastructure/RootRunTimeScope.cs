using Domain.Models.HeroModel;
using Domain.UseCases;
using VContainer;
using VContainer.Unity;
using MessagePipe;
using Presentation.Presenters;

namespace Infrastructure
{
    public class RootLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();
            
            builder.Register<HeroModel>(Lifetime.Singleton);
            builder.Register<UpgradeHeroUseCase>(Lifetime.Scoped);

            builder.Register(sp => 
            {
                var heroModel = sp.Resolve<HeroModel>();
                return new HeroPresenter(heroModel.Level, heroModel.Strength);
            }, Lifetime.Singleton);
        }
    }
}