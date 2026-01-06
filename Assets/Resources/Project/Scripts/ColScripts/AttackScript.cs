using UnityEngine;
using UnityEngine.Analytics;

public class AttackScript : MonoBehaviour
{
    private AttackSensor attackSensor;
    private Animator anim;
    [SerializeField] private GameObject AttackSensorObject;
    private static int overHeatTemp = 40;
    private static int overCoolTemp = 30;
    public int attackAnim = 2; // 0: 火炎放射 1: 冷凍光線 2:攻撃していない
    public bool isAttacking;
    private void Awake()
    {
        attackSensor = AttackSensorObject.GetComponent<AttackSensor>();
        anim = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if ( TempManager.Instance.temp <= overHeatTemp &&  TempManager.Instance.temp >= overCoolTemp)
        {
            if (isAttacking)
            {
                if (attackAnim == 0)
                {
                    EndFireAttack();
                }
                else if (attackAnim == 1)
                {
                    EndIceAttack();
                }
            }
            AttackSensorObject.SetActive(false);
            attackAnim = 2;
            isAttacking = false;
            return;
        }
        if (!PlayerMovement.Instance.isGrounded)
        {
            AttackSensorObject.SetActive(false);
            if (isAttacking)
            {
                if (attackAnim == 0)
                {
                    EndFireAttack();
                }
                else if (attackAnim == 1)
                {
                    EndIceAttack();
                }
            }
            attackAnim = 2;
            isAttacking = false;
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if ( TempManager.Instance.temp >= 41)
            {
                attackSensor.attackmode = 0; // 火炎放射
                attackAnim = 0;
                isAttacking = true;
                StartFireAttack();
                AttackSensorObject.SetActive(true);
            }
            else if ( TempManager.Instance.temp <= 29)
            {
                attackSensor.attackmode = 1; // 冷凍光線
                attackAnim = 1;
                isAttacking = true;
                StartIceAttack();
                AttackSensorObject.SetActive(true);
            }
            else
            {
                return;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isAttacking)
            {
                if (attackAnim == 0)
                {
                    EndFireAttack();
                }
                else if (attackAnim == 1)
                {
                    EndIceAttack();
                }
            }
            attackAnim = 2;
            isAttacking = false;
            AttackSensorObject.SetActive(false);
        }

    }

    void StartFireAttack()
    {
        anim.SetInteger("Motion", 3);
    }
    void StartIceAttack()
    {
        anim.SetInteger("Motion", 6);
    }

    void EndFireAttack()
    {
        anim.SetInteger("Motion", 5); // FireAttack_End
    }

    void EndIceAttack()
    {
        anim.SetInteger("Motion", 8); // FireAttack_End
    }
    public void FireLoop()
    {
        anim.SetInteger("Motion", 4); // FireAttack_Loop
    }

    public void IceLoop()
    {
        anim.SetInteger("Motion", 7); // IceAttack_Loop
    }

    public void EndAttack()
    {
        anim.SetInteger("Motion",0);
    }

}
