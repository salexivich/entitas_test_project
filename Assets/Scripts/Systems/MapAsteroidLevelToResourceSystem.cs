using UnityEngine;
using Entitas;
using System.Collections.Generic;

public class MapAsteroidLevelToResourceSystem : ReactiveSystem<GameEntity>
{

    private Contexts _contexts;
    public MapAsteroidLevelToResourceSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asteroid);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsteroid;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var setup = _contexts.game.gameSetup.value;
        foreach (var entity in entities)
        {
            entity.AddResource(MapAsteroidLevelToResource(entity.asteroid.level, setup));
            var speed = _contexts.game.gameSetup.value.asteroidSpeed;
            var angle = Random.Range(0.0f, 2.0f);
            entity.AddAcceleration(new Vector3(speed * Mathf.Cos(angle), speed * Mathf.Sin(angle), 0.0f));
        }
    }

    private GameObject MapAsteroidLevelToResource(int level, GameSetup gameSetup)
    {
        switch (level)
        {
            case 0:
                return gameSetup.tinys[Random.Range(0, gameSetup.tinys.Length)];
            case 1:
                return gameSetup.smalls[Random.Range(0, gameSetup.smalls.Length)];
            case 2:
                return gameSetup.meds[Random.Range(0, gameSetup.meds.Length)];
            case 3:
                return gameSetup.bigs[Random.Range(0, gameSetup.bigs.Length)];
            default:
                return gameSetup.bigs[Random.Range(0, gameSetup.bigs.Length)];
        }
    }
}
