using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
	Renderer rend;
	public Color aliveColor;
	public Color deadColor;
    public Color toDie;
    public PlayerController PC;

	public int x = -1;
	public int y = -1;
    bool beenSelected = false;

	public bool nextAlive;
	private bool _alive = false;
    public bool Alive
    {
        get
        {
            return this._alive;
        }
        set
        {
            this._alive = value;
            
            if (this._alive) {
				rend.material.color = aliveColor;
			} else {
				rend.material.color = deadColor;
			}
		}
    }

    // Start is called before the first frame update
    void Start()
    {
		rend = gameObject.GetComponent<Renderer>();
        //this.Alive = Random.value < 0.5f;
        this.Alive = false;

        GameObject Player = GameObject.Find("Player");
        PC = Player.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!this.nextAlive && Alive)
        {
            rend.material.color = toDie;
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(PC.counter <= 10)
    //    {
    //        this.Alive = true;
    //    }
    //    Debug.Log(this.Alive);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (PC.counter <= 10 && !beenSelected)
        {
            this.Alive = true;
            beenSelected = true;
            PC.counter++;
        }
        Debug.Log(this.Alive);
    }


    public void TurnRed()
    {
        if (!this.nextAlive && this._alive)
        {
            rend.material.color = toDie;
            Debug.Log("to die to die to die");
        }
    }
}
