using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 3f;
    [SerializeField] float xRangt = 5f;
    [SerializeField] float yRangt = 10f;
    [SerializeField] float PositionFacter = -5f;                               // Giá trị âm Rotation (-5f) sẽ đảo chiều ảnh hưởng (khi lên, góc giảm; khi xuống, góc tăng).
    [SerializeField] float ControlPitchFactor = -10f;
    [SerializeField] float PositionYawFacter = 5f;
    [SerializeField] float PositionFacterll = -20f;
    float xThrow, yThrow;
    void Update()
    {
        Moving();
        ProcessRotation();
    }
    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * PositionFacter;
        float pitchDueToControlthow = yThrow * ControlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlthow;                           // pitch trục x của Rotation , transform.localPosition.y đối tượng di chuyển dọc theo trục y, nó sẽ tự động thay đổi góc quay của mình theo một tỷ lệ được xác định bởi giá trị của PositionFacter.
        float yaw =  transform.localPosition.x* PositionYawFacter;
        float roll = xThrow * PositionFacterll;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);                         // nếu đối tượng đang di chuyển lên hoặc xuống, giá trị này sẽ thay đổi pitch
    }
    void Moving()
    {

        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float oxffset = xThrow * Time.deltaTime * MoveSpeed;
        float newXPos = transform.localPosition.x + oxffset;
        float clampeXPos = Mathf.Clamp(newXPos, -xRangt, xRangt);                                     //Mathf.Clamp giới hạn vật trục x di chuyển xRangt thừ -5 đến 5 

        float oyffset = yThrow * Time.deltaTime * MoveSpeed;
        float newYPos = transform.localPosition.y + oyffset;
        float clampeYPos = Mathf.Clamp(newYPos, -yRangt, yRangt);

        transform.localPosition = new Vector3(clampeXPos, clampeYPos, transform.localPosition.z);   // clampeXPos bao gồm xThrow( phương hương ngang) + oxffset tốc độ và Time.deltaTime + newXPos

    }
}
