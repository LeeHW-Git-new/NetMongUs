using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCrew : MonoBehaviour
{
    public EPlayerColor playerColor;

    SpriteRenderer spriteRenderer;
    Vector3 direction;
    float floatingSpeed;
    float rotateSpeed;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetFloatingCrew(Sprite sprite, EPlayerColor playerColor, Vector3 direction, float floatingSpeed, float rotateSpeed, float size)
    {
        this.playerColor = playerColor;
        this.direction = direction;
        this.floatingSpeed = floatingSpeed;
        this.rotateSpeed = rotateSpeed;

        spriteRenderer.sprite = sprite;
        spriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(playerColor));

        transform.localScale = new Vector3(size, size, size);
        spriteRenderer.sortingOrder = (int)Mathf.Lerp(1, 32767, size); //배경 크루원 큰사이즈가 앞으로 오게 설정
    }

    void Update()
    {
        //배경 크루원 회전 , 이동
        transform.position += direction * floatingSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, rotateSpeed));
    }
}
