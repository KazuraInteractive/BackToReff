using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();
        
        if (character && character.lives<3)
        {
            character.liveadd();
            Destroy(gameObject);
        }
    }
}
