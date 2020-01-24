using UnityEngine;
using Entitas;

public class InitializeAsteroidsSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializeAsteroidsSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        for (int i = 0; i < 4; i++)
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddAsteroid(3);
            entity.AddInitialPosition(new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0.0f));
        }
    }
}
