using UnityEngine;

public static class HelperMath
{
    public static float CalculateAcceleration(Vector2 currentVelocity,Vector2 direction,float speed,float accelTime)
    {
        float acceleration;
        float velocity = Mathf.Abs(currentVelocity.magnitude);
        acceleration = speed - velocity;
        acceleration/= accelTime;
        return acceleration;    
    }

    public static Vector2 CalculateJumpForce(float jumpHeight, float jumpRange,float _gravity)
    {
        float vertical = Mathf.Sqrt(2*jumpHeight*_gravity);
        float horizontal = (jumpRange * _gravity)/(2*vertical);
        return new Vector2(horizontal, vertical);
    }
}
