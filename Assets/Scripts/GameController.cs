using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    public GameSetup gameSetup;
    private Systems _systems;
    // Start is called before the first frame update
    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        contexts.game.SetGameSetup(gameSetup);
        
        _systems = CreateSystems(contexts);
        _systems.Initialize();
    }

    // Update is called once per frame
    private void Update()
    {
        _systems.Execute();
    }

    Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
        .Add(new HelloWorldSystem())
        
        .Add(new InitializePlayerSystem(contexts))
        .Add(new InitializeAsteroidsSystem(contexts))

        .Add(new InputSystem(contexts))
        .Add(new ShootSystem(contexts))
        .Add(new HitAsteroidSystem(contexts))

        .Add(new MapAsteroidLevelToResourceSystem(contexts))
        .Add(new RotateLaserSystem(contexts))
        .Add(new InstantiateViewSystem(contexts))
        .Add(new RotatePlayerSystem(contexts))
        .Add(new ReplaceAccelerationSystem(contexts))
        .Add(new MoveSystem(contexts))
        .Add(new DestroySystem(contexts));
    }
}
