using System;
using Presentation.Views.Interfaces;
using R3;
using VContainer;
using VContainer.Unity;

namespace Presentation.Presenters
{
    public class HeroPresenter : IDisposable, IStartable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        
        private ILevelView _levelView;
        private IStrengthView _strengthView;

        [Inject]
        public HeroPresenter([Key("LevelStream")] ReadOnlyReactiveProperty<int> level,
            [Key("StrengthStream")] ReadOnlyReactiveProperty<int> strength,
            ILevelView levelView,
            IStrengthView strengthView)
        {
            _levelView = levelView;
            _strengthView = strengthView;
            
            level.Subscribe(OnLevelUpdated).AddTo(_disposables);
            strength.Subscribe(OnStrengthUpdated).AddTo(_disposables);
        }

        public void Start()
        {
        }

        public void Dispose() => _disposables.Dispose();

        private void OnLevelUpdated(int level) => _levelView.UpdateLevel(level);

        private void OnStrengthUpdated(int strength) => _strengthView.UpdateStrength(strength);
    }
}