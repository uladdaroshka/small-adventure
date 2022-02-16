using System;
using UnityEngine.Serialization;

namespace CodeBase.Data
{
  [Serializable]
  public class WorldData
  {
    public PositionOnLevel PositionOnLevel;
    public LootData LootData;


    public WorldData(string initialLevel)
    {
      PositionOnLevel = new PositionOnLevel(initialLevel);
    }
  }
}