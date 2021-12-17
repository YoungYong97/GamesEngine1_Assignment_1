# GamesEngine1_Assignment_1
#### Name: Yonghui Huang
#### Student Number: C15335771
#### Course Code: DT282/4

## Description of Assignment
This Unity Application takes in an audio file(music) and then visualizes the audio. This application is made up of a ring of 32 cubes and a line of eight cubes. I modified the cubes so that the cubes only scale in one direction and on both ways.

![image](https://user-images.githubusercontent.com/22171305/146187241-5138568e-62e8-4b40-a744-609872d5be22.png)

![image](https://user-images.githubusercontent.com/22171305/146187463-6526b8d2-caa2-4513-b7d2-2aae28fe4d87.png)

## Instructions for use
Import the audio file that you wish to play as an asset, then drag the audio file to the audio source of the sound component to set it as the audio file.

![image](https://user-images.githubusercontent.com/22171305/146189109-7c2cee35-cf17-4ee0-ada3-2c93ae6bb9c4.png)

## How it works
I get the spectrum value of the audio file every frame and use the spectrum value of the audio at that frame. Using this value I can then make changes to the scale of the object that I spawn.

![image](https://user-images.githubusercontent.com/22171305/146469569-6f2ce1d3-5217-4b95-b40f-2061b81233b8.png)

I also calculate the DB value of the audio, using this value I make changes to the color of the background.

![image](https://user-images.githubusercontent.com/22171305/146470258-0fcda892-10f7-4039-94b8-01e4591355c3.png)

The scale of each object spawned is changed every frame, this is done by using the spectrum value obtained from the analysis.

![image](https://user-images.githubusercontent.com/22171305/146469628-6db0d0f5-9534-405b-98a1-3f90e4e99ebf.png)


## References
https://www.youtube.com/watch?v=wtXirrO-iNA&t=122s

## Proposal
For my Games Engine project I would like to create a 3D music visualizer. The music visualizer would be something similar to the pictures below where the shapes change according to the music, But the one that I want to create would be in 3D.
The user would be able to upload a piece of music and the music visualizer would change according to the sounds from the music.
