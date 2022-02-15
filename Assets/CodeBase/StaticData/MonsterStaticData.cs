using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "StaticData/Monster")]
    public class MonsterStaticData : ScriptableObject
    {
        public MonsterTypeId MonsterTypeId;
        
        [Range(1, 100)]
        public float Hp;
        
        [Range(1.0f, 30.0f)]
        public float Damage;

        [Range(0.5f, 1.0f)] 
        public float EffectiveDistance = 0.666f;

        [Range(0.5f, 1.0f)]
        public float Cleavage;
        
        [Range(0.0f, 100.0f)]
        public float MoveSpeed;

        public GameObject Prefab;
    }
}