using Domain.Interfaces;
using R3;

namespace Domain.Models.HeroModel
{
    public class HeroModel : IUpgradable
    {
        private readonly ReactiveProperty<int> _level;
        private readonly ReactiveProperty<int> _strength;
        private readonly ReactiveProperty<bool> _canUpgrade;

        public ReadOnlyReactiveProperty<int> Level => _level;
        public ReadOnlyReactiveProperty<int> Strength => _strength;
        public ReadOnlyReactiveProperty<bool> CanUpgrade => _canUpgrade;


        public HeroModel(int level, int strength)
        {
            _level = new ReactiveProperty<int>(level);
            _strength = new ReactiveProperty<int>(strength);
            _canUpgrade = new ReactiveProperty<bool>(true);
        }

        public void Upgrade()
        {
            _level.Value += 1;
            _strength.Value += 5;
        }
    }
}
