using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
	const int maxProcessTime = 100;
	const int initialProcessCount = 300;
	const int addedProcesses = 1200;
	const int sim_count = 5;

	const int SRTF_QuantumTime = 20;
	const int RR_QuantumTime = 50;

	static void Main(string[] args)
	{
		ProcessGenerator generator = new ProcessGenerator();
		Algorithm[] algorithms = new Algorithm[] { new FIFO(), new SJF(), new SRTF(SRTF_QuantumTime), new RR(RR_QuantumTime) };
		long[] avgTimes = new long[algorithms.Length];

		for (int i = 0; i < sim_count; i++)
		{
			generator.generate(maxProcessTime, initialProcessCount, addedProcesses);
			for (int j = 0; j < algorithms.Length; j++)
			{
				algorithms[j].setProcessList(generator.getProcessListCopy());
				var sim_result = algorithms[j].simulate();
				avgTimes[j] += sim_result.AvgWaitingTime;
			}
			Console.WriteLine("Simulation " + (i+1) + " completed");
		}

		Console.WriteLine('\n');

		for (int i = 0; i < avgTimes.Length; i++)
		{
			avgTimes[i] /= sim_count;
			string algName = algorithms[i].name;

			Console.WriteLine("Average waiting time with " + algName + ": " + avgTimes[i] + " ms");
		}

		Console.ReadKey();
	}
}

