using System;
using System.Threading;
using Application.Events;
using Cysharp.Threading.Tasks;
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
        public UpgradeHeroUseCase(IUpgradable upgradable, IAsyncSubscriber<OnTryUpgrade> subscriber)
        {
            _heroModel = upgradable;
            _subscription = subscriber.Subscribe((msg, ct) => Execute(ct));
        }

        public void Start()
        {
        }

        public async UniTask Execute(CancellationToken cancellationToken)
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