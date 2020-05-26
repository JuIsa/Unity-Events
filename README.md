# Unity Events and Fun Stuff

This repository is only for experimenting and fun

## Scenes

There are different scenes for variuos experiments. For instance, *Dance* scene if for experimenting with prefabs behaviour.

[SampleScene.scene](#Events)

[Dance.scene](#Dance)

[TileGenerator.scene](#Tiles)

[Dissapear.scene](#Fog)



## Scripts

There is a separate folder for all scripts called *Scripts*. Inside that folder there are subfolders for each scene, because there will a
lot of experiments based on separate scripts. Names of scripts more or less similar, at least in meaning, to scenes' names so it is easy to
find which script is responsible for a certain function.

## Textures

Separate folder for all types of textures. I am not going to test a lot of textures so far. Maybe in the future I will create subfolders
for *Normal map*, *Albedo map*, *Metallic*.

## Prefabs

Separate folder for prefabs, mostly of those that will be spawned a lot of times

## Materials

Separate folder for materials.

### <a name="Events">Events</a>

* ```Main.cs```, [Event1.cs](https://github.com/JuIsa/Unity-Events/blob/master/TonsOfEvents/Assets/Scripts/Events/Event1.cs), [Event2.cs](https://github.com/JuIsa/Unity-Events/blob/master/TonsOfEvents/Assets/Scripts/Events/Event2.cs),[Subscriber1.cs](https://github.com/JuIsa/Unity-Events/blob/master/TonsOfEvents/Assets/Scripts/Events/Subscriber1.cs), [Subscriber2.cs](https://github.com/JuIsa/Unity-Events/blob/master/TonsOfEvents/Assets/Scripts/Events/Subscriber2.cs)
*

This scene is only for testing events, delegates. 

### <a name="Dance">Dance</a>

* [DanceOfCubes.cs](https://github.com/JuIsa/Unity-Events/blob/master/TonsOfEvents/Assets/Scripts/Dance/DanceOfCubes.cs), [SelfAware.cs](https://github.com/JuIsa/Unity-Events/blob/master/TonsOfEvents/Assets/Scripts/Dance/SelfAware.cs)
* SpherePrefab
* SphereMeterial

Instantiate 400 spheres by 20x20 shape.
All spheres starting from the first line start to move up and down every 0.1 seconds.

### <a name="Tiles">Tiles</a>

* [TileGenerator.cs](https://github.com/JuIsa/Unity-Events/blob/master/TonsOfEvents/Assets/Scripts/Tiles/TileGenerator.cs)
* BlockPrefab
* image.jpg

The idea of this scene is to get pixels' colors of image and spawn cubes of that colors.
It is done using Unity's  ```GetPixels``` which return an array of colors. The image size is 512x512 but it will end up instantiating 262144 cubes which is too much for now. What I did instead is transform initial array or colors to 2D array with length 512x512.Then I transform given 2D array to a smaller array with length 64x64 by getting average color of 64 pixels. Final result is pretty gratifying.

### <a name="Fog">Dissapear</a>

* [Dissapear.cs](https://github.com/JuIsa/Unity-Events/blob/master/TonsOfEvents/Assets/Scripts/Dissapear/DissapearSelf.cs)
* Cube

As soon as a player come closer than 2.5 units cubes disables renderer 


