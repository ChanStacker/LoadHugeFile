// See https://aka.ms/new-console-template for more information
Console.WriteLine("Increasing number of threadpool threads");


int minWorkerThreads, completionPortThreads;
ThreadPool.GetMinThreads(out minWorkerThreads, out completionPortThreads);
DisplayCounts(minWorkerThreads, completionPortThreads);

ThreadPool.SetMinThreads(minWorkerThreads + 10, completionPortThreads);

ThreadPool.GetMinThreads(out minWorkerThreads, out completionPortThreads);
DisplayCounts(minWorkerThreads, completionPortThreads);

ThreadPool.GetAvailableThreads(out minWorkerThreads, out completionPortThreads);
DisplayCounts(minWorkerThreads, completionPortThreads);
void DisplayCounts(int workerThreads, int completionPortThreads)
{
    Console.WriteLine("Number of worker threads: " + workerThreads);
    Console.WriteLine("Number of I/O completion threads: " + completionPortThreads);
}
