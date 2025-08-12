using R3;

namespace Domain.Interfaces
{
    public interface IUpgradable
    {
        public ReadOnlyReactiveProperty<bool> CanUpgrade { get; }
        public void Upgrade();
    }
}