using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Process
{
	public int BurstTime { get; private set; }
	public int RemainingTime { get; set; }
	public int ArrivalTime { get; set; }
	public int EndTime { get; set; }

	public Process(int totalTime)
	{
		BurstTime = totalTime;
		ArrivalTime = 0;
		RemainingTime = BurstTime;
	}

	public Process Copy()
	{
		Process process = new Process(BurstTime);
		process.RemainingTime = RemainingTime;
		process.ArrivalTime = ArrivalTime;
		process.EndTime = EndTime;
		return process;
	}
}