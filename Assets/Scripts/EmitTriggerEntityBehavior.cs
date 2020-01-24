using UnityEngine;
public class EmitTriggerEntityBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.AddCollision(this.gameObject, other.gameObject);
    }
}