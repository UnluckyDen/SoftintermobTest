using System;
using Domain.Events;
using Domain.Models.HeroModel;
using MessagePipe;

namespace Domain.UseCases
{
    public class UpgradeHeroUseCase : IDisposable
    {
        private readonly HeroModel _heroModel;
        private readonly IDisposable _subscription;

        public UpgradeHeroUseCase(HeroModel heroModel, ISubscriber<OnTryUpgrade> subscriber)
        {
            _heroModel = heroModel;
            _subscription = subscriber.Subscribe(_ => Execute());
        }

        public void Execute()
        {
            _heroModel.Upgrade();
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}