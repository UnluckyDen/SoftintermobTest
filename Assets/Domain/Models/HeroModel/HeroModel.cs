using R3;

namespace Domain.Models.HeroModel
{
    public class HeroModel
    {
        private readonly ReactiveProperty<int> _level;
        private readonly ReactiveProperty<int> _strength;

        public ReadOnlyReactiveProperty<int> Level => _level;
        public ReadOnlyReactiveProperty<int> Strength => _strength;

        public HeroModel(int level = 1, int strength = 10)
        {
            _level = new ReactiveProperty<int>(level);
            _strength = new ReactiveProperty<int>(strength);
        }

        public void Upgrade()
        {
            _level.Value += 1;
            _strength.Value += 5;
        }
    }
}
