using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _numeroVidasHero = 10;
    private float _numeroVidasEnemy = 10;
    private bool _isDeadHero = false;
    private bool _isDeadEnemy = false;
    private bool _isBlockHero = false;
    private bool _isBlockEnemy = false;



    //L�gica vida Hero  

    public float NumeroVidasHero
    {
        get { return _numeroVidasHero; }
        set { _numeroVidasHero = value; }
    }

    //L�gica vida Enemy 

    public float NumeroVidasEnemy
    {
        get { return _numeroVidasEnemy; }
        set { _numeroVidasEnemy = value; }
    }



    //L�gica muerte Hero

    public bool IsDeadHero
    {
        get { return _isDeadHero; }
        set {
            if (_numeroVidasHero < 1)
            {
                _isDeadHero = value;
            }
          
        
        }
    }

    //L�gica muerte enemigo

    public bool IsDeadEnemy
    {
        get { return _isDeadEnemy; }
        
        set {
            if (_numeroVidasEnemy < 1)
            {
                _isDeadEnemy = value;
            }
  
        
        }
            
        
        
    }

    //L�gica blockeo hero

    public bool IsBlockHero
    {
        get { return _isBlockHero; }
        set { _isBlockHero = value; }
    }

    //L�gica bloqueo Enemy
    public bool IsBlockEnemy
    {
        get { return _isBlockEnemy; }
        set { _isBlockEnemy = value; }
    }


}
