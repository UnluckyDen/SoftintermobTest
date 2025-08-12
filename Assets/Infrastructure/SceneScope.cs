using Presentation.Presenters;
using Presentation.Views.Interfaces;
using VContainer;
using VContainer.Unity;

namespace Infrastructure
{
    public class SceneScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<ILevelView>();
            builder.RegisterComponentInHierarchy<IStrengthView>();
            builder.RegisterComponentInHierarchy<IUpgradeView>();

            builder.RegisterEntryPoint<HeroPresenter>();
            builder.RegisterEntryPoint<HeroUpgradePresenter>();
        }
    }
}