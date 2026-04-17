using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class DogAnimController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    Animator dogAnim;
    [SerializeField]
    Button BtnBark;
    [SerializeField]
    Button BtnRoll;
    [SerializeField]
    Button BtnSpin;
    public int animState { get; set; }
    

    void Awake()
    {

        
        if (BtnRoll != null && BtnBark != null && BtnSpin !=null)
        {
            // Listen to its onClick event
            BtnRoll.onClick.AddListener(OnButtonClick);
            BtnBark.onClick.AddListener(OnButtonClick);
            BtnSpin.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        dogAnim.SetBool("ButPressed",true);
    }


    IEnumerator Start()
    {
        
        dogAnim = GetComponent<Animator>();
        //float timer = 0f;
        //while (timer < 10f)
        //{
        //    timer += Time.deltaTime;
        //}

       // if (timer >= 10f & !dogAnim.GetBool("ButPressed"))
       // {
       //     Debug.Log(timer);
       //     timer = 0f;    
       //     dogAnim.SetInteger("Sit_ID", Random.Range(0,3));
       //     dogAnim.SetTrigger("Sit");
       //     yield return null; // wait one frame
       //     Debug.Log(timer);
       // }
  
        
        if (animState == 1)
        {

            dogAnim.SetTrigger("ToSit");
            dogAnim.SetInteger("Com_ID",1);
            dogAnim.SetBool("ButPressed",false);
            yield return new WaitForSeconds(3f);
            animState = 0;

        }
        if (animState == 2)
        {
            Debug.Log("Triggered Bark");
            dogAnim.SetInteger("Com_ID",0);
            dogAnim.SetTrigger("ToStand");

            dogAnim.SetBool("ButPressed",false);
            yield return new WaitForSeconds(3f);
            animState = 0;
            
        }
        if (animState == 3)
        {
            Debug.Log("Triggered Spin");
            dogAnim.SetTrigger("ToStand");
            dogAnim.SetInteger("Com_ID",2);
            dogAnim.SetBool("ButPressed",false);
            yield return new WaitForSeconds(3f);
            animState = 0;
        }
        
    }


}
