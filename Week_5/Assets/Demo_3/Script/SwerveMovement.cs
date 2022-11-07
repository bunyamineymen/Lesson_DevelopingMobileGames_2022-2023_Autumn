
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{

    [SerializeField]
    private SwerveInputSystem swerveInputSystem;

    [SerializeField]
    private float swerveSpeed = 0.5f;

    [SerializeField]
    private float maxSwerveAmount = 1f;

    private void Update()
    {

        float swerveAmount = Time.deltaTime * swerveSpeed * swerveInputSystem.MoveFactoryX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0f, 0f);

    }


}
