using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public Transform target;
    public Walkable walkable;
    public float oldPosition;
    public bool movingRight = false;
    public bool movingLeft = false;
    

     void LateUpdate(){
	    oldPosition = transform.position.x;
    }

    private void Update() {
        if (target != null) {
            var directionTowardsTarget = (target.position - this.transform.position).normalized;
            walkable.moveTo(directionTowardsTarget);

            Debug.Log($"Target Position: {target.position}, Enemy Position: {transform.position}, Direction: {directionTowardsTarget}");
        }

        /* flip left or right depending on direction */
        if (transform.position.x > oldPosition) {
            movingRight = true;
            movingLeft = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (transform.position.x < oldPosition) {
            movingRight = false;
            movingLeft = true;
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }

}

