# 🏀 AR Basketball Game

An Augmented Reality (AR) basketball game built using Unity and AR Foundation that allows players to place a virtual basketball hoop in the real world and shoot basketballs using touch gestures. The project combines AR plane detection, object placement, physics-based shooting mechanics, trajectory prediction, and score tracking to create an immersive basketball experience.

## 🚀 Features

### 🏀 AR Hoop Placement

* Detects real-world surfaces using AR Foundation.
* Displays a placement indicator on detected planes.
* Allows users to place a basketball hoop in their environment with a simple tap.

### 🎯 Physics-Based Shooting

* Drag-and-release gesture controls shooting power.
* Realistic basketball physics using Unity Rigidbody.
* Adjustable shooting force based on drag distance.

### 📈 Trajectory Prediction

* Visualizes the ball's predicted path before shooting.
* Uses Unity's physics engine to simulate projectile motion.
* Improves aiming accuracy and gameplay experience.

### 🎮 Interactive Gameplay

* Real-time basketball shooting.
* Score tracking system.
* Collision-based basket detection.

### 📱 Mobile AR Experience

* Built using AR Foundation.
* Supports plane detection and object placement.
* Designed for Android and iOS AR-enabled devices.

---

## 🛠️ Tech Stack

### Game Engine

* Unity

### AR Development

* AR Foundation
* AR Raycast Manager
* AR Plane Detection

### Programming

* C#

### Physics

* Unity Physics Engine
* Rigidbody
* Collision Detection

### UI

* Unity UI
* Text Components
* Line Renderer

---

## 🧠 System Architecture

### AR Plane Detection

1. Detect horizontal surfaces.
2. Display placement indicator.
3. Allow user to place the hoop.

### Shooting System

1. Detect touch drag.
2. Calculate shooting force.
3. Spawn basketball.
4. Apply force using Rigidbody.

### Trajectory Visualization

1. Calculate projectile motion.
2. Simulate gravity effects.
3. Render trajectory using LineRenderer.

### Score System

1. Detect collisions with target area.
2. Increment player score.
3. Update UI in real time.

---

## 📂 Project Structure

```text
Assets/
│
├── Scripts/
│   ├── PlaceHoop.cs
│   ├── ShootBall.cs
│   ├── BasketballHoopSpawner.cs
│   └── Score.cs
│
├── Prefabs/
│   ├── BasketballHoop
│   ├── Basketball
│   └── PlacementIndicator
│
├── Materials/
├── Scenes/
└── UI/
```

---

## ▶️ How to Play

1. Launch the application.
2. Scan the environment until a plane is detected.
3. Tap to place the basketball hoop.
4. Drag on the screen to aim.
5. Release to shoot the basketball.
6. Score points by shooting through the hoop.

---

## 📚 Learning Outcomes

* Augmented Reality Development
* AR Plane Detection
* Object Placement in AR
* Mobile Game Development
* Physics-Based Gameplay
* Projectile Motion Simulation
* Unity UI Systems
* Collision Detection
* Real-Time Interaction Design

---

## 🚀 Future Improvements

* Multiplayer AR basketball
* Online scoreboards
* Advanced scoring system
* Multiple difficulty levels
* Sound effects and animations
* AR multiplayer synchronization
* Power-ups and challenges
* AI-controlled opponents

## 👨‍💻 Author

Kondamoni Shakthi

Built using Unity, AR Foundation, and C#.
