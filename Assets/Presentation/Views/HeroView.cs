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

        private int _level;
        private int _strength;

        private void Start()
        {
            _root = _uiDocument.rootVisualElement;
            _levelText = _root.Q<Label>("LevelText");
            _strengthText = _root.Q<Label>("StrengthText");

            UpdateLevelText();
            UpdateStrengthText();
        }

        public void UpdateLevel(int level)
        {
            _level = level;
            UpdateLevelText();
        }

        public void UpdateStrength(int strength)
        {
            _strength = strength;
            UpdateStrengthText();
        }

        private void UpdateLevelText()
        {
            if (_levelText == null)
                return;
            
            _levelText.text = $"Hero level: {_level}";
        }

        private void UpdateStrengthText()
        {
            if (_strengthText == null)
                return;
            
            _strengthText.text = $"Hero strength: {_strength}";
        }
    }
}