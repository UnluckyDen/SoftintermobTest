using System;
using Application.Events;
using Domain.Interfaces;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Application.UseCases
{
    public class UpgradeHeroUseCase : IDisposable, IStartable
    {
        private readonly IUpgradable _heroModel;
        private readonly IDisposable _subscription;

        [Inject]
        public UpgradeHeroUseCase(IUpgradable upgradable, ISubscriber<OnTryUpgrade> subscriber)
        {
            _heroModel = upgradable;
            _subscription = subscriber.Subscribe(_ => Execute());
        }

        public void Start()
        {
        }

        public void Execute()
        {
            if (_heroModel.CanUpgrade.CurrentValue)
                _heroModel.Upgrade();
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}