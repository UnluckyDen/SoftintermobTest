using System;
using R3;

namespace Presentation.Presenters
{
    public class HeroPresenter : IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public HeroPresenter(ReadOnlyReactiveProperty<int> level, ReadOnlyReactiveProperty<int> strength)
        {
            level.Subscribe(OnLevelUpdated).AddTo(_disposables);
            strength.Subscribe(OnStrengthUpdated).AddTo(_disposables);
        }

        public void Dispose() => _disposables.Dispose();

        private void OnLevelUpdated(int level) => UnityEngine.Debug.Log($"Level: {level}");
        private void OnStrengthUpdated(int strength) =>  UnityEngine.Debug.Log($"Strength: {strength}");
    }
}