using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[CreateAssetMenu]
[Game, Unique]
public class GameSetup : ScriptableObject
{
    public GameObject playerPrefab;
    public GameObject laser;
    public float rotationSpeed = 180.0f;
    public float playerMovementSpeed = 5.0f;
    public float laserSpeed = 10.0f;
    public float asteroidSpeed = 0.3f;
    public GameObject[] bigs;
    public GameObject[] meds;
    public GameObject[] smalls;
    public GameObject[] tinys;
}
