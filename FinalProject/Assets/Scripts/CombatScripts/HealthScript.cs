using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthScript : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Slider hpSlider;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI rustText;
    private Unit unit;
    float positionY;
    float positionX;
    public List<TextMeshProUGUI> popUps;
    [SerializeField]
    public TextMeshProUGUI preFab;
    public GameObject location;
    public ParticleSystem rustParticles;
    public ParticleSystem recoverParticles;
    public void Start(){
        popUps = new List<TextMeshProUGUI>();
        int i =0;
        positionY = rustText.transform.localPosition.y;
        positionX = rustText.transform.localPosition.x;
        for(i = 0; i < 10; i++){
            TextMeshProUGUI pop =Instantiate(preFab);
            pop.transform.SetParent(location.transform);
            pop.gameObject.SetActive(false);
            pop.transform.localPosition=new Vector3(positionX,positionY,0);
            pop.transform.localScale = new Vector3(1,1,1);
            popUps.Add(pop);
        }
    }
    public void SetUp(Unit unit){
        this.unit=unit;
        healthText.text=""+unit.maxHealth+ "/"+unit.maxHealth;
        nameText.text=unit.name;
        hpSlider.maxValue = unit.maxHealth;
        hpSlider.value = unit.currHealth;

    }
    public void SetHealth(int health){
        healthText.text=""+health+ "/"+unit.maxHealth;
        hpSlider.value = health;
    }
    public void RustText(){
        positionY = rustText.transform.localPosition.y;
        positionX = rustText.transform.localPosition.x;
        int i = 0;
        for(i = 0; i < 10; i++){
            if(popUps[i].IsActive() == false){
                popUps[i].gameObject.SetActive(true);
                popUps[i].transform.position.Set(positionX,positionY,0);
                popUps[i].text="Rust!";
                break;
            }
        }
        StartCoroutine(fade());
        IEnumerator fade(){
            float timer = 0;
         while (timer < 1f){
            yield return null;
            timer+=Time.deltaTime;
            popUps[i].color=Color.Lerp(new Color(166, 77, 10,1),new Color(166, 77, 10,0),timer/1f);
            popUps[i].transform.localPosition=Vector3.Lerp(new Vector3(positionX,positionY,0),new Vector3(positionX,positionY+40,0),timer/1f);
            }
            popUps[i].transform.localPosition=new Vector3(positionX,positionY,0);
            popUps[i].gameObject.SetActive(false);
        }
    }
    public void RecoverText(){
        positionY = rustText.transform.localPosition.y;
        positionX = rustText.transform.localPosition.x;
        int i = 0;
        for(i = 0; i < 10; i++){
            if(popUps[i].IsActive() == false){
                popUps[i].gameObject.SetActive(true);
                popUps[i].transform.position.Set(positionX,positionY,0);
                popUps[i].text="Recovering...";
                break;
            }
        }
        StartCoroutine(fade());
        IEnumerator fade(){
            float timer = 0;
         while (timer < 1f){
            yield return null;
            timer+=Time.deltaTime;
            popUps[i].color=Color.Lerp(new Color(166, 77, 10,1),new Color(166, 77, 10,0),timer/1f);
            popUps[i].transform.localPosition=Vector3.Lerp(new Vector3(positionX,positionY,0),new Vector3(positionX,positionY+40,0),timer/1f);
            }
            popUps[i].transform.localPosition=new Vector3(positionX,positionY,0);
            popUps[i].gameObject.SetActive(false);
        }
    
    }
    public void RustDamageTaken(){
        rustParticles.Play();
    }
    public void Recovering(){
        recoverParticles.Play();
    }
}
