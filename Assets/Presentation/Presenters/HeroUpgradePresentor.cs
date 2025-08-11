using System;
using Domain.Events;
using MessagePipe;

namespace Presentation.Presenters
{
    public class HeroUpgradePresenter : IDisposable
    {
        private readonly IPublisher<OnTryUpgrade> _publisher;

        public HeroUpgradePresenter(IPublisher<OnTryUpgrade> publisher)
        {
            _publisher = publisher;
        }

        public void OnUpgradeButtonClicked()
        {
            _publisher.Publish(new OnTryUpgrade());
        }

        public void Dispose()
        {
        }
    }
}