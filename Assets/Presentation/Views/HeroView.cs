using Presentation.Views.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace Presentation.Views
{
    public class HeroView : MonoBehaviour, ILevelView, IStrengthView
    {
        [SerializeField] private UIDocument _uiDocument;
        
        private VisualElement _root;
        private Label _levelText;
        private Label _strengthText;

        private void Start()
        {
            _root = _uiDocument.rootVisualElement;
            _levelText = _root.Q<Label>("LevelText");
            _strengthText = _root.Q<Label>("StrengthText");
        }

        public void UpdateLevel(int level) => _levelText.text = $"Hero level: {level}";

        public void UpdateStrength(int strength) => _strengthText.text = $"Hero strength: {strength}";
    }
}