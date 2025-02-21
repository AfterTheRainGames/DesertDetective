# Desert Detective  
**Game Jam Submission**  
*DESSERT Theme | Limitation: Sharing is Caring | July 19-22 2024*

## Overview  
**Desert Detective** is an interactive puzzle game set in a mysterious desert environment. Players take on the role of a detective solving riddles, unlocking secret IDs, and piecing together clues to uncover hidden truths. With unique interactions, word puzzles, and object-based gameplay, the detective slowly unravels the desert's secrets.

---

## Key Contributions as a Gameplay Programmer  

### **Interactions System**  
- Developed the core interaction system where the player engages with different objects in the environment, including clickable buttons and hidden objects.  
- Created a mechanic to track and display unlocked IDs as the player progresses, with UI updates reflecting the player’s progress.  
- Implemented logic to unlock access to new areas, such as the basement, based on completed objectives.

### **Word Puzzle Mechanic**  
- Designed and implemented a word puzzle system using clickable buttons to cycle through letters, requiring the player to match the correct word "CAT" to progress.  
- Integrated dynamic text updates based on player input and conditional checks to track puzzle completion.
- Implimented morse code lighting as indicator for puzzle solution.

### **Movement System**  
- Developed a smooth character movement system with basic walking and gravity-based mechanics.  
- Implemented sprinting functionality using the Shift key for faster movement.  
- Designed the system to be responsive and intuitive for exploration in the dessert environment.

### **UI and Progression**  
- Created a dynamic UI system to display the number of IDs unlocked, updating in real-time as the player progresses through the game.  
- Designed the basement button to only become active after all IDs are unlocked, requiring players to solve puzzles and advance in the game.

---

## Challenges Overcome  

### **Complex Interactions**  
- **Issue**: Integrating multiple UI updates and maintaining fluid game progress caused synchronization issues between the player's actions and UI elements.  
  - **Solution**: Used event-driven updates and ensured that UI elements only update when relevant to the current state, improving flow and preventing bugs.

### **Puzzle Difficulty and Feedback**  
- **Issue**: The word puzzle system could have been frustrating if players didn't get clear feedback on their progress.  
  - **Solution**: Added clear visual cues and dynamic text updates to guide the player through the puzzle-solving process.

### **Flag Puzzle Complexity**  
- **Issue**: Connection between food names and variables began increasingly complex. 
  - **Solution**: Renamed 3D models and variables accordingly to simplying the organization of the food puzzle.

---

## Reflection  
Desert Detective allowed me to explore the challenge of creating engaging interaction-based mechanics and puzzles. The game’s atmosphere relies on small, rewarding moments of progression as the player solves puzzles and uncovers secrets. Balancing the progression with a lighthearted mystery theme was a fun and rewarding design challenge.

---

## Play the Game  
[Play Desert Detective on Itch.io](https://aftertheraingames.itch.io/dessert-detective)
