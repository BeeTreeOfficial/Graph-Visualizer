# Graph Visualizer


## Features

- Interactive graph editing:
  - Add/remove vertices and edges via text commands
  - Select, move, and highlight vertices with the mouse
- Live camera controls (pan & zoom)
- Command console at the bottom of the screen
- Real-time visualization of:
  - Dijkstra’s shortest-path algorithm
  - Bellman–Ford algorithm
- Random graph generation and shuffling
- Optional fullscreen toggle and FPS display



## Demo

![Demo Screenshot](./RepoRelated/TimeLapse.gif)


## Requirements

- .NET 6.0 SDK or higher
- Raylib_cs (>= 4.0)
- A graphics-capable platform supported by Raylib (Windows, Linux, macOS)

## Getting Started

1. Clone this repository  
   `git clone https://github.com/BeeTreeOfficial/Graph-Visualizer.git`

2. Navigate into the project folder  
   `cd dijkstra-visualizer`

3. Restore NuGet packages  
   `dotnet restore`

4. Build and run  
   `dotnet run --project DijkstraAlgorithm`

## How to Use

When the application launches, you’ll see a blank canvas. Toggle typing mode with `Tab`. In typing mode, enter commands in the console at the bottom. Press `Enter` to execute.

### Basic Commands

- `ADD <name>`  
  Create a new vertex at the current camera focus with the given name.  
- `ADD <name> <color>` 
  RED,  GREEN, BLACK, BLUE, YELLOW;
  Create a vertex and display a custom color.

- `DEL <name>`  
  Remove the vertex (and all its edges).

- `DEL <name1> <name2>`  
  Remove the edge between two vertices.

- `CON <name1> <name2>`  
  Connect two existing vertices with an undirected edge.

- `SEL <name>`  
  Select a vertex to move it with the mouse.  
- `SEL`  
  Deselect the current vertex.

- `RAND`  
  Shuffle all vertices to random positions.

- `NEW`  
  Clear the entire graph.

- `ABC`  
  Quickly generate 5 labeled nodes (`A` → `E`) and shuffle them.

### Pathfinding Commands

- `DEX <start>`  
  Solve shortest paths from `<start>` using **Dijkstra’s algorithm**.  
  Outputs each vertex, its distance, and path.

- `BELL <start>`  
  Solve single-source shortest paths with **Bellman–Ford**.  
  Outputs distances and paths; detects negative cycles.

### Camera & View

- Pan: W A S D 
- Zoom: Q / E 
- Fullscreen Toggle: Press `F`

### Miscellaneous

- `P` (when not typing): Print graph data to console  
- `ESC` or close window: Exit application  
- FPS counter in the top-left corner  

## Contributing

1. Fork this repository  
2. Create your feature branch (`git checkout -b feature/my-cool-feature`)  
3. Commit your changes (`git commit -am 'Add some feature'`)  
4. Push to your branch (`git push origin feature/my-cool-feature`)  
5. Open a Pull Request

Please adhere to existing code style and include tests/examples when appropriate.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
