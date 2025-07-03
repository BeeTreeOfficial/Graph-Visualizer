using Raylib_cs;

namespace DijkstraAlgorithm.TimeRelated;
public class DurationTimer(double Duration)
{
    private double startTime = Raylib.GetTime();
    private readonly double duration = Duration;
    private bool running = true;
    private double TimeLeft;
    public bool IsRunning
    {
        get
        {
            TimeLeft = (Raylib.GetTime() - duration);
            if (TimeLeft >= startTime)
            {
                running = false;
                startTime = Raylib.GetTime();
            }
            return running;
        }
    }
    public void Start()
    {
        running = true;
    }
}


