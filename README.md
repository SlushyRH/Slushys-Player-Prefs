# Slushy's Player Prefs
An easy to use, scalable and flexible alternative to Unity's default Player Prefs. Slushy's Player Prefs are available for download on the [Unity Asset Store]() or this Github's [Releases](https://github.com/SlushyRH/Slushys-Player-Prefs/releases) page.

With Slushy's Player Prefs you can save and load any serializable data type with two very simple methods!

## Features
|                             | Player Prefs     | Slushy's Player Prefs
|-----------------------------|------------------|------------------
| Encryption                  |:x:               |:heavy_check_mark:
| Set and Get Ints            |:heavy_check_mark:|:heavy_check_mark:
| Set and Get Strings         |:heavy_check_mark:|:heavy_check_mark:
| Set and Get Floats          |:heavy_check_mark:|:heavy_check_mark:
| Set and Get Booleans        |:x:               |:heavy_check_mark:
| Set and Get Chars           |:x:               |:heavy_check_mark:
| Set and Get Doubles         |:x:               |:heavy_check_mark:
| Set and Get Enums           |:x:               |:heavy_check_mark:
| Set and Get Vector2         |:x:               |:heavy_check_mark:
| Set and Get Vector3         |:x:               |:heavy_check_mark:
| Set and Get Vector4         |:x:               |:heavy_check_mark:
| Set and Get Quaternion      |:x:               |:heavy_check_mark:
| Set and Get Colors          |:x:               |:heavy_check_mark:
| Set and Get Lists           |:x:               |:heavy_check_mark:
| Set and Get Arrays          |:x:               |:heavy_check_mark:

## How to Use
More information in the Demo Scene included in the product.
### Save Values to Player Prefs
```` C#
using SRH;

public class HighscoreManager : MonoBehaviour
{
    public void Awake()
    {
        // Not encrypted
        SPP.Set("myInt", 126);
        SPP.Set("myBool", true);
        SPP.Set("myVector3", transform.position);

        // Encrypted
        SPP.SetEncrypted("myInt", 126);
        SPP.SetEncrypted("myBool", true);
        SPP.SetEncrypted("myVector3", transform.position);
    }
}
````
### Get Values from Player Prefs
```` C#
using SRH;

public class HighscoreManager : MonoBehaviour
{
    public void Awake()
    {
        // Works even if pref is encrypted
        int myInt = SPP.Get("myInt");
        bool myBool = SPP.Get("myBool");
        Vector3 myVector3 = SPP.Get("myVector3");]
    }
}
````