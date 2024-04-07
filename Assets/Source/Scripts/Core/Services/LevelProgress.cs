using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private List<RecallStone> _recallStones = new List<RecallStone>();
    [SerializeField] private LevelData _levelData;
}