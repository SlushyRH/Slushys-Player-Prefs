# Slushy's Player Prefs
An easy to use, scalable and flexible alternative to Unity's default Player Prefs. Slushy's Player Prefs are available for download on the [Unity Asset Store]() or this Github's [Releases](https://github.com/SlushyRH/Slushys-Player-Prefs/releases) page.

With Slushy's Player Prefs you can save and load any serializable data type with two very simple methods!

## Features
|                             | Player Prefs     | Slushy's Player Prefs
|-----------------------------|------------------|------------------
| Encryption                  |❌|✔️
| Set and Get Ints            |✔️|✔️
| Set and Get Strings         |✔️|✔️
| Set and Get Floats          |✔️|✔️
| Set and Get Booleans        |❌|✔️
| Set and Get Chars           |❌|✔️
| Set and Get Doubles         |❌|✔️
| Set and Get Enums           |❌|✔️
| Set and Get Vector2         |❌|✔️
| Set and Get Vector3         |❌|✔️
| Set and Get Vector4         |❌|✔️
| Set and Get Quaternion      |❌|✔️
| Set and Get Colors          |❌|✔️
| Set and Get Lists           |❌|✔️
| Set and Get Arrays          |❌|✔️

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