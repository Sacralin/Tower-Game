using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveComposition
{
    public  List<Enemy> wave = new List<Enemy>();




    public void Level1WaveComposition()
    {
        wave.Add(new Enemy("footman",5));
        wave.Add(new Enemy("footman",10));
        wave.Add(new Enemy("footman",10));
        wave.Add(new Enemy("footman",10));

        wave.Add(new Enemy("footman", 10));
        wave.Add(new Enemy("footman")); 

        wave.Add(new Enemy("footman", 10));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman")); 

        wave.Add(new Enemy("footman", 10));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));

        wave.Add(new Enemy("hero", 10));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));

        wave.Add(new Enemy("hero",10));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));

        wave.Add(new Enemy("hero", 10));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("footman"));

        wave.Add(new Enemy("hero", 10));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));

        wave.Add(new Enemy("dragon", 10));


        //////////////////////////////////


        wave.Add(new Enemy("footman", 20));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));

        wave.Add(new Enemy("hero", 5));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));

        wave.Add(new Enemy("hero", 5));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));

        wave.Add(new Enemy("hero", 5));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("footman"));
        wave.Add(new Enemy("footman"));


        wave.Add(new Enemy("hero", 5));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("footman"));

        wave.Add(new Enemy("hero", 5));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));

        wave.Add(new Enemy("dragon", 10));
        wave.Add(new Enemy("dragon"));
        wave.Add(new Enemy("dragon"));


        //////////////////////////////////


        //////////////////////////////////


        wave.Add(new Enemy("hero", 20));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));

        wave.Add(new Enemy("hero", 5));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("dragon"));

        wave.Add(new Enemy("hero", 5));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("dragon"));
        wave.Add(new Enemy("dragon"));

        wave.Add(new Enemy("hero", 5));
        wave.Add(new Enemy("hero"));
        wave.Add(new Enemy("dragon"));
        wave.Add(new Enemy("dragon"));
        wave.Add(new Enemy("dragon"));


        wave.Add(new Enemy("hero", 5));
        wave.Add(new Enemy("dragon"));
        wave.Add(new Enemy("dragon"));
        wave.Add(new Enemy("dragon"));
        wave.Add(new Enemy("dragon"));

        wave.Add(new Enemy("dragon", 5));
        wave.Add(new Enemy("dragon"));
        wave.Add(new Enemy("dragon"));
        wave.Add(new Enemy("dragon"));
        wave.Add(new Enemy("dragon"));

    }

    
    
}
