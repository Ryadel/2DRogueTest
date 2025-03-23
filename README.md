# 2DRogueTest – A Simple 2D Roguelike Prototype in Unity using Visual Studio 2022 and C#

Welcome, adventurer! 🧙‍♂️

**2DRogueTest** is a free, open-source prototype of a **2D roguelike game** built in **Unity**, designed to serve as a learning project for developers who want to understand how to make a basic top-down dungeon crawler with procedural generation, simple enemy AI, and combat mechanics.

This project was created as a step-by-step educational example, and it's been fully documented through a 3-part tutorial series. Whether you're new to Unity or just curious about building roguelikes, you're in the right place.

---

## 📚 Tutorial Series

We wrote a complete tutorial series that walks you through every part of this project:

### 🔹 Part 1 of 3: Project Setup, Pixel Art and Player Movement
Learn how to set up a 2D Unity project, import pixel art sprites, organize your folder structure, and implement basic WASD player movement.
➡️ [Read Part 1](https://github.com/Ryadel/2DRogueTest)

### 🔹 Part 2 of 3: Enemies, AI and Combat System
We add enemies to the game, make them chase the player using a basic AI, and implement a simple close-range combat mechanic.
➡️ [Read Part 2](https://github.com/Ryadel/2DRogueTest)

### 🔹 Part 3 of 3: Procedural Dungeon Generation
In the final part, we create a procedural level generator that builds a new dungeon layout every time you play, complete with enemy spawn points and room templates.
➡️ [Read Part 3](https://github.com/Ryadel/2DRogueTest)

---

## 🕹️ Features

- Top-down 2D movement using `Rigidbody2D`
- Basic melee combat with attack radius and hit detection
- Modular enemy AI that chases the player
- Entity-based health and death system (`EntityStats.cs`)
- Procedural room generation system with reusable room prefabs
- Dynamic enemy spawning based on room content
- Camera follow system (`CameraFollow.cs`)
- Clean folder structure and beginner-friendly code

---

## 📂 Project Structure

```
/Assets
├── Animations/         → Player and enemy animation clips
├── Prefabs/            → Player, enemy, room and UI prefabs
├── Scenes/             → SampleScene is the main scene
├── Scripts/            → All game logic scripts
├── Sprites/            → All pixel art assets
```

---

## 🛠️ How to Run

1. Download or clone the repository  
2. Open the project in **Unity 2022 or newer**  
3. Open `Scenes/SampleScene.unity`  
4. Press **Play** and explore the generated dungeon!

Optional:
- Add more room prefabs in `/Prefabs/Rooms/` to expand the generation
- Tweak values in `DungeonGenerator.cs` for more complexity
- Use the project as a base for your own roguelike experiments

---

## 🧠 Learning Goals

This project is ideal for developers who want to learn:

- Unity 2D workflow and scripting
- Basic game architecture with prefabs and modular scripts
- Procedural generation principles
- Implementing simple enemy behavior and combat
- Organizing a small game project with clarity

---

## 🤝 Contributions

Feel free to fork the project, open issues, or suggest improvements. This prototype is meant to be a foundation — build on it, break it, and make it your own!

---

## 📜 License

This project is released under the **MIT License**.  
Use it freely for educational, personal or commercial projects — no attribution required (but appreciated!).

---

Happy dungeon crawling! ⚔️  
– Ryadel - https://www.ryadel.com/
