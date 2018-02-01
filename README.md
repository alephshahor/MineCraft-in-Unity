# Minecraft-in-Unity
My First personal project in order to Learn Unity and C#.

In this Project I'll try to create a Voxel Game from Scratch using Unity and not having any knowledge about the Graphic Motor and C#, only 
knowing a little bit about C++.

#### First Result 

The first "Successfull" result that I've got is this attempt of creating an abstraction of a "Minecraft world" by creating three clases: *Block*, *Chunk* and *World*. This is the final result:

![First Result Image 1](https://imgur.com/E4rXlJ1)

![First Result Image 2](https://imgur.com/C31rLM5)

As you can see I've been able to create separate Chunks of variable Size in differente positions wich is actually a result that I'm very proud of at this moment taking in account that I had no idea about anything.

_But there's a huge problem_. 

It only exist one Mesh wich is actually the World Mesh that contains every vertex of every block inside every Chunk, that's actually a huge problem because I can't modify each block mesh characteristics (for example, textures).
I've to figure out a way of creating different meshes for differente type of blocks so I can change any of those blocks during the execution of the program.



