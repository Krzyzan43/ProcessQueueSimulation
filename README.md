# ProcessQueueSimulation
This program simulates executing processes in an operating system. While simulation is running, processes are added to the process queue and at any given time one process is executed. The program tests average waiting time for different strategies of selecting a process to execute

# Algorithms
  * FCFS - First come first served
  * SJF - Shortest job first
  * SRTF - Shortest remainig time first, same as shortest job first, but when a new process is added that needs less time than currently executed process, new process starts executing instead
  * Rotational - Selects first process, executes it for a certain amount of time, then selects next, regardless if it's completed

# Results
  Right now only waiting time is measured, but more statistics can easily be added
  ```
  Simulation 1 completed
  Simulation 2 completed
  Simulation 3 completed
  Simulation 4 completed
  Simulation 5 completed
  
  
  Average waiting time with FCFS: 19374 ms
  Average waiting time with SJF: 11273 ms
  Average waiting time with SRTF: 11271 ms
  Average waiting time with Rotational: 23301 ms
```
