using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private const string MonstersDataPath = "Static Data/Monsters";
    private const string LevelsDataPath = "Static Data/Levels";
    private const string WindowsStaticData = "Static Data/UI/WindowStaticData";

    private Dictionary<MonsterTypeId, MonsterStaticData> _monsters;
    private Dictionary<string, LevelStaticData> _levels;
    private Dictionary<WindowID, WindowConfig> _windowConfigs;


    public void Load()
    {
      _monsters = Resources
        .LoadAll<MonsterStaticData>(MonstersDataPath)
        .ToDictionary(x => x.MonsterTypeId, x => x);
      
      _levels = Resources
        .LoadAll<LevelStaticData>(LevelsDataPath)
        .ToDictionary(x => x.LevelKey, x => x);
      
      _windowConfigs = Resources
        .Load<WindowStaticData>(WindowsStaticData)
        .Configs
        .ToDictionary(x => x.WindowID, x => x);
    }

    public MonsterStaticData ForMonster(MonsterTypeId typeId) => 
      _monsters.TryGetValue(typeId, out MonsterStaticData staticData)
        ? staticData 
        : null;

    public LevelStaticData ForLevel(string sceneKey) => 
      _levels.TryGetValue(sceneKey, out LevelStaticData staticData)
        ? staticData 
        : null;

    public WindowConfig ForWindow(WindowID windowID) => 
    _windowConfigs.TryGetValue(windowID, out WindowConfig windowConfig)
    ? windowConfig 
    : null;
  }
} 