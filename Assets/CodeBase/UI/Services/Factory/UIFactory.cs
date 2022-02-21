using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/UIRoot";
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;

        private Transform _uiRoot;

        public UIFactory(IAssetProvider assets, IStaticDataService staticData)
        {
            _staticData = staticData;
            _assets = assets;
        }
        
        public void CreateShop()
        {
            WindowConfig windowConfig = _staticData.ForWindow(WindowID.Shop);
            Object.Instantiate(windowConfig.Prefab, _uiRoot);
        }

        public void CreateUIRoot() =>
            _uiRoot = _assets.Instantiate(UIRootPath).transform;
    }
} 