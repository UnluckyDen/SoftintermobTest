using System;
using Presentation.Views.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace Presentation.Views
{
    public class UpgradeHeroView : MonoBehaviour, IUpgradeView
    {
        public event Action Upgrade;
        
        [SerializeField] private UIDocument _uiDocument;
        private VisualElement _root;

        private void Start()
        {
            _root = _uiDocument.rootVisualElement;
            VisualElement button = _root.Q<Button>("UpgradeButton");
            
            button.RegisterCallback<ClickEvent>(OnClick);
        }

        public void OnClick(ClickEvent clickEvent) =>
            Upgrade?.Invoke();
    }
}