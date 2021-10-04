using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingCarosel : MonoBehaviour
{

    float generationArea = -16;
    public GameObject FactoryClass;

    void Awake(){
        for(var ii = 0; ii < 5; ii++)
            ToppingFactory.AddMoreFlavour();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float left = -generationArea;
        foreach(var obj in this.gameObject.GetComponentsInChildren<ToppingFactory>()){
            if(obj.transform.position.x  > -generationArea){
                GameObject.Destroy(obj.gameObject);
            }
            var topping = obj.gameObject.GetComponentInChildren<Topping>();
            if(topping){
                left = Mathf.Min(obj.transform.position.x - topping.Width/2.0f, left);
            }
            
        }

        if(left > generationArea){
            var position = new Vector3(generationArea, this.transform.position.y, 0);
            var created = Instantiate(FactoryClass, position, Quaternion.identity);
            created.transform.SetParent(this.transform);
        }
    }
}
