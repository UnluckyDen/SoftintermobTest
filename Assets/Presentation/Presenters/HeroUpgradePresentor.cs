using System;
using Application.Events;
using MessagePipe;
using Presentation.Views.Interfaces;
using VContainer;
using VContainer.Unity;

namespace Presentation.Presenters
{
    public class HeroUpgradePresenter : IDisposable, IStartable
    {
        private readonly IPublisher<OnTryUpgrade> _publisher;
        private readonly IUpgradeView _upgradeView;

        [Inject]
        public HeroUpgradePresenter(IUpgradeView upgradeView, IPublisher<OnTryUpgrade> publisher)
        {
            _upgradeView = upgradeView;
            _publisher = publisher;
        }

        public void Start()
        {
            _upgradeView.Upgrade += OnUpgradeButtonClicked;
        }

        public void Dispose()
        {
            _upgradeView.Upgrade -= OnUpgradeButtonClicked;
        }

        private void OnUpgradeButtonClicked() =>
            _publisher.Publish(new OnTryUpgrade());
    }
}