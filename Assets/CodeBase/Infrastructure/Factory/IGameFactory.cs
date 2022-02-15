using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
  public interface IGameFactory:IService
  {
    GameObject CreateHero(GameObject at);
    GameObject CreateHud();
    List<ISavedProgressReader> ProgressReaders { get; }
    List<ISavedProgress> ProgressWriters { get; }
    void Register(ISavedProgressReader progressReader);
    void Cleanup();
    void Register(ISavedProgressReader savedProgress);
    GameObject CreateMonster(MonsterTypeId monsterTypeId, Transform parent);
  }
}