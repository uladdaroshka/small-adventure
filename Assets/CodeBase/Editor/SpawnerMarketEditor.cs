using CodeBase.Logic.EnemySpawners;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
  [CustomEditor(typeof(SpawnMarker))]
  public class SpawnerMarketEditor : UnityEditor.Editor
  {
    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    public static void RenderCustomGizmo(SpawnMarker spawner, GizmoType gizmo)
    {
      CircleGizmo(spawner);
    }

    private static void CircleGizmo(SpawnMarker spawner)
    {
      Gizmos.color = Color.red;
      Gizmos.DrawSphere(spawner.transform.position, 0.5f);
    }
  }
}